using DigitaalUpskills.Models;
using DigitaalUpskills.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitaalUpskills.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        // GET: Cart
        public ActionResult AddToCart(int id)
        {
            List<tbl_Course> CartLIst = new List<tbl_Course>();
            if (Session[ "cart"] != null )
            {
                CartLIst = (List<tbl_Course>)Session["cart"];
            }

            tbl_Course tbl_Course = db.tbl_Course.Where(x => x.Course_Id == id).FirstOrDefault();
            CartLIst.Add(tbl_Course);

            Session["Cart"] = CartLIst;



            return RedirectToAction("DisplayCart");
        } 
        public ActionResult DisplayCart()
        {
            return View();
        } 
        public ActionResult CourseRegistered(tbl_CourseRegistration registered)
        {
            List<tbl_Course> list = new List<tbl_Course>();
            list = (List<tbl_Course>)Session["cart"];
            var data = list.FirstOrDefault();
            registered.Course_Registration_Date = DateTime.Now;
            registered.Student_Fid = CurrentUser.CurrentStudent.Student_Id;
            registered.Payment_Status = "Registered";
            registered.Course_Fid =data.Course_Id ;
            db.tbl_CourseRegistration.Add(registered);
            db.SaveChanges();
            string mailBody = "Your Course has been registered Successfully";
            EmailProvider.Email(registered.Gmail, "Course Conformation", mailBody);
            return View();
        }
        public ActionResult RemoveFromCart(int id)
        {
            List<tbl_Course> list = new List<tbl_Course>();
            list = (List<tbl_Course>)Session["cart"];
                list.RemoveAt(id);
            Session["cart"] = list; 
            return View("DisplayCArt");
        }
        public ActionResult Checkout()
        {
            if(CurrentUser.CurrentStudent == null)
            {
                return RedirectToAction("LoginStudent", "Home");
            }
            return View();
        }
    }
}