using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATG_SE_Project2016.MODEL;

namespace ATG_SE_Project2016.CONTROLLER
{
    class Section_C
    {
        char Section_ID;
        int Batch_ID;
        int Strength;
        string Department;
        Section_M section = new Section_M();
         public Section_C()
        {
            this.Batch_ID = 0;
            this.Department = "";
            this.Section_ID = ' ';
        }
         public Section_C(int batch, string depart,char section)
        {
            this.setBatch(batch);
            this.setDepart(depart);
        }
        public void setBatch(int batch)
        {
            this.Batch_ID = batch;
        }
        public void setDepart(string depart)
        {
            this.Department = depart;
        }
        public void setSection(char section)
        {
            this.Section_ID=section;
        }
        public void setStrength(int st)
        {
            this.Strength = st;
        }
        public int getBatch()
        {
            return this.Batch_ID;
        }
        public string getDepart()
        {
            return this.Department;
        }
        public char getSection()
        {
            return this.Section_ID;
        }
        public int getStrength()
        {
            return this.Strength;
        }
        public DataSet getTable()
        {
            return section.getTable();
        }
        public void DeleteSection(string str)
        {

            string batch = "";
            string depart = "";
            char section = ' ';
            if (str.Length > 4)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (i < 4)
                    {
                        batch = batch + str[i];
                    }
                    else if (i == 5)
                    {
                        section = str[i];
                    }
                    else if(i>6)
                    {
                        depart = depart + str[i];
                    }
                }
                int batch1 = Convert.ToInt32(batch);
                this.section.setBatch(batch1);
                this.section.setDepart(depart);
                this.section.setSection(section);
                MessageBox.Show("Batch=" + batch1 + "  Depart=" + depart+ "Section="+section);
                this.section.DeleteSection();
            }
        }
        public bool isExist()
        {
            section.setBatch(this.getBatch());
            section.setDepart(this.getDepart());
            section.setStrength(this.getStrength());
            section.setSection(this.getSection());
            return section.isExist();
        }
        public void AddSection()
        {
            section.setBatch(this.getBatch());
            section.setDepart(this.getDepart());
            section.setStrength(this.getStrength());
            section.setSection(this.getSection());
            section.AddSection();
        }
    }
}
