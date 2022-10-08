using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal class Patient
    {
        private string _NoteId;
        private string _PatientName;
        private DateTime _BirthDate;
        private List<string> _PatientProblems;
        private string _AdditionalNotes;

        public string NoteId { get; set; }
        public string PatientName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<string> PatientProblems { get; set; }
        public string AdditionalNotes { get; set; }

        public Patient() //default constructor
        {
            this._NoteId = "";
            this._PatientName = "";
            this._BirthDate = DateTime.Now;
            this._PatientProblems = new List<string>();
            this._AdditionalNotes = "";
        }

        public Patient(string noteId, string patientName, DateTime birthDate, List<string> patientProblems, string additionalNotes)
        {
            this._NoteId = noteId;
            this._PatientName = patientName;
            this._BirthDate = birthDate;
            this._PatientProblems = patientProblems;
            this._AdditionalNotes = additionalNotes;
        }

        public void FillDetails(string inputLine) //takes a string input (read from the file), parses it into a format that is easy to use, then fills the attributes of the patient object with correct information
        {
            List<string> splitRecord = inputLine.Split('|').ToList();
            this.NoteId = splitRecord[0];
            this.PatientName = splitRecord[1];
            this.BirthDate = DateTime.Parse(splitRecord[2]);
            this.PatientProblems = splitRecord[3].Split(';').ToList();
            this.AdditionalNotes = splitRecord[4];
        }

        public string FillLeftListbox() //returns a string which will be used to display the patient name and note id in the patient records listbox
        {
            string recordInfo = this.PatientName + " (Note " + this.NoteId + ")";
            return recordInfo;
        }

        public static string InfoValidation(string patientName, DateTime birthDate, string patientProblems) //used to validate the input strings and return either "success" or a string containing the errors in the validation
        {
            string problemField = "";
            if (String.IsNullOrEmpty(patientName))
            {
                problemField = "No name was entered" + Environment.NewLine;
            }
            if (birthDate >= DateTime.Now)
            {
                problemField += "Birth date must be in the past" + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(patientProblems))
            {
                problemField += "Patient clinical notes must not be empty";
            }
            if (!String.IsNullOrEmpty(problemField))
            {
                return problemField;
            }
            else
            {
                return "success";
            }
        }
    }
}
