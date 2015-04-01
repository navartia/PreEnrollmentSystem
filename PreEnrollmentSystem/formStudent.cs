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
    using StudentTable = EnrollmentDataSet.StudentsDataTable;
    using ScheduleTable = EnrollmentDataSet.StudentScheduleViewDataTable;

    public partial class FormStudent : Form
    {
        private StudentTable student_information;
        private ScheduleTable schedule;
        private EnrollmentDataSet.AnnouncementsDataTable announcements =  new EnrollmentDataSet.AnnouncementsDataTable();
        private String username, student_num;

        public FormStudent()
        {
            InitializeComponent();
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enrollmentDataSet.StudentScheduleView' table. You can move, or remove it, as needed.
            this.studentScheduleViewTableAdapter.Fill(this.enrollmentDataSet.StudentScheduleView);
            // TODO: This line of code loads data into the 'enrollmentDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.enrollmentDataSet.Students);
            panelHome.BringToFront();

            updateAnnouncements();

            username = Properties.Settings.Default.username;
            loadDatabaseToTable();
        }

        //GUI Related Methods
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

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panelSettings.BringToFront();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            panelStudentProfile.BringToFront();
        }

        //Internal Methods
        private void loadDatabaseToTable()
        {
            student_information = new StudentTable();
            this.studentsTableAdapter.FillByUsername(this.enrollmentDataSet.Students, username);

            labelName.Text = (String) this.studentsTableAdapter.GetName(username);
            labelProgramMajor.Text = (String)this.programsTableAdapter.GetCourseDescription((String) student_information.Rows[0]["student_program"]);

            schedule = new ScheduleTable();
            student_num = student_information[Convert.ToInt32(this.studentsTableAdapter.GetStudentID(username))]["student_num"].ToString();
            labelStudNum.Text = student_num;
            this.studentScheduleViewTableAdapter.FillByStudentNum(schedule, student_num);
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
            EnrollmentDataSet.AccountsDataTable account = this.accountsTableAdapter.GetDataByUsername(username);

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
            int counter = 1;
            for (int ctr = announcements.Rows.Count-3; ctr < announcements.Rows.Count ;ctr++)
            {
                if (counter == 1)
                {
                    announcementTitle1.Text = this.announcementsTableAdapter.GetAnnouncementTitle(ctr-counter);
                    announcementDetails1.Text = this.announcementsTableAdapter.GetAnnouncementDetails(ctr-counter);
                    counter++;
                }
                else if (counter == 2)
                {
                    announcementTitle2.Text = this.announcementsTableAdapter.GetAnnouncementTitle(ctr-counter);
                    announcementDetails2.Text = this.announcementsTableAdapter.GetAnnouncementDetails(ctr-counter);
                    counter++;
                }
                else if (counter == 3)
                {
                    announcementTitle3.Text = this.announcementsTableAdapter.GetAnnouncementTitle(ctr-counter);
                    announcementDetails3.Text = this.announcementsTableAdapter.GetAnnouncementDetails(ctr-counter);
                    counter = 1;
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
