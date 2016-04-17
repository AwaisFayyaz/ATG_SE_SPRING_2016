using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using ATG_SE_Project2016.CONTROLLER;
using ATG_SE_Project2016.VIEW;

namespace ATG_SE_Project2016
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private CreateConnection conn = new CreateConnection();
        private Inputs start = new Inputs();
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {

            if (conn.OpenConnection())
            {

                DialogResult r = MetroMessageBox.Show(this, "\n\nRemember: ATG Deals with the only Regular Students of your institute. Main purpose of ATG is to provide the efficeint timetable of the core students of an institute.\n\n Are you ready to proceed using ATG??", "Automated TimeTable Generator is Ready to Work.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                    start.ShowDialog();
                    this.Close();
                    conn.CloseConnection();
                }

                //close the connection
                else
                {
                    conn.CloseConnection();
                }
             
            }
            else
            {
                MetroMessageBox.Show(this, "Please Try Again Latter. We are sorry for disturbance.", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Question);
                conn.CloseConnection();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

    }
}
