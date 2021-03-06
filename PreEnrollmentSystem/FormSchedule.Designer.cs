﻿namespace PreEnrollmentSystem
{
    partial class FormSchedule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.course_sched_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coursedescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectioncodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coursedayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coursetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseScheduleViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.enrollmentDataSet = new PreEnrollmentSystem.EnrollmentDataSet();
            this.courseScheduleViewTableAdapter = new PreEnrollmentSystem.EnrollmentDataSetTableAdapters.CourseScheduleViewTableAdapter();
            this.tableAdapterManager = new PreEnrollmentSystem.EnrollmentDataSetTableAdapters.TableAdapterManager();
            this.student_ScheduleTableAdapter = new PreEnrollmentSystem.EnrollmentDataSetTableAdapters.Student_ScheduleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseScheduleViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enrollmentDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(398, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Schedule";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.course_sched_id,
            this.coursedescriptionDataGridViewTextBoxColumn,
            this.sectioncodeDataGridViewTextBoxColumn,
            this.coursedayDataGridViewTextBoxColumn,
            this.coursetimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.courseScheduleViewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(860, 227);
            this.dataGridView1.TabIndex = 0;
            // 
            // course_sched_id
            // 
            this.course_sched_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.course_sched_id.DataPropertyName = "course_sched_id";
            this.course_sched_id.HeaderText = "Schedule ID";
            this.course_sched_id.Name = "course_sched_id";
            this.course_sched_id.Width = 91;
            // 
            // coursedescriptionDataGridViewTextBoxColumn
            // 
            this.coursedescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coursedescriptionDataGridViewTextBoxColumn.DataPropertyName = "course_description";
            this.coursedescriptionDataGridViewTextBoxColumn.HeaderText = "Course Name";
            this.coursedescriptionDataGridViewTextBoxColumn.Name = "coursedescriptionDataGridViewTextBoxColumn";
            // 
            // sectioncodeDataGridViewTextBoxColumn
            // 
            this.sectioncodeDataGridViewTextBoxColumn.DataPropertyName = "section_code";
            this.sectioncodeDataGridViewTextBoxColumn.HeaderText = "Section";
            this.sectioncodeDataGridViewTextBoxColumn.Name = "sectioncodeDataGridViewTextBoxColumn";
            // 
            // coursedayDataGridViewTextBoxColumn
            // 
            this.coursedayDataGridViewTextBoxColumn.DataPropertyName = "course_day";
            this.coursedayDataGridViewTextBoxColumn.HeaderText = "Day";
            this.coursedayDataGridViewTextBoxColumn.Name = "coursedayDataGridViewTextBoxColumn";
            // 
            // coursetimeDataGridViewTextBoxColumn
            // 
            this.coursetimeDataGridViewTextBoxColumn.DataPropertyName = "course_time";
            this.coursetimeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.coursetimeDataGridViewTextBoxColumn.Name = "coursetimeDataGridViewTextBoxColumn";
            // 
            // courseScheduleViewBindingSource
            // 
            this.courseScheduleViewBindingSource.DataMember = "CourseScheduleView";
            this.courseScheduleViewBindingSource.DataSource = this.enrollmentDataSet;
            // 
            // enrollmentDataSet
            // 
            this.enrollmentDataSet.DataSetName = "EnrollmentDataSet";
            this.enrollmentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // courseScheduleViewTableAdapter
            // 
            this.courseScheduleViewTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AccountsTableAdapter = null;
            this.tableAdapterManager.AnnouncementsTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.Course_ScheduleTableAdapter = null;
            this.tableAdapterManager.CoursesTableAdapter = null;
            this.tableAdapterManager.Enrollment_ReportTableAdapter = null;
            this.tableAdapterManager.FacultyTableAdapter = null;
            this.tableAdapterManager.ProgramsTableAdapter = null;
            this.tableAdapterManager.RoomsTableAdapter = null;
            this.tableAdapterManager.SectionsTableAdapter = null;
            this.tableAdapterManager.Student_ScheduleTableAdapter = null;
            this.tableAdapterManager.StudentsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = PreEnrollmentSystem.EnrollmentDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // student_ScheduleTableAdapter
            // 
            this.student_ScheduleTableAdapter.ClearBeforeFill = true;
            // 
            // FormSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSchedule";
            this.Text = "Add Schedule";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseScheduleViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enrollmentDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private EnrollmentDataSet enrollmentDataSet;
        private EnrollmentDataSetTableAdapters.CourseScheduleViewTableAdapter courseScheduleViewTableAdapter;
        private EnrollmentDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource courseScheduleViewBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn course_sched_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn coursedescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectioncodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coursedayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coursetimeDataGridViewTextBoxColumn;
        private EnrollmentDataSetTableAdapters.Student_ScheduleTableAdapter student_ScheduleTableAdapter;
    }
}