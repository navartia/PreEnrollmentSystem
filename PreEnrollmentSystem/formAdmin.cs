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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enrollmentDataSet.Enrollment_Report' table. You can move, or remove it, as needed.
            this.enrollment_ReportTableAdapter.Fill(this.enrollmentDataSet.Enrollment_Report);

            comboBoxCourse.Items.Add("General Education");
            comboBoxCourse.Items.Add("ABComm");
            comboBoxCourse.Items.Add("BSCpE");
            comboBoxCourse.Items.Add("BSCS");
            comboBoxCourse.Items.Add("BSHRM");
            comboBoxCourse.Items.Add("BSIT");
            comboBoxCourse.Items.Add("BSITDA");

            comboBoxFacultyGender.Items.Add("Male");
            comboBoxFacultyGender.Items.Add("Female");

            comboBoxFacultyCivilStatus.Items.Add("Single");
            comboBoxFacultyCivilStatus.Items.Add("Married");
            comboBoxFacultyCivilStatus.Items.Add("Divorced");
            comboBoxFacultyCivilStatus.Items.Add("Widowed");

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

        public void loadData(String username)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelHome.BringToFront();
        }

        private void buttonCreateFacultyAccount_Click(object sender, EventArgs e)
        {
            panelEditInfo.BringToFront();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEnrollment_Click(object sender, EventArgs e)
        {
            panelEnrollment.BringToFront();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                this.enrollment_ReportTableAdapter.UpdateRow(row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(),
                    row.Cells[7].Value.ToString(), row.Cells[0].Value.ToString());
            }
        }

        private void buttonClearData_Click(object sender, EventArgs e)
        {
            textBoxStudentFirstname.Text = "";
            textBoxStudentMiddlename.Text = "";
            textBoxStudentLastname.Text = "";
            comboBoxCourse.Text = "";

            comboBoxFacultyGender.Text = "";
            dateTimePickerBirthdate.Text = "";
            textBoxStudentBirthplace.Text = "";
            textBoxStudentCitizenship.Text = "";
            comboBoxFacultyCivilStatus.Text = "";
            textBoxStudentReligion.Text = "";

            textBoxStudentMobile.Text = "";
            textBoxStudentLandline.Text = "";
            textBoxStudentEmail.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox26.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            generateEnrollmentReport();
            generateSectionTable();
            generateCourseScheduleTable();
            generateRoomAssignments();
        }

        private void generateEnrollmentReport()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                String ns = row.Cells[1].Value.ToString();

                int migrated = 0;
                if (ns.Equals("") || ns.Equals("0"))
                {
                    String enrolled = row.Cells[2].Value.ToString();
                    if (!enrolled.Equals(""))
                    {
                        migrated = Convert.ToInt32(enrolled);
                        migrated = migrated * 9 / 10;
                    }
                }
                else
                {
                    migrated = Convert.ToInt32(ns);
                }

                row.Cells[3].Value = migrated;

                if (migrated > 10)
                    row.Cells[4].Value = (migrated / 40) + 1;
                else
                    row.Cells[4].Value = 1;

                int sections = Convert.ToInt32(row.Cells[4].Value.ToString());
                int afternoon = (int)(sections * 0.4 + 0.5);
                int evening = (int)(sections * 0.2 + 0.5);
                int morning = sections - afternoon - evening;

                row.Cells[5].Value = morning;
                row.Cells[6].Value = afternoon;
                row.Cells[7].Value = evening;
            }
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
            doc.Open();
            Paragraph paragraph = new Paragraph("This is a test paragraph for the PDF File! :)");
            doc.Add(paragraph);
            doc.Close();
        }

        private void generateSectionTable()
        {
            int counter = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int morning = Convert.ToInt32(row.Cells[5].Value);
                int afternoon = Convert.ToInt32(row.Cells[6].Value);
                int evening = Convert.ToInt32(row.Cells[7].Value);

                String program_code = "BSCS";
                int section_count = 0;
                for (int i = 0; i < morning; i++)
                {
                    section_count++;
                    String section_code = program_code + (counter + 1) + "0" + section_count;
                    this.sectionsTableAdapter.Insert(section_code, (counter / 2 + 1), program_code, (counter % 2) + 1, "morning");
                    MessageBox.Show(section_code);
                }

                for (int i = 0; i < afternoon; i++)
                {
                    section_count++;
                    String section_code = program_code + (counter + 1) + "0" + section_count;
                    MessageBox.Show(section_code);
                    this.sectionsTableAdapter.Insert(section_code, (counter / 2 + 1), program_code, (counter % 2) + 1, "afternoon");
                }

                for (int i = 0; i < evening; i++)
                {
                    section_count++;
                    String section_code = program_code + (counter + 1) + "0" + section_count;
                    MessageBox.Show(section_code);
                    this.sectionsTableAdapter.Insert(section_code, (counter / 2 + 1), "BSCS", (counter % 2) + 1, "evening");
                }

                counter++;
            }
        }

        private void generateCourseScheduleTable()
        {

        }

        private void generateRoomAssignments()
        {

        }
    }
}
