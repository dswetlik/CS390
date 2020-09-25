﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS390
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
            Console.Write(LogInScreen.current_user);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label1.Location = new Point(10, label1.Location.Y);
            label2.Location = new Point(10, label2.Location.Y);
            var course_array = from row in RegistrationDatabase.GetCourses() select new { Id = row.Value.GetCourseID(), 
                Name = row.Value.GetCourseName(), Faculty = row.Value.faculty.GetUserName(), Credits = row.Value.GetCourseCredit(), 
                Seats = row.Value.GetNumSeats(), Dates = String.Join(", ", row.Value.GetDayBlocks()), Times = String.Join(", ", row.Value.GetTimeBlocks())
            };
            dataGridView1.DataSource = course_array.ToArray();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Form1"].Close();
        }
    }
}
