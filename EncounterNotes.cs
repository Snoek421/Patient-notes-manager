using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Assignment_3
{
    public partial class Form1 : Form
    {
        string fileName = @".\encounter-notes.txt"; //store path of file for easy use in the rest of the program
        List<string> textLines = new List<string>(); //globally accessible list of lines of text read from the file
        List<Patient> patient = new List<Patient>(); //globally accessible list of patient objects created from the lines of text list
        List<string> patientProblems = new List<string>(); //globally accessible list to store patient problems for the selected patient
        List<string> bloodPressures = new List<string>(); //globally accessible list to store the blood pressures for the selected patient
        Regex bloodPressurePattern = new Regex(@"BP:?\s\d{2,3}/\d{2,3}"); //pattern to match against the blood pressure when scanning through text
        Regex noteIdCheck = new Regex(@"^[1-9]\|"); //pattern to use to check whether the text prepared to write to the file was prepared successfully
        int activeNote = -1; // index of currently active note
        bool savedNewNote = false;
        bool newNoteMode = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(fileName)) //check if file exists and if it doesn't, create the file
            {
                File.Create(fileName).Dispose();
            }
            textLines.Clear(); //clear list to prepare for reading the file
            UpdateListbox(); //read the file and store all notes into patient objects in the patients list
            lsbRecords.ClearSelected(); //clear the selected record so that the application is ready for the user to select a record
        }



        private void btnStartNewNote_Click(object sender, EventArgs e)
        {
            ClearFields(); //clear all the text fields and listboxes to prepare for user to input new text
            int lastIndex = patient.Count - 1;
            int newNoteId = Convert.ToInt16(patient[lastIndex].NoteId); //find last stored patient's note id
            newNoteId += 1; // add 1 to generate the new note id
            lsbRecords.ClearSelected(); //clera selected record, to avoid strange interactions with the selected record index in other methods
            AddMode(); //enable and disable correct fields and set "newNoteMode" bool to true
            txtNoteId.Text = newNoteId.ToString(); //display new note id in textbox
            patient.Add(new Patient()); //add new patient for other fields to be accepted into
            patient[patient.Count - 1].NoteId = newNoteId.ToString(); //assign generated noteId to new patient object
            savedNewNote = false; //this allows other methods and handlers to easily tell if they need to change or delete anything before proceeding
        }

        private void lsbRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeNote = lsbRecords.SelectedIndex;
            if (newNoteMode == true && savedNewNote == false)
            {
                patient.Remove(patient[patient.Count - 1]); //if new note was started but not saved, remove the temporary patient object to keep the newNoteId generation correct
            }
            if (lsbRecords.SelectedIndex == -1) //if no record is selected then clear all fields and listboxes, and enter waiting mode
            {
                patientProblems.Clear();
                bloodPressures.Clear();
                ClearFields();
                WaitingMode();
                return;
            }
            else //if record has been selected, display patient attributes in correct locations
            {
                txtNoteId.Text = patient[activeNote].NoteId;
                txtPatientName.Text = patient[activeNote].PatientName;
                dtpDateOfBirth.Value = patient[activeNote].BirthDate;
                patientProblems.Clear(); //clear string list to prepare for new problems to be added
                foreach (string problem in patient[activeNote].PatientProblems) //for each string in problems attribute list add the string to local list
                {
                    patientProblems.Add(problem);
                }
                lsbProblems.DataSource = null;
                lsbProblems.DataSource = patientProblems; //set datasource to null and back to patientProblems list to refresh items
                lsbProblems.ClearSelected(); //clear selected index for visual clarity
                rtbNotes.Text = patient[activeNote].AdditionalNotes.Replace(';', '\n'); //display other notes in rich textbox and replace secondary split character with newline character
                bloodPressures.Clear(); //clear list to prepare for new blood pressures to be added
                MatchCollection bpMatches = bloodPressurePattern.Matches(patient[activeNote].AdditionalNotes); //collect substrings that match the blood pressure pattern stored at the start of the program
                foreach (Group match in bpMatches)
                {
                    string bpString = match.Value.Trim();
                    bpString = Regex.Replace(bpString, "BP: ", ""); 
                    bpString = Regex.Replace(bpString, "BP ", "");
                    bloodPressures.Add(bpString); //remove BP: and BP from each substring, and add blood pressure numbers to list to display
                }
                lsbBloodPressure.DataSource = bloodPressures; 
                lsbBloodPressure.ClearSelected();
                EditMode();
                
            }
        }

        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            if (activeNote == -1) //if user is adding new note
            {
                patientProblems.Add(txtNewProblem.Text.Trim()); //add text from new problem textbox to the list used to display the problems of the patient
                lsbProblems.DataSource = null;
                lsbProblems.DataSource = patientProblems; //refresh the datasource of the listbox to update the items
                lsbProblems.SelectedIndex = -1; // clear selected item for visual clarity
                txtNewProblem.Text = ""; //clear new problem textbox for user to add more new problems
            }
            else // if user selected a patient record
            {
                patientProblems = patient[activeNote].PatientProblems; //store patient's problems in list temporarily to easily add new problems
                patientProblems.Add(txtNewProblem.Text.Trim()); //add text from textbox to the list
                lsbProblems.DataSource = null;
                lsbProblems.DataSource = patientProblems; 
                lsbProblems.SelectedIndex = -1;
                txtNewProblem.Text = "";
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {


            string prepResult = PrepareStringToWrite(); //run method to validate and prepare all text into one string to write to the file
            if (!noteIdCheck.IsMatch(prepResult)) //check if returned string starts with a note id. If not then the returned string is errors
            {
                lblMessage.Text = prepResult; //display errors that were returned by the method
                return;
            }
            else //if method prepared text successfully then open new streamwriter and write new line containing the prepared string
            {
                StreamWriter writer = new StreamWriter(fileName, true) { AutoFlush = true }; 
                writer.WriteLine(prepResult);
                savedNewNote = true; //this will let other event handler code know that the new note has been successfully saved and that they don't have to delete the temporary patient object
                writer.Dispose();
            }
            UpdateListbox(); //update listbox with new patient
            EditMode(); //enter edit mode on newly saved note
            lsbRecords.SelectedIndex = patient.Count - 1; //select the newly added note
        }

        private void btnUpdateNote_Click(object sender, EventArgs e)
        {
            activeNote = lsbRecords.SelectedIndex; //store selected record index to try to fix bug where selected record is reset
            string prepResult = PrepareStringToWrite(); //run method to validate and prepare text for writing to file
            if (!noteIdCheck.IsMatch(prepResult))
            {
                lblMessage.Text = prepResult;
                return;
            }
            else //if method prepares text successfully
            {
                string[] textLines = File.ReadAllLines(fileName); //read all lines into array
                textLines[activeNote] = prepResult; //rewrite current record with prepared text
                File.WriteAllLines(fileName, textLines); //rewrite full file to update correct line and keep all other text the same
                UpdateListbox(); //update left box in case name of patient was changed
            }
            lsbRecords.SelectedIndex = activeNote; //attempt to re-select the last active note to fix bug where selected record is reset
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            activeNote = lsbRecords.SelectedIndex; //store active note
            string[] textLines = File.ReadAllLines(fileName); //read all lines into array
            textLines[activeNote] = ""; //rewrite current record with empty string
            List<string> textAfterDelete = new List<string>(); //create temporary list to store all text lines aside from empty string
            foreach (string line in textLines)
            {
                if (line != "")
                {
                    textAfterDelete.Add(line);
                }
            }
            File.WriteAllLines(fileName, textAfterDelete); //write all lines in temporary string list
            UpdateListbox();
            lsbRecords.SelectedIndex = activeNote - 1; //select item one above the deleted note, to prevent error from index out of range
        }

        private void rtxNotes_TextChanged(object sender, EventArgs e)
        {
            MatchCollection bpMatches = bloodPressurePattern.Matches(rtbNotes.Text.ToString()); //every time rich textbox is changed, scan for and gather any matches for blood pressure patttern
            if (bpMatches.Count > 0) //if any matches are found, clear blood pressures list, trim, extract, and add blood pressure numbers to list
            {
                bloodPressures.Clear();
                foreach (Group match in bpMatches)
                {
                    string bpString = match.Value.Trim();
                    bpString = Regex.Replace(bpString, "BP: ", "");
                    bpString = Regex.Replace(bpString, "BP ", "");
                    bloodPressures.Add(bpString);
                }
                lsbBloodPressure.DataSource = null;
                lsbBloodPressure.DataSource = bloodPressures;
                lsbBloodPressure.SelectedIndex = -1;
            }
        }

        // Methods Start //
        private void UpdateListbox()
        {
            patient.Clear(); //clear patient list to prepare for reading or re-reading the file text
            StreamReader reader = new StreamReader(path: fileName);
            while (!reader.EndOfStream) //until the reader reaches the end of the file, read and add each line to a dynamically sized list of strings
            {
                textLines.Add(reader.ReadLine());
            }
            List<string> patientRecords = new List<string>(); // create list for strings to display in patient records listbox
            for (int i = 0; i < textLines.Count; i++)
            {
                
                patient.Add(new Patient()); //add new patient to list of patient objects
                patient[i].FillDetails(textLines[i]); //run method to fill details for new patient with information extracted from line of text
                patientRecords.Add(patient[i].FillLeftListbox()); //run method to add necessary information from new patient into patient records listbox list
            }
            textLines.Clear(); //clear text read from file for data security and to prepare for next run of this method
            lsbRecords.DataSource = patientRecords;
            reader.Dispose();
        }

        private void EditMode() //enable and disable correct buttons to allow user to edit a record
        {
            txtPatientName.Enabled = true;
            dtpDateOfBirth.Enabled = true;
            txtNewProblem.Enabled = true;
            rtbNotes.Enabled = true;
            btnAddNote.Enabled = false;
            btnAddProblem.Enabled = true;
            btnUpdateNote.Enabled = true;
            btnDeleteNote.Enabled = true;
        }

        private void WaitingMode() //for application when it loads or has no patient record selected. Only enable start new note button
        {
            txtPatientName.Enabled = false;
            dtpDateOfBirth.Enabled = false;
            txtNewProblem.Enabled = false;
            rtbNotes.Enabled = false;
            btnAddNote.Enabled = false;
            btnAddProblem.Enabled = false;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = false;
            btnStartNewNote.Enabled = true;
        }

        private void AddMode() //only is used when user clicks start new note button. Disables ability to update or delete note
        {
            newNoteMode = true;
            txtPatientName.Enabled = true;
            dtpDateOfBirth.Enabled = true;
            txtNewProblem.Enabled = true;
            rtbNotes.Enabled = true;
            btnAddNote.Enabled = true;
            btnAddProblem.Enabled = true;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = false;
        }

        private void ClearFields() //used to clear all patient data fields, to prepare for inputs or when application is put into waiting mode
        {
            txtNoteId.Text = "";
            txtPatientName.Text = "";
            dtpDateOfBirth.Value = DateTime.Now;
            txtNewProblem.Text = "";
            lsbProblems.DataSource = null;
            rtbNotes.Text = "";
            lsbBloodPressure.DataSource = null;
        }

        private string PrepareStringToWrite() //extracts text from all textboxes and validates if necessary, then adds all of the text into a single string to write
        {
            string problems = ""; //initialize string to store items in problems listbox
            for (int i = 0; i < lsbProblems.Items.Count; i++)
            {
                if (lsbProblems.Items[i].ToString() == "") //if item is empty, don't touch the string
                { }
                else if (i == lsbProblems.Items.Count - 1)
                {
                    problems += lsbProblems.Items[i].ToString(); //if item is the last one in the listbox, don't append ; to the end, and break the loop
                    break;
                }
                else
                {
                    problems += lsbProblems.Items[i].ToString() + ";"; //for each item in problems listbox, write to the string then add the secondary delimiting character
                }
            }
            string clinicalNotes = rtbNotes.Text.ToString();
            string result = Patient.InfoValidation(txtPatientName.Text, dtpDateOfBirth.Value, clinicalNotes); //run validation on the necessary fields before adding to string
            if (result != "success")
            {
                return result; //if validation fails, it returns a string holding the errors, which this method can then pass forward to be displayed in a label
            }
            else //if validation succeeds, make string of all patient attributes from textboxes and problems listbox, with correct delimiting characters placed in correct places
            {
                string preppedText = txtNoteId.Text + "|" + txtPatientName.Text + "|" + dtpDateOfBirth.Text.ToString() + "|" + problems + "|" + clinicalNotes.Replace("\n", ";");
                return preppedText;
            }
            
        }
       
    }
}
