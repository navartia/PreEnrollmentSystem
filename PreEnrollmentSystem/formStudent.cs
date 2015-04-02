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
            int ctr = Convert.ToInt32(this.announcementsTableAdapter.Count());
            MessageBox.Show(ctr.ToString());

            int b = 1;
            for (int a = ctr; a > ctr-3; a--)
            {
                if (b == 1)
                {
                    announcementTitle1.Text = (String)this.announcementsTableAdapter.GetAnnouncementTitle(ctr);
                    announcementDetails1.Text = (String)this.announcementsTableAdapter.GetAnnouncementDetails(ctr); 
                    MessageBox.Show(a.ToString());
                    MessageBox.Show(announcementTitle1.Text+announcementDetails1.Text);
                    b++;
                }
                if (b == 2)
                {
                    announcementTitle2.Text = (String)this.announcementsTableAdapter.GetAnnouncementTitle(ctr);
                    announcementDetails2.Text = (String)this.announcementsTableAdapter.GetAnnouncementDetails(ctr);
                    MessageBox.Show(a.ToString());
                    MessageBox.Show(announcementTitle2.Text + announcementDetails2.Text);
                    b++;
                }
                if (b == 3)
                {
                    announcementTitle3.Text = this.announcementsTableAdapter.GetAnnouncementTitle(ctr);
                    announcementDetails3.Text = this.announcementsTableAdapter.GetAnnouncementDetails(ctr);
                    MessageBox.Show(a.ToString());
                    MessageBox.Show(announcementTitle3.Text + announcementDetails3.Text);
                    break;
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
