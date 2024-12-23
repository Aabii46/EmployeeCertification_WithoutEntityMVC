using EmployeeCertification_WithoutMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCertification_WithoutMVC.Controllers
{
    public class tbl_LoginController : Controller
    {
        string constr = "Data Source = AABITH-MUSHARAF; Initial Catalog = employee; Integrated Security = True";
        
        // GET: tbl_Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: tbl_Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: tbl_Login/Create
        public ActionResult Signup()
        {
            return View();
        }

        // POST: tbl_Login/Create
        [HttpPost]
        public ActionResult Signup(tbl_Login tbl_Login_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_Login_signup '" + tbl_Login_obj.uname + "','" + tbl_Login_obj.pwd + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        ViewBag.SignupSuccess = "success";
                    }
                    //return RedirectToAction("Index");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Signin()
        {
            return View();
        }

        // POST: tbl_Login/Create
        [HttpPost]
        public ActionResult Signin(tbl_Login tbl_Login_obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string uname = "";
                    SqlCommand cmd = new SqlCommand("sp_Login '" + tbl_Login_obj.uname + "','" + tbl_Login_obj.pwd + "'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        uname = sdr[0].ToString();
                        Session["uname"] = uname;
                    }

                    con.Close();
                    if (uname!= "")
                    {
                        ViewBag.LoginSuccess = "Valid User";
                        return RedirectToAction("Index", "tbl_employee");
                    }
                    else
                    {
                        ViewBag.LoginSuccess = "InValid User";
                    }
                    //return RedirectToAction("Index");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: tbl_Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: tbl_Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: tbl_Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: tbl_Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
