using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using System.Windows.Forms;
using ATG_SE_Project2016.CONTROLLER;

namespace ATG_SE_Project2016.VIEW
{
    public partial class Inputs : MetroFramework.Forms.MetroForm
    {
        Batch_C batch = new Batch_C();
        Section_C section = new Section_C();
        Course_C course = new Course_C();
        DataSet DS_batch = new DataSet();
        DataSet DS_Section = new DataSet();
        DataSet DS_Course = new DataSet();
        public Inputs()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.fillingBatch();
            this.fillingSection();
            this.fillingCourse();
           
        }

        private void Inputs_Load(object sender, EventArgs e)
        {

        }

       private void fillingCourse()
        {
            DS_batch = batch.getTable();
            DS_Course = course.getTable();
            grid_Course.Rows.Clear();
            combo_CourseBatchDepart.Items.Clear();
            combo_Course.Items.Clear();
            foreach (DataRow r in DS_batch.Tables[0].Rows)
            {
                combo_CourseBatchDepart.Items.Add(r["Batch_ID"].ToString() + "-" + r["Department"].ToString());
            }
            foreach (DataRow r in DS_Course.Tables[0].Rows)
            {
                grid_Course.Rows.Add(r["batch_ID"],r["Department"],r["Course_Name"]);
            }
            combo_CourseBatchDepart.SelectedIndex = 0;
        }
        private void fillingSection()
        {
            DS_batch = batch.getTable();
            grid_Section.Rows.Clear();
            DS_Section = section.getTable();
            combo_DeleteSection.Items.Clear();
            combo_SelectStrength.Items.Clear();
            combo_SelectBatch.Items.Clear();
            combo_SelectSection.Items.Clear();
            foreach (DataRow r in DS_Section.Tables[0].Rows)
            {
                combo_DeleteSection.Items.Add(r["Batch_ID"].ToString() + "-" + r["Section_ID"].ToString() + "-" + r["Department"].ToString());
                grid_Section.Rows.Add(r["Batch_ID"], r["Department"], r["Section_ID"],r["Strength"]);
            }
            foreach (DataRow r in DS_batch.Tables[0].Rows)
            {
                combo_SelectBatch.Items.Add(r["Batch_ID"].ToString() + "-" + r["Department"].ToString());
            }
            for (int i = 0; i < 5;i++ )
            {
                combo_SelectSection.Items.Add(Convert.ToChar(65+i));
            }
            for (int i = 0; i <= 25;i++ )
            {
                combo_SelectStrength.Items.Add(35 + i + "");
            }
                combo_DeleteSection.SelectedIndex = 0;
                combo_SelectStrength.SelectedIndex = 0;
                combo_SelectSection.SelectedIndex = 0;
                combo_SelectBatch.SelectedIndex = 0;

            
        }
        private void fillingBatch()
        {
            DateTime dt = DateTime.Now;
            grid_Batch.Rows.Clear();
            DS_batch = batch.getTable();
            combo_DeleteBatch.Items.Clear();
            combo_addBatch.Items.Clear();
            combo_addDepartment.Items.Clear();
            foreach (DataRow r in DS_batch.Tables[0].Rows)
            {
                combo_DeleteBatch.Items.Add(r["Batch_ID"].ToString() + "-" + r["Department"].ToString());
                grid_Batch.Rows.Add(r["Batch_ID"], r["Department"]);
            }

           
            combo_DeleteBatch.SelectedIndex = 0;
          
            for (int i=0;i<7;i++)
            {
                combo_addBatch.Items.Add(dt.Year - i);
            }
            combo_addBatch.SelectedIndex = 0;
            combo_addDepartment.Items.Add("CS");
            combo_addDepartment.Items.Add("EE");
            combo_addDepartment.Items.Add("BBA");
            combo_addDepartment.SelectedIndex = 0;
        }

        private void Btn_AddBatch_Click(object sender, EventArgs e)
        {
            batch.setBatch(Convert.ToInt32(combo_addBatch.SelectedItem.ToString()));
            batch.setDepart(combo_addDepartment.SelectedItem.ToString());
            if(batch.isExist())
            {
                MetroMessageBox.Show(this, "Following Batch is already store.", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                batch.insertBatch();
                fillingBatch();
            }
        }

        private void Btn_DeleteBatch_Click(object sender, EventArgs e)
        {
            batch.DeleteBatch(combo_DeleteBatch.SelectedItem.ToString());
            this.fillingBatch();
        }

        private void btn_DeleteSection_Click(object sender, EventArgs e)
        {
            section.DeleteSection(combo_DeleteSection.SelectedItem.ToString());
            this.fillingSection();
        }

        private void btn_AddSection_Click(object sender, EventArgs e)
        {
            section.setStrength(Convert.ToInt32(combo_SelectStrength.SelectedItem.ToString()));
            section.setSection(Convert.ToChar(combo_SelectSection.SelectedItem.ToString()));
            string temp = combo_SelectBatch.SelectedItem.ToString();
            string batchTemp="",departTemp="";
            for(int i=0;i<temp.Length;i++)
            {
                if(i<4)
                {
                    batchTemp = batchTemp + temp[i];
                }
                else if(i>4)
                {
                    departTemp = departTemp + temp[i];
                }
            }
            section.setBatch(Convert.ToInt32(batchTemp));
            section.setDepart(departTemp);
            if(section.isExist())
            {
                MetroMessageBox.Show(this, "Following Section is already store.", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                section.AddSection();
                fillingSection();
            }
        }

        private void btn_AddCourse_Click(object sender, EventArgs e)
        {
           // course.setCourse(txt_Course.Text);
            string temp = combo_CourseBatchDepart.SelectedItem.ToString();
            string batchTemp = "", departTemp = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (i < 4)
                {
                    batchTemp = batchTemp + temp[i];
                }
                else if (i > 4)
                {
                    departTemp = departTemp + temp[i];
                }
            }
            course.setBatch(Convert.ToInt32(batchTemp));
            course.setDepart(departTemp);
            if(course.IsExist())
            {
                MetroMessageBox.Show(this, "Following Course is already store.", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                course.AddCourse();
                fillingCourse();
            }
        }

      
        

     
    }
}
