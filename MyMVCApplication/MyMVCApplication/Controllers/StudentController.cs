using MyMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        List<Student> studentList = new List<Student>() {
                    new Student(){ StudentId=1, StudentName="John", Age = 18 },
                    new Student(){ StudentId=2, StudentName="Steve", Age = 21 },
                    new Student(){ StudentId=3, StudentName="Bill", Age = 25 },
                    new Student(){ StudentId=4, StudentName="Ram", Age = 20 },
                    new Student(){ StudentId=5, StudentName="Ron", Age = 31 },
                    new Student(){ StudentId=6, StudentName="Chris", Age = 17 },
                    new Student(){ StudentId=7, StudentName="Rob", Age = 19 }
                };
        public ActionResult Index()
        {
            //var studentList = new List<Student>{
            //                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
            //                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
            //                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
            //                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
            //                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
            //                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
            //                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
            //            };
            // Get the students from the database in the real application

            return View(studentList);
        }
        public ActionResult Edit(int Id, string name)
        {
            //    // do something here
            var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();

            return View(std);
        }
        //[HttpPost]
       // public ActionResult Edit(Student std)
       // {
        //    var id = std.StudentId;
        //    var name = std.StudentName;
        //    var age = std.Age;
        //    var standardName = std.standard.StandardName;

        //    //update database here..

          //  return RedirectToAction("Index");
       // }
        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "StudentId, StudentName")] Student std)
        //{
        //    var name = std.StudentName;

        //    //write code to update student 

        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Age")] Student std)
        {
            var name = std.StudentName;

            //write code to update student 

            return RedirectToAction("Index");
        }


        //public string Index()
        //{
        //    return "This is Index action method of StudentController";
        //}

        //[HttpPost]
        //public ActionResult Edit(Student std)
        //{
        //    // update student to the database

        //    return RedirectToAction("Index");
        //}

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            // delete student from the database whose id matches with specified id
            var students = studentList;
            DeletedById(students, id);
            return RedirectToAction("Index");
        }

        private void DeletedById(List<Student> students, int id)
        {
            foreach (var student in students)
            {
                if (student.StudentId == id)
                {
                    students.Remove(student);      
                 }

                

            }
        }

        //public StudentController()
        //{

        //}

        //[ActionName("find")]
        //public ActionResult GetById(int id)
        //{
        //    // get student from the database 
        //    return View();
        //}


        //[NonAction]
        //public Student GetStudnet(int id)
        //{
        //    return studentList.Where(s => s.StudentId == id).FirstOrDefault();
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult PostAction()
        //{
        //    return View("Index");
        //}


        //[HttpPut]
        //public ActionResult PutAction()
        //{
        //    return View("Index");
        //}

        //[HttpDelete]
        //public ActionResult DeleteAction()
        //{
        //    return View("Index");
        //}

        //[HttpHead]
        //public ActionResult HeadAction()
        //{
        //    return View("Index");
        //}

        //[HttpOptions]
        //public ActionResult OptionsAction()
        //{
        //    return View("Index");
        //}

        //[HttpPatch]
        //public ActionResult PatchAction()
        //{
        //    return View("Index");
        //}

        //[AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        //public ActionResult GetAndPostAction()
        //{
        //    return RedirectToAction("Index");
        //}
    }
}