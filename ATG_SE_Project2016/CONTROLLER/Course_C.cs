using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ATG_SE_Project2016.MODEL;

namespace ATG_SE_Project2016.CONTROLLER
{
    class Course_C
    {
         string CourseName;
        string Department;
        int Batch_ID;
        Course_M course = new Course_M();
        public Course_C()
        {
            this.Batch_ID = 0;
            this.Department = "";
            this.CourseName = "";
        }
         public Course_C(int batch,string depart,string course)
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
             return course.getTable();
         }
        public bool IsExist()
        {
            course.setBatch(this.getBatch());
            course.setCourse(this.getCourse());
            course.setDepart(this.getDepart());
            return course.IsExist();
        }
        public void AddCourse()
        {
            course.setBatch(this.getBatch());
            course.setCourse(this.getCourse());
            course.setDepart(this.getDepart());
            course.AddCourse();
        }
    }
}
