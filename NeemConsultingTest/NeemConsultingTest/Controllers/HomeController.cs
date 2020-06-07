using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeemConsultingTest.Models;
using NeemConsultingTest_DATA;
using NeemConsultingTest_DATA.Entites;
using NeemConsultingTest.BAL;
namespace NeemConsultingTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {   

            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        public ActionResult About()
        {

            List<StudentModel> sm = new List<StudentModel>();
            try
            {
                ProcessRecords processRecords = new ProcessRecords();
                sm = processRecords.FetchRecord();
            }
            catch (Exception)
            {

                throw;
            }

            return View(sm);
        }
        public ActionResult Edit(int id=0)
        {
            StudentModel sm = new StudentModel();
            try
            {
                ProcessRecords processRecords = new ProcessRecords();
                sm=processRecords.FetchRecordId(id);

            }
            catch (Exception)
            {

                throw;
            }
            return View(sm);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("About");

                }
                ProcessRecords processRecords = new ProcessRecords();
                processRecords.DeleteRecord(id);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("About");


        }
        [HttpPost]
        public ActionResult Edit(StudentModel student)
        {
            try
            {
                ProcessRecords processRecords = new ProcessRecords();
                processRecords.updateRecord(student);
                ViewBag.Message = "Record updated successfully";
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }
        [HttpPost]
        
        public JsonResult Index(StudentModel studentModel)
        {
            string message = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    //return View();
                }
                ProcessRecords processRecords = new ProcessRecords();
                message=processRecords.InsertRecordInStudentTable(studentModel);
                if(message != "")
                {
                    //ViewBag.Message = message;
                }
                else
                {
                    //ViewBag.Message = "Data recorded successfully";
                    message = "Data recorded successfully";
                    //ModelState.Clear();

                }
            }
            catch (Exception)
            {
                //Catch exception in text file
                //ViewBag.Message = "Error occured while inserting reocrd";
                message= "Error occured while inserting reocrd";
            }
            return Json(message,JsonRequestBehavior.AllowGet);
        }
    }
}