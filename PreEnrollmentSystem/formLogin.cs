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
    using AccountTable = EnrollmentDataSet.AccountsDataTable;
    public partial class FormLogin : Form
    {
        private AccountTable account;

        private Image[] toDisplay;
        private int i = 0;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            toDisplay = new Image[6];

            toDisplay[0] = PreEnrollmentSystem.Properties.Resources.STI_1;
            toDisplay[1] = PreEnrollmentSystem.Properties.Resources.STI_2;
            toDisplay[2] = PreEnrollmentSystem.Properties.Resources.STI_3;
            toDisplay[3] = PreEnrollmentSystem.Properties.Resources.STI_4;
            toDisplay[4] = PreEnrollmentSystem.Properties.Resources.STI_5;
            toDisplay[5] = PreEnrollmentSystem.Properties.Resources.STI_6;

            pictureBox2.Image = toDisplay[0];
            timer1.Enabled = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String inputUsername = textBoxUsername.Text;
            String inputPassword = textBoxPassword.Text;

            account = new AccountTable();
            this.accountsTableAdapter.FillByUsername(account, inputUsername);

            if (account.Rows.Count > 0)
            {
                if (inputPassword.Equals(account.Rows[0]["password"]))
                {
                    String queryAccountType = (String)account.Rows[0]["account_type"];
                    Properties.Settings.Default.username = inputUsername;
                    Properties.Settings.Default.password = inputPassword;
                    Properties.Settings.Default.Save();
                    this.Hide();

                    switch (queryAccountType)
                    {
                        case "student":
                            FormStudent fs = new FormStudent();
                            fs.ShowDialog();
                            break;
                        case "administrator":
                            FormAdmin fa = new FormAdmin();
                            fa.loadData(inputUsername);
                            fa.ShowDialog();
                            break;
                        case "registrar":
                            FormRegistrar fr = new FormRegistrar();
                            //fr.loadData(inputUsername);
                            fr.ShowDialog();
                            break;
                        case "faculty":
                            FormFaculty ff = new FormFaculty();
                            //ff.loadData(inputUsername);
                            ff.ShowDialog();
                            break;
                    }

                    this.Show();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Closing..", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            if (i == 6)
            {
                i = 0;
            }

            pictureBox2.Image = toDisplay[i];
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (i == 0)
            {
                i = 6;
            }
            i--;

            pictureBox2.Image = toDisplay[i];

            timer1.Enabled = true;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            i++;

            if (i > 5)
            {
                i = 0;
            }

            pictureBox2.Image = toDisplay[i];

            timer1.Enabled = true;
        }
    }
}
