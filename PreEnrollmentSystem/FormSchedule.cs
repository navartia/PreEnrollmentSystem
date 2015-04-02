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
    using CourseScheduleViewTable = EnrollmentDataSet.CourseScheduleViewDataTable;
    public partial class FormSchedule : Form
    {
        private CourseScheduleViewTable courseSchedView;
        private int student_id, schedule_id;
        private String courseName, studentNum;

        public FormSchedule()
        {
            InitializeComponent();
        }
        private void FormSchedule_Load(object sender, EventArgs e)
        {
            courseName = Properties.Settings.Default.courseName;
            studentNum = Properties.Settings.Default.studentNum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
            Properties.Settings.Default.scheduleID =Convert.ToInt32(dataGridView1[0, row]);
            Properties.Settings.Default.studentID = (int)this.enrollmentTableAdapter.GetStudentID(studentNum);

            schedule_id = Properties.Settings.Default.scheduleID;
            student_id = Properties.Settings.Default.studentID;

            this.enrollmentTableAdapter.Insert(student_id, schedule_id, false);
            this.Dispose();
        }

        public void viewData()
        {
            courseSchedView = new CourseScheduleViewTable();
            this.courseScheduleViewTableAdapter.FillByCourseName(courseSchedView, courseName);
        }
    }
}