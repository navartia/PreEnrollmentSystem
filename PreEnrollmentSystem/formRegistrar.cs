using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PreEnrollmentSystem
{
    public partial class FormRegistrar : Form
    {
        public FormRegistrar()
        {
            InitializeComponent();
        }

        private void FormRegistrar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enrollmentDataSet.StudentScheduleView' table. You can move, or remove it, as needed.

            //this.studentScheduleViewTableAdapter.Fill(this.enrollmentDataSet.StudentScheduleView);

            // TODO: This line of code loads data into the 'enrollmentDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.enrollmentDataSet.Students);
            
            panelHome.BringToFront();

            comboBoxStudentStatus.Items.Add("Regular");
            comboBoxStudentStatus.Items.Add("Irregular");

            comboBoxCourse.Items.Add("ABComm");
            comboBoxCourse.Items.Add("BSCpE");
            comboBoxCourse.Items.Add("BSCS");
            comboBoxCourse.Items.Add("BSHRM");
            comboBoxCourse.Items.Add("BSIT");
            comboBoxCourse.Items.Add("BSITDA");

            comboBoxStudentGender.Items.Add("Male");
            comboBoxStudentGender.Items.Add("Female");

            comboBoxStudentCivilStatus.Items.Add("Single");
            comboBoxStudentCivilStatus.Items.Add("Married");
            comboBoxStudentCivilStatus.Items.Add("Divorced");
            comboBoxStudentCivilStatus.Items.Add("Widowed");

            comboBoxPresentRegion.Items.Add("National Capital Region");
            comboBoxPresentRegion.Items.Add("Cordillera Administrative Region");
            comboBoxPresentRegion.Items.Add("Region I - Ilocos Region");
            comboBoxPresentRegion.Items.Add("Region II - Cagayan Valley");
            comboBoxPresentRegion.Items.Add("Region III - Central Luzon");
            comboBoxPresentRegion.Items.Add("Region IV-A - CALABARZON");
            comboBoxPresentRegion.Items.Add("Region IV-B - MIMAROPA");
            comboBoxPresentRegion.Items.Add("Region V - Bicol Region");
            comboBoxPresentRegion.Items.Add("Region VI - Western Visayas");
            comboBoxPresentRegion.Items.Add("Region VII - Central Visayas");
            comboBoxPresentRegion.Items.Add("Region VIII - Eastern Visayas");
            comboBoxPresentRegion.Items.Add("Region IX - Zamboanga Peninsula");
            comboBoxPresentRegion.Items.Add("Region X - Northern Mindanao");
            comboBoxPresentRegion.Items.Add("Region XI - Davao Region");
            comboBoxPresentRegion.Items.Add("Region XII - SOCCSKARGEN");
            comboBoxPresentRegion.Items.Add("Region XIII - Caraga");
            comboBoxPresentRegion.Items.Add("Autonomous Region in Muslim Mindanao");

            comboBoxProvinceRegion.Items.Add("National Capital Region");
            comboBoxProvinceRegion.Items.Add("Cordillera Administrative Region");
            comboBoxProvinceRegion.Items.Add("Region I - Ilocos Region");
            comboBoxProvinceRegion.Items.Add("Region II - Cagayan Valley");
            comboBoxProvinceRegion.Items.Add("Region III - Central Luzon");
            comboBoxProvinceRegion.Items.Add("Region IV-A - CALABARZON");
            comboBoxProvinceRegion.Items.Add("Region IV-B - MIMAROPA");
            comboBoxProvinceRegion.Items.Add("Region V - Bicol Region");
            comboBoxProvinceRegion.Items.Add("Region VI - Western Visayas");
            comboBoxProvinceRegion.Items.Add("Region VII - Central Visayas");
            comboBoxProvinceRegion.Items.Add("Region VIII - Eastern Visayas");
            comboBoxProvinceRegion.Items.Add("Region IX - Zamboanga Peninsula");
            comboBoxProvinceRegion.Items.Add("Region X - Northern Mindanao");
            comboBoxProvinceRegion.Items.Add("Region XI - Davao Region");
            comboBoxProvinceRegion.Items.Add("Region XII - SOCCSKARGEN");
            comboBoxProvinceRegion.Items.Add("Region XIII - Caraga");
            comboBoxProvinceRegion.Items.Add("Autonomous Region in Muslim Mindanao");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox26.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelHome.BringToFront();
        }

        private void buttonCreateStudent_Click(object sender, EventArgs e)
        {
            panelCreateStudentAccount.BringToFront();
        }

        private void buttonStudentAssessment_Click(object sender, EventArgs e)
        {
            panelStudentAssessment.BringToFront();
        }

        private void buttonStudentAnnouncement_Click(object sender, EventArgs e)
        {
            panelCreateAnnouncements.BringToFront();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            String username = textBoxStudentFirstname.Text;
            username = username.Replace(" ", String.Empty) + "." + textBoxStudentLastname.Text;
            username = username.ToLower();

            String course = comboBoxCourse.Text;
            int programID = (int)this.studentsTableAdapter.GetProgramID(course);

            String studNum = textBox3.Text + " - " + textBox1.Text + " - " + textBox2.Text;
            this.accountsTableAdapter.Insert(username, "student", "student");
            int accountID = (int)this.studentsTableAdapter.GetAccountID(username);

            this.studentsTableAdapter.Insert(accountID, programID, textBoxStudentLastname.Text,
                textBoxStudentFirstname.Text, textBoxStudentMiddlename.Text, studNum,
                comboBoxStudentStatus.Text, comboBoxStudentGender.Text,
                dateTimePickerBirthdate.Text, textBoxStudentBirthplace.Text, textBoxStudentCitizenship.Text,
                comboBoxStudentCivilStatus.Text, textBoxStudentReligion.Text, textBoxStudentMobile.Text,
                textBoxStudentLandline.Text, textBoxStudentEmail.Text);

            MessageBox.Show("Created an account successfully!\n Username: " + username);

        }

        private void buttonClearData_Click(object sender, EventArgs e)
        {
            textBoxStudentFirstname.Text = "";
            textBoxStudentMiddlename.Text = "";
            textBoxStudentLastname.Text = "";
            comboBoxCourse.Text = "";

            comboBoxStudentGender.Text = "";
            dateTimePickerBirthdate.Text = "";
            textBoxStudentBirthplace.Text = "";
            textBoxStudentCitizenship.Text = "";
            comboBoxStudentCivilStatus.Text = "";
            textBoxStudentReligion.Text = "";

            textBoxStudentMobile.Text = "";
            textBoxStudentLandline.Text = "";
            textBoxStudentEmail.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBoxStudentStatus.Text = "";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Schedule Validated Successfully!.");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxHeader1.Clear();
            textBoxHeader2.Clear();
            textBoxHeader3.Clear();

            textBoxDetails1.Clear();
            textBoxDetails2.Clear();
            textBoxDetails3.Clear();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.announcementsTableAdapter.Insert(textBoxHeader1.Text, textBoxDetails1.Text);

            this.announcementsTableAdapter.Insert(textBoxHeader2.Text, textBoxDetails2.Text);

            this.announcementsTableAdapter.Insert(textBoxHeader3.Text, textBoxDetails3.Text);

            MessageBox.Show("Announcements Posted Successfully!");
        }

        private void buttonPrintSchedule_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
            doc.Open();

            Paragraph paragraph = new Paragraph("Data Grid View Contents");

            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
            }

            table.HeaderRows = 1;

            for (int b = 0; b < 10; b++)
            {
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    if (dataGridView1[c, b].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView1[c, b].Value.ToString()));
                    }
                }
            }

            doc.Add(paragraph);
            doc.Add(table);
            doc.Close();

            MessageBox.Show("PDF successfully created!");
        }
    }
}
