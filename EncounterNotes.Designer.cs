namespace Assignment_3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartNewNote = new System.Windows.Forms.Button();
            this.lsbRecords = new System.Windows.Forms.ListBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteNote = new System.Windows.Forms.Button();
            this.btnUpdateNote = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lsbBloodPressure = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lsbProblems = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddProblem = new System.Windows.Forms.Button();
            this.txtNewProblem = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtNoteId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartNewNote
            // 
            this.btnStartNewNote.Location = new System.Drawing.Point(12, 22);
            this.btnStartNewNote.Name = "btnStartNewNote";
            this.btnStartNewNote.Size = new System.Drawing.Size(93, 23);
            this.btnStartNewNote.TabIndex = 0;
            this.btnStartNewNote.Text = "Start new note";
            this.btnStartNewNote.UseVisualStyleBackColor = true;
            this.btnStartNewNote.Click += new System.EventHandler(this.btnStartNewNote_Click);
            // 
            // lsbRecords
            // 
            this.lsbRecords.FormattingEnabled = true;
            this.lsbRecords.Location = new System.Drawing.Point(12, 59);
            this.lsbRecords.Name = "lsbRecords";
            this.lsbRecords.Size = new System.Drawing.Size(137, 394);
            this.lsbRecords.TabIndex = 1;
            this.lsbRecords.SelectedIndexChanged += new System.EventHandler(this.lsbRecords_SelectedIndexChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 469);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteNote);
            this.groupBox1.Controls.Add(this.btnUpdateNote);
            this.groupBox1.Controls.Add(this.btnAddNote);
            this.groupBox1.Controls.Add(this.rtbNotes);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lsbBloodPressure);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lsbProblems);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnAddProblem);
            this.groupBox1.Controls.Add(this.txtNewProblem);
            this.groupBox1.Controls.Add(this.dtpDateOfBirth);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.txtNoteId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(169, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 504);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/Edit/Delete Encounter Note";
            // 
            // btnDeleteNote
            // 
            this.btnDeleteNote.Enabled = false;
            this.btnDeleteNote.Location = new System.Drawing.Point(183, 447);
            this.btnDeleteNote.Name = "btnDeleteNote";
            this.btnDeleteNote.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteNote.TabIndex = 17;
            this.btnDeleteNote.Text = "Delete note";
            this.btnDeleteNote.UseVisualStyleBackColor = true;
            this.btnDeleteNote.Click += new System.EventHandler(this.btnDeleteNote_Click);
            // 
            // btnUpdateNote
            // 
            this.btnUpdateNote.Enabled = false;
            this.btnUpdateNote.Location = new System.Drawing.Point(102, 447);
            this.btnUpdateNote.Name = "btnUpdateNote";
            this.btnUpdateNote.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateNote.TabIndex = 16;
            this.btnUpdateNote.Text = "Update note";
            this.btnUpdateNote.UseVisualStyleBackColor = true;
            this.btnUpdateNote.Click += new System.EventHandler(this.btnUpdateNote_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Enabled = false;
            this.btnAddNote.Location = new System.Drawing.Point(21, 447);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(75, 23);
            this.btnAddNote.TabIndex = 15;
            this.btnAddNote.Text = "Add note";
            this.btnAddNote.UseVisualStyleBackColor = true;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // rtbNotes
            // 
            this.rtbNotes.Enabled = false;
            this.rtbNotes.Location = new System.Drawing.Point(21, 209);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(582, 221);
            this.rtbNotes.TabIndex = 14;
            this.rtbNotes.Text = "";
            this.rtbNotes.TextChanged += new System.EventHandler(this.rtxNotes_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Notes:";
            // 
            // lsbBloodPressure
            // 
            this.lsbBloodPressure.FormattingEnabled = true;
            this.lsbBloodPressure.Location = new System.Drawing.Point(504, 58);
            this.lsbBloodPressure.Name = "lsbBloodPressure";
            this.lsbBloodPressure.Size = new System.Drawing.Size(99, 134);
            this.lsbBloodPressure.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "BP Measurements:";
            // 
            // lsbProblems
            // 
            this.lsbProblems.FormattingEnabled = true;
            this.lsbProblems.Location = new System.Drawing.Point(388, 58);
            this.lsbProblems.Name = "lsbProblems";
            this.lsbProblems.Size = new System.Drawing.Size(101, 134);
            this.lsbProblems.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Problems:";
            // 
            // btnAddProblem
            // 
            this.btnAddProblem.Enabled = false;
            this.btnAddProblem.Location = new System.Drawing.Point(297, 145);
            this.btnAddProblem.Name = "btnAddProblem";
            this.btnAddProblem.Size = new System.Drawing.Size(75, 23);
            this.btnAddProblem.TabIndex = 8;
            this.btnAddProblem.Text = "Add";
            this.btnAddProblem.UseVisualStyleBackColor = true;
            this.btnAddProblem.Click += new System.EventHandler(this.btnAddProblem_Click);
            // 
            // txtNewProblem
            // 
            this.txtNewProblem.Enabled = false;
            this.txtNewProblem.Location = new System.Drawing.Point(91, 147);
            this.txtNewProblem.Name = "txtNewProblem";
            this.txtNewProblem.Size = new System.Drawing.Size(200, 20);
            this.txtNewProblem.TabIndex = 7;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "dd MMM yyyy";
            this.dtpDateOfBirth.Enabled = false;
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(91, 111);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(104, 20);
            this.dtpDateOfBirth.TabIndex = 6;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Enabled = false;
            this.txtPatientName.Location = new System.Drawing.Point(91, 73);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(281, 20);
            this.txtPatientName.TabIndex = 5;
            // 
            // txtNoteId
            // 
            this.txtNoteId.Enabled = false;
            this.txtNoteId.Location = new System.Drawing.Point(91, 37);
            this.txtNoteId.Name = "txtNoteId";
            this.txtNoteId.Size = new System.Drawing.Size(74, 20);
            this.txtNoteId.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "New problem:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Date of Birth:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Patient name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Note ID:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lsbRecords);
            this.Controls.Add(this.btnStartNewNote);
            this.Name = "Form1";
            this.Text = "Patient Notes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartNewNote;
        private System.Windows.Forms.ListBox lsbRecords;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteNote;
        private System.Windows.Forms.Button btnUpdateNote;
        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lsbBloodPressure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lsbProblems;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddProblem;
        private System.Windows.Forms.TextBox txtNewProblem;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtNoteId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

