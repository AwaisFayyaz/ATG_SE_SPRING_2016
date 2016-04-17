using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ATG_SE_Project2016.MODEL
{
    class Course_M
    {
        string CourseName;
        string Department;
        int Batch_ID;
        DbConnection DB = new DbConnection();
        public Course_M()
        {
            this.Batch_ID = 0;
            this.Department = "";
            this.CourseName = "";
        }
         public Course_M(int batch,string depart,string course)
        {
            this.setBatch(batch);
            this.setDepart(depart);
            this.setCourse(course);
        }
         public void setBatch(int batch)
         {
             this.Batch_ID = batch;
         }
         public void setDepart(string depart)
         {
             this.Department = depart;
         }
         public void setCourse(string course)
         {
             this.CourseName = course;
         }
         public int getBatch()
         {
             return this.Batch_ID;
         }
         public string getDepart()
         {
             return this.Department;
         }
         public string getCourse()
         {
             return this.CourseName;
         }
         public DataSet getTable()
         {
             DataSet ds = new DataSet();
             string query = "SELECT Course_Name,Batch_ID,Department from course";
             ds = DB.select(query);
             return ds;
         }
         public bool IsExist()
         {
             DataSet ds = new DataSet();
             string query = "SELECT Course_Name,Batch_ID,Department from course where Course_Name='" + this.CourseName + "' and Batch_ID='" + this.Batch_ID + "' and Department='" + this.Department + "'";
             ds = DB.select(query);
             if (ds.Tables[0].Rows.Count == 0)
             {
                 return false;
             }
             else
             {
                 return true;
             }
         }
         public void AddCourse()
         {
             string query = "INSERT INTO course VALUES(NULL, '" + this.CourseName + "','" + this.Batch_ID + "','" + this.Department+ "')";
             DB.insert(query);
         }
    }
}
