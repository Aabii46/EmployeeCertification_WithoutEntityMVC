using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeCertification_WithoutMVC.Models;

namespace EmployeeCertification_WithoutMVC.Controllers
{
    public class tbl_employeeController : Controller
    {
        // GET: tbl_employee

        string constr = "Data Source = AABITH-MUSHARAF; Initial Catalog = employee; Integrated Security = True";
        public ActionResult Index()
        {
            if ((string)Session["uname"] == null)
            {
                return RedirectToAction("Signin", "tbl_Login");
            }
            else
            {


                ViewBag.LoggedInUser = Session["uname"];

                List<tbl_employee> tbl_employee_obj = new List<tbl_employee>();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_fetch", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        tbl_employee_obj.Add(new tbl_employee
                        {
                            id = Convert.ToInt32(sdr[0].ToString()),
                            emp_name = sdr[1].ToString(),
                            age = Convert.ToInt32(sdr[2].ToString()),
                            emp_id = sdr[3].ToString(),
                            designation = sdr[4].ToString()
                        }
                        );
                    }
                    con.Close();
                    return View(tbl_employee_obj);
                }
            } 
        }


        public ActionResult Logout()
        {
            ViewBag.LoggedInUser = "";
            Session["uname"] = "";
            //Session.Remove("uname");
            return View();
        }


            // GET: tbl_employee/Details/5
            public ActionResult Details(int id)
        {
            tbl_employee tbl_employee_obj = new tbl_employee();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_fetch_empid " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    tbl_employee_obj = new tbl_employee
                    {
                        id = Convert.ToInt32(sdr[0].ToString()),
                        emp_name = sdr[1].ToString(),
                        age = Convert.ToInt32(sdr[2].ToString()),
                        emp_id = sdr[3].ToString(),
                        designation = sdr[4].ToString()
                    };
                }
                con.Close();
            }

            return View(tbl_employee_obj);
        }

        // GET: tbl_employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_employee/Create
        [HttpPost]
        public ActionResult Create(tbl_employee tbl_employeeobj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_create '" + tbl_employeeobj.emp_name + "'," + tbl_employeeobj.age + ",'" + tbl_employeeobj.emp_id + "','" + tbl_employeeobj.designation + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: tbl_employee/Edit/5
        public ActionResult Edit(int id)
        {
            tbl_employee tbl_employee_obj = new tbl_employee();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_fetch_empid " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    tbl_employee_obj = new tbl_employee
                    {
                        id = Convert.ToInt32(sdr[0].ToString()),
                        emp_name = sdr[1].ToString(),
                        age = Convert.ToInt32(sdr[2].ToString()),
                        emp_id = sdr[3].ToString(),
                        designation = sdr[4].ToString()
                    };
                }
                con.Close();
            }

            return View(tbl_employee_obj);
        }

        // POST: tbl_employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,tbl_employee tbl_employeeobj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_edit " + id + ",'" + tbl_employeeobj.emp_name + "'," + tbl_employeeobj.age + ",'" + tbl_employeeobj.emp_id + "','" + tbl_employeeobj.designation + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: tbl_employee/Delete/5
        public ActionResult Delete(int id)
        {
            tbl_employee tbl_employee_obj = new tbl_employee();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_fetch_empid " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    tbl_employee_obj = new tbl_employee
                    {
                        id = Convert.ToInt32(sdr[0].ToString()),
                        emp_name = sdr[1].ToString(),
                        age = Convert.ToInt32(sdr[2].ToString()),
                        emp_id = sdr[3].ToString(),
                        designation = sdr[4].ToString()
                    };
                }
                con.Close();
            }

            return View(tbl_employee_obj);
        }

        // POST: tbl_employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,tbl_employee tbl_employeeobj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_delete_empid " + id, con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ListCertification(int id)
        {

            List<get_Certification> get_Certification_obj = new List<get_Certification>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_get_Certification " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    get_Certification_obj.Add(new get_Certification
                    {
                        emp_name = sdr[0].ToString(),
                        emp_id = sdr[1].ToString(),
                        designation = sdr[2].ToString(),
                        certification = sdr[3].ToString()
                    });
                }
                con.Close();
                return View(get_Certification_obj);
            }

        }

    }
}
