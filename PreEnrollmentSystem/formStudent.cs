using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreEnrollmentSystem
{
    public partial class FormStudent : Form
    {
        EnrollmentDataSet.StudentsDataTable student_information;
        private String student_num, a_header1, a_header2, a_header3, a_details1, a_details2, a_details3;
        static FormStudent frms = new FormStudent();
        PreEnrollmentSystem.EnrollmentDataSetTableAdapters.StudentScheduleViewTableAdapter ssView = new PreEnrollmentSystem.EnrollmentDataSetTableAdapters.StudentScheduleViewTableAdapter();

        public FormStudent()
        {
            InitializeComponent();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            panelSchedule.BringToFront();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelHome.BringToFront();
        }

        private void buttonGrades_Click(object sender, EventArgs e)
        {
            panelGrades.BringToFront();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panelSettings.BringToFront();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            panelStudentProfile.BringToFront();
        }

        private void formStudent_Load(object sender, EventArgs e)
        {
            comboBox1.Text=("2013-2014");
            comboBox1.Items.Add("2013-2014");
            comboBox1.Items.Add("2014-2015");
            comboBox1.Items.Add("2015-2016");
            comboBox2.Text = ("1st Term");
            comboBox2.Items.Add("1st Term");
            comboBox2.Items.Add("2nd Term");
        }

        public void loadData(String username)
        {
            student_information = this.studentsTableAdapter.GetDataBy(username);
            this.studentsTableAdapter.FillBy(this.enrollmentDataSet.Students, username);

            labelName.Text = (String) this.studentsTableAdapter.GetName(username);
            labelProgramMajor.Text = (String)this.programsTableAdapter.GetCourseDescription((String) student_information.Rows[0]["student_program"]);
        
            // TODO: This line of code loads data into the 'enrollmentDataSet.StudentScheduleView' table. You can move, or remove it, as needed.
            student_num = student_information[0]["student_num"].ToString();
            ssView.FillByStudentNum(this.enrollmentDataSet.StudentScheduleView, student_num);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelSettings.BringToFront();
        }

        private void createScheduleTable()
        {
            //DataTable 
        }

        private void buttonUpdatePassword_Click(object sender, EventArgs e)
        {
            String oldPass = maskedTextBoxOldPass.Text;
            String newPass1 = maskedTextBoxNewPass1.Text;
            String newPass2 = maskedTextBoxNewPass2.Text;

            String username = (String)student_information.Rows[0]["username"];
            EnrollmentDataSet.AccountsDataTable account = this.accountsTableAdapter.GetDataBy(username);

            if (oldPass.Equals((String)account.Rows[0]["password"]))
            {
                if (newPass1.Equals(newPass2))
                {
                    if (newPass1.Equals(oldPass))
                    {
                        MessageBox.Show("This password is already in use.");
                    }
                    else 
                    {
                        this.accountsTableAdapter.UpdatePassword(newPass1, username);
                        MessageBox.Show("Password updated successfully.");
                    }
                }
                else
                {
                    MessageBox.Show("The new passwords are the not the same.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect old password");
            }
        }

        private void updateAnnouncements()
        {
            this.announcementsTableAdapter.GetData();

            announcementTitle1.Text = a_header1;
            announcementTitle2.Text = a_header2;
            announcementTitle3.Text = a_header3;

            announcementDetails1.Text = a_details1;
            announcementDetails2.Text = a_details2;
            announcementDetails3.Text = a_details3;
        }

        private void buttonSearchSched_Click(object sender, EventArgs e)
        {
            FormSchedule fs = new FormSchedule();
            fs.loadData(textBoxSearchSched.Text, student_num);
            fs.ShowDialog();

            ssView.FillByStudentNum(this.enrollmentDataSet.StudentScheduleView, student_num);
        }
    }
}
