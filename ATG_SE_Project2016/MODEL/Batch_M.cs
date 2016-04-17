using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace ATG_SE_Project2016.MODEL
{
    class Batch_M
    {
        int Batch_ID;
        string Department;
        DbConnection DB = new DbConnection();
        public Batch_M()
        {
            this.Batch_ID = 0;
            this.Department = "";
        }
        public Batch_M(int batch,string depart)
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
            DataSet ds = new DataSet();
            string query = "SELECT Batch_ID,Department from batch";
            ds =DB.select(query);
            return ds;
        }
        public void DeleteBatch()
        {
            string query = "Delete from batch where Batch_ID='"+this.Batch_ID+"' and Department='"+this.Department+"'";
            DB.delete(query);
        }

        public bool isExist()
        {
            DataSet ds = new DataSet();
            string query = "SELECT Batch_ID,Department from batch where Batch_ID='" + this.Batch_ID + "' and Department='" + this.Department + "'";
            ds = DB.select(query);
            if(ds.Tables[0].Rows.Count==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        
        }

        public void insertBatch()
        {
            string query = "INSERT INTO batch VALUES(NULL, '"+this.Batch_ID+"','"+this.Department+"')";
            DB.insert(query);
        }
    }
}
