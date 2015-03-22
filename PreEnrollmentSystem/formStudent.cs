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
        EnrollmentDataSet.AnnouncementsDataTable announcements;
        private String student_num;
        static FormStudent frms = new FormStudent();

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
            panelHome.BringToFront();

            updateAnnouncements();
        }

        public void loadData(String username)
        {
            student_information = this.studentsTableAdapter.GetDataBy(username);
            this.studentsTableAdapter.FillBy(this.enrollmentDataSet.Students, username);

            labelName.Text = (String) this.studentsTableAdapter.GetName(username);
            labelProgramMajor.Text = (String)this.programsTableAdapter.GetCourseDescription((String) student_information.Rows[0]["student_program"]);
        
            // TODO: This line of code loads data into the 'enrollmentDataSet.StudentScheduleView' table. You can move, or remove it, as needed.
            student_num = student_information[0]["student_num"].ToString();
            this.studentScheduleViewTableAdapter.FillByStudentNum(this.enrollmentDataSet.StudentScheduleView, student_num);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelSettings.BringToFront();
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
            FormRegistrar fr = new FormRegistrar();
            int ctr = 0;
            for(int b = announcements.Rows.Count; b < announcements.Rows.Count-3; b--)
            {
                if (b == 1)
                {
                    announcementTitle1.Text = announcements[b-2]["announcements_title"].ToString();
                    announcementDetails1.Text = announcements[b-2]["announcement_details"].ToString();
                    ctr++;
                }
                if (b == 2)
                {
                    announcementTitle2.Text = announcements[b-1]["announcements_title"].ToString();
                    announcementDetails2.Text = announcements[b-1]["announcement_details"].ToString();
                }
                if (b == 3)
                {
                    announcementTitle3.Text = announcements[b]["announcements_title"].ToString();
                    announcementDetails3.Text = announcements[b]["announcement_details"].ToString();
                }
            }
        }

        private void buttonSearchSched_Click(object sender, EventArgs e)
        {
            FormSchedule fs = new FormSchedule();
            fs.loadData(textBoxSearchSched.Text, student_num);
            fs.ShowDialog();

            this.studentScheduleViewTableAdapter.FillByStudentNum(this.enrollmentDataSet.StudentScheduleView, student_num);
        }
    }
}
