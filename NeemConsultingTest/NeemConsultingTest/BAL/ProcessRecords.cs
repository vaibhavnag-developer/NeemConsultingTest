using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeemConsultingTest.Models;
using NeemConsultingTest_DATA;
using NeemConsultingTest_DATA.Entites;

namespace NeemConsultingTest.BAL
{
    public class ProcessRecords
    {
        public string InsertRecordInStudentTable(StudentModel studentModel)
        {
            string message = string.Empty;
            using (MyDatabaseEntities1 myDatabase = new MyDatabaseEntities1())
            {
                var temp = (from temp1 in myDatabase.students
                            where temp1.Email == studentModel.Email
                            select temp1).FirstOrDefault();
                if (temp == null)
                {

                    student sm = new student();
                    sm.FirstName = studentModel.FirstName;
                    sm.LastName = studentModel.LastName;
                    sm.Gender = studentModel.Gender;
                    sm.City = studentModel.City;
                    sm.Email = studentModel.Email;
                    myDatabase.students.Add(sm);
                    myDatabase.SaveChanges();
                    
                }
                else
                {
                    message = "Email address already exixts";
                }
            }
            return message;
        }
        public StudentModel FetchRecordId(int id)
        {
            StudentModel sm = new StudentModel();
            try
            {
                using (MyDatabaseEntities1 myDatabase= new MyDatabaseEntities1())
                {
                    student student = new student();
                    var temp1 = (from temp in myDatabase.students
                                 where temp.id == id
                                 select temp).FirstOrDefault();
                    if (temp1!=null)
                    {
                        sm.FirstName = temp1.FirstName;
                        sm.LastName = temp1.LastName;
                        sm.Gender = temp1.Gender;
                        sm.City = temp1.City;
                        sm.Email = temp1.Email;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return sm;
        }
        public void updateRecord(StudentModel model)
        {
            try
            {
                using (MyDatabaseEntities1 myDatabase=new MyDatabaseEntities1())
                {
                    var temp = (from temp1 in myDatabase.students
                                where temp1.Email == model.Email
                                select temp1).FirstOrDefault();
                    if (temp != null)
                    {
                        temp.FirstName = model.FirstName;
                        temp.LastName = model.LastName;
                        temp.Gender = model.Gender;
                        temp.City = model.City;
                        myDatabase.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<StudentModel> FetchRecord()
        {
            List<StudentModel> students = new List<StudentModel>();
            try
            {
                using (MyDatabaseEntities1 myDatabase= new MyDatabaseEntities1())
                {
                    List<student> sm = new List<student>();
                    sm = (from temp in myDatabase.students
                          select temp).ToList();
                          
                    foreach (var item in sm)
                    {
                        StudentModel studentModels = new StudentModel();
                        studentModels.PersonId = item.id;
                        studentModels.FirstName = item.FirstName;
                        studentModels.LastName = item.LastName;
                        studentModels.Gender = item.Gender;
                        studentModels.City = item.City;
                        studentModels.Email = item.Email;
                        students.Add(studentModels);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return students;
        }
        public void DeleteRecord(int id)
        {
            try
            {
                using (MyDatabaseEntities1 myDatabase= new MyDatabaseEntities1())
                {
                    var fetchRecord = (from temp in myDatabase.students
                                       where temp.id == id 
                                       select temp).FirstOrDefault();
                    myDatabase.students.Remove(fetchRecord);
                    myDatabase.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}