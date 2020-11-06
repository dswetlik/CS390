﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS390
{
    public partial class AdminDashboard : Form
    {
        private Admin current_user;

        public AdminDashboard()
        {
            InitializeComponent();
            current_user = (Admin)LogInScreen.current_user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.Location = new Point(10, label1.Location.Y);
            var course_array = from row in RegistrationDatabase.GetCourses()
                               select new
                               {
                                   Id = row.Value.GetCourseID(),
                                   Name = row.Value.GetCourseName(),
                                   Faculty = row.Value.GetFaculty().GetUserName(),
                                   Credits = row.Value.GetCourseCredit(),
                                   Seats = row.Value.GetNumSeats(),
                                   Dates = String.Join(", ", row.Value.GetDayBlocks()),
                                   Times = String.Join(", ", row.Value.GetTimeBlocks())
                               };
            dataGridView1.DataSource = course_array.ToArray();
            foreach(User user in RegistrationDatabase.GetUserDatabase().Values)
            {
                if (user is Student)
                {
                    comboBox1.Items.Add(user.GetUserName());
                }
                if (user is Faculty)
                {
                    comboBox2.Items.Add(user.GetUserName());
                }
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Form1"].Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 3;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 1;
            button5.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.Maroon;
            button2.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Empty;
            button4.FlatAppearance.BorderColor = Color.Empty;
            button5.FlatAppearance.BorderColor = Color.Empty;
            dataGridView1.Visible = true;
            label1.Visible = true;
            button8.Visible = true;
            button6.Visible = false;
            comboBox1.Visible = false;
            button7.Visible = false;
            comboBox2.Visible = false;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 1;
            button5.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderColor = Color.Maroon;
            button1.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Empty;
            button4.FlatAppearance.BorderColor = Color.Empty;
            button5.FlatAppearance.BorderColor = Color.Empty;
            dataGridView1.Visible = false;
            label1.Visible = false;
            button8.Visible = false;
            button6.Visible = true;
            comboBox1.Visible = true;
            button7.Visible = true;
            comboBox2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 3;
            button4.FlatAppearance.BorderSize = 1;
            button5.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.Empty;
            button2.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Maroon;
            button4.FlatAppearance.BorderColor = Color.Empty;
            button5.FlatAppearance.BorderColor = Color.Empty;
            dataGridView1.Visible = false;
            label1.Visible = false;
            button8.Visible = false;
            button6.Visible = false;
            comboBox1.Visible = false;
            button7.Visible = false;
            comboBox2.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.Empty;
            button2.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Empty;
            button4.FlatAppearance.BorderColor = Color.Maroon;
            button5.FlatAppearance.BorderColor = Color.Empty;
            dataGridView1.Visible = false;
            label1.Visible = false;
            button8.Visible = false;
            button6.Visible = false;
            comboBox1.Visible = false;
            button7.Visible = false;
            comboBox2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.FlatAppearance.BorderSize = 3;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderSize = 1;
            button5.FlatAppearance.BorderColor = Color.Maroon;
            button2.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Empty;
            button4.FlatAppearance.BorderColor = Color.Empty;
            button1.FlatAppearance.BorderColor = Color.Empty;
            button8.Visible = false;
            button6.Visible = false;
            comboBox1.Visible = false;
            button7.Visible = false;
            comboBox2.Visible = false;
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                LogInScreen.current_user = RegistrationDatabase.GetUser(comboBox1.Text);
                StudentDashboard form2 = new StudentDashboard();
                form2.Show();
            } catch
            {
                Console.WriteLine("Oops");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                LogInScreen.current_user = RegistrationDatabase.GetUser(comboBox2.Text);
                ProfessorDashboard form2 = new ProfessorDashboard();
                form2.Show();
            }
            catch
            {
                Console.WriteLine("Oops");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d_row in dataGridView1.Rows)
            {
                object ischecked = d_row.Cells[0].Value;

                if (ischecked == null)
                {
                }
                else
                {
                    try
                    {
                        Console.WriteLine("Attempted to remove " + (string)d_row.Cells[1].Value);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Error in removing course");
                    }
                }
            }
            Form2_Load(sender, e);
        }
    }
}
