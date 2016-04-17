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
    class Batch_C
    {
        int Batch_ID;
        string Department;
        Batch_M batch = new Batch_M();
       
        public Batch_C()
        {
            this.Batch_ID = 0;
            this.Department = "";
        }
        public Batch_C(int batch,string depart)
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
        public int getBatch()
        {
            return this.Batch_ID;
        }
        public string getDepart()
        {
            return this.Department;
        }
        public DataSet getTable()
        {   
            return batch.getTable();
        }
        public void DeleteBatch(string str)
        {
            string batch="";
            string depart="";
            if(str.Length>4)
            {
                for(int i=0;i<str.Length;i++)
                {
                    if(i<4)
                    {
                        batch = batch + str[i];
                    }
                    else if(i>4)
                    {
                        depart = depart + str[i];
                    }
                }
                int batch1 = Convert.ToInt32(batch);
                this.batch.setBatch(batch1);
                this.batch.setDepart(depart);
                MessageBox.Show("Batch=" + batch1 + "  Depart=" + depart);
                this.batch.DeleteBatch();
            }

        }

        public bool isExist()
        {
            batch.setBatch(this.Batch_ID);
            batch.setDepart(this.Department);
            return batch.isExist();
        }
        public void insertBatch()
        {
            batch.insertBatch();
        }
    }
}
