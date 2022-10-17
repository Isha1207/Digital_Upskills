using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitaalUpskills.Models;
using DigitaalUpskills.Utills;

namespace DigitaalUpskills.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult LoginInstructor()
        {
            return View();
        }
        public ActionResult IndexAdmin()
        {
            return View();
        } 
        public ActionResult InstructorCourse()
        {
            return View();
        } 
        public ActionResult IndexUser()
        {
            return View();
        }
        public ActionResult CourseSingle()
        {
            return View();
        }
        public ActionResult Instructor(int? id)
        {
            if (id != null)
            {
                ViewData["catid"] = id;
            }
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult SignupStudent()
        {
            return View();
        }
        public ActionResult SignupInstructor()
        {
            return View();
        } 
        public ActionResult ForgetPassword()
        {
            return View();
        }
       

        [HttpPost]
        public ActionResult LoginInstructor (tbl_Instructor instructor)
        {
            TempData["Data"] = "Welcome to knowledge world!";
            if (instructor.Instructor_Name == null || instructor.Instructor_PhoneNo == null || instructor.Instructor_Address == null)
            {
                tbl_Instructor ins = db.tbl_Instructor.Where(x => x.Instructor_Gmail == instructor.Instructor_Gmail && x.Instructor_Password == instructor.Instructor_Password).FirstOrDefault();
                if (ins != null)
                {
                    return RedirectToAction("InstructorCourse");
                }
                else
                {
                    ViewBag.msg = "<script> alert('Invalid Email & Password'</script>)";
                }
            }
        
            if (ModelState.IsValid)

            {
                db.tbl_Instructor.Add(instructor);
                db.SaveChanges();
                ViewBag.msg = "<script> alert( 'Account Is Created Successfully' </script>)";
            }
            return View("IndexUser");
        }
        public ActionResult LoginStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginStudent(tbl_Student student)
        {
            TempData["Data"] = "Welcome to knowledge world!";
            if (student.Student_Name == null || student.Student_PhoneNo == null || student.Student_Address == null)
            {
                tbl_Student stu = db.tbl_Student.Where(x => x.Student_Gmail == student.Student_Gmail && x.Student_Password == student.Student_Password).FirstOrDefault();
                if (stu != null)
                {
                    CurrentUser.CurrentStudent = stu;
                    if (Session["cart"] != null)
                    {
                        return RedirectToAction("DisplayCart", "Cart");
                    }
                    return RedirectToAction("Courses");

                }
                else
                {
                    ViewBag.msg = "<script> alert('Invalid Email & Password'</script>)";
                }
            }
            if (ModelState.IsValid)

            {
                db.tbl_Student.Add(student);
                db.SaveChanges();
                ViewBag.msg = "<script> alert( 'Account Is Created Successfully' </script>)";
            }
            return View("IndexUser");
        }

        public ActionResult CourseCategory()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
      
        public ActionResult Courses(int? id)
        {
           if(id !=null)
            {
                ViewData["catid"] = id;
            }
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult SignUpAdmin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult LoginAdmin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(string Email, string Password)
        {

            int v = db.tbl_Admin.Where(x => x.Admin_Gmail == Email && x.Admin_Password == Password).Count();
            if (v > 0)
            {
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ViewBag.loginerror = "Incorrect Email or Passsword";
                return View();
            }

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        } 
        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}