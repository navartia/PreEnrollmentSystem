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
    public partial class FormFaculty : Form
    {
        EnrollmentDataSet.FacultyDataTable faculty_information;

        public FormFaculty()
        {
            InitializeComponent();
        }

        private void buttonScheduleList_Click(object sender, EventArgs e)
        {
            panelScheduleList.BringToFront();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelHome.BringToFront();
        }

        private void buttonViewClassList_Click(object sender, EventArgs e)
        {
            panelClassListView.BringToFront();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panelSettings.BringToFront();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonFacultyProfile_Click(object sender, EventArgs e)
        {
            panelFacultyProfile.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox26.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonUpdatePassword_Click(object sender, EventArgs e)
        {
            String oldPass = maskedTextBoxOldPass.Text;
            String newPass1 = maskedTextBoxNewPass1.Text;
            String newPass2 = maskedTextBoxNewPass2.Text;

            String username = (String)faculty_information.Rows[0]["username"];
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
    }
}
