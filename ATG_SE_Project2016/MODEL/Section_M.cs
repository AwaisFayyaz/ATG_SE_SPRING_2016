using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace ATG_SE_Project2016.MODEL
{
    class Section_M
    {
        char Section_ID;
        int Batch_ID;
        int Strength;
        string Department;
        DbConnection DB = new DbConnection();
         public Section_M()
        {
            this.Batch_ID = 0;
            this.Department = "";
            this.Section_ID = ' ';
        }
         public Section_M(int batch, string depart,char section)
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
            DataSet ds = new DataSet();
            string query = "SELECT Section_ID,Batch_ID,Department,Strength from section";
            ds = DB.select(query);
            return ds;
        }
        public void DeleteSection()
        {
            string query = "Delete from section where Section_ID='"+this.Section_ID+"' and Batch_ID='" + this.Batch_ID + "' and Department='" + this.Department + "'";
            DB.delete(query);
        }
        public bool isExist()
        {
            DataSet ds = new DataSet();
            string query = "SELECT Section_ID,Batch_ID,Department from section where Section_ID='" + this.Section_ID + "' and Batch_ID='" + this.Batch_ID + "' and Department='" + this.Department + "'";
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
        public void AddSection()
        {
            string query = "INSERT INTO section VALUES(NULL, '" + this.Section_ID + "','" + this.Batch_ID + "','"+this.Strength+"','"+this.Department+"')";
            DB.insert(query);
        }
    }
}
