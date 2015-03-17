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
    public partial class FormSchedule : Form
    {
        String student_num;
        PreEnrollmentSystem.EnrollmentDataSetTableAdapters.EnrollmentTableAdapter eTA= new PreEnrollmentSystem.EnrollmentDataSetTableAdapters.EnrollmentTableAdapter();
        public FormSchedule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
                String course_code = dataGridView1[0, row].Value.ToString();

                eTA.Insert1(false,student_num);
                this.Dispose();
        }

        public void loadData(String courseName, String student_num)
        {
            this.student_num = student_num;
            this.courseScheduleViewTableAdapter.FillByCourseName(this.enrollmentDataSet.CourseScheduleView, courseName);
        }
    }
}
