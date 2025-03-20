using Microsoft.AspNetCore.Mvc;
using Datar.DAL.SEC;
using System.Data;
using System.Data.SqlClient;
using Datar.Areas.SEC_User.Models;
using Datar.DAL.SEC;

namespace Datar.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[Controller]/[action]")]
    public class SEC_UserController : Controller
    {
            private IConfiguration Configuration;

            public SEC_UserController(IConfiguration _configuration)
            {
                Configuration = _configuration;
            }
            public IActionResult Index()
            {
                return View();
            }
            public IActionResult Register()
            {

                return View();
            }

            [HttpPost]
            public IActionResult Login(SEC_UserModel modelSEC_User)
            {

                string connstr = this.Configuration.GetConnectionString("MyconnString");
                string error = null;
                if (modelSEC_User.UserName == null)
                {
                    error += "User Name is Required";
                }
                if (modelSEC_User.PassWord == null)
                {
                    error += "User Password is Required";
                }
                if (error != null)
                {
                    TempData["Error"] = error;
                    return RedirectToAction("Index");
                }
                else
                {
                    SEC_DAL dal = new SEC_DAL();
                    DataTable dt = dal.SelectUserByUsernameAndPassword(connstr, modelSEC_User.UserName, modelSEC_User.PassWord);
                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                            HttpContext.Session.SetString("PassWord", dr["PassWord"].ToString());
                            HttpContext.Session.SetString("EmailAddress", dr["EmailAddress"].ToString());
                            HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                            HttpContext.Session.SetString("CreateBy", dr["CreateBy"].ToString());
                            HttpContext.Session.SetString("IsAdmin", dr["IsAdmin"].ToString());
                            if (Convert.ToBoolean(dr["IsAdmin"]))
                            {
                                return Redirect("/MST_Company/MST_Company/CompanyList");
                            }
                            else
                            {
                                return Redirect("/UserLayout/UserLayout/User");
                            }
                        }
                    }
                    else
                    {
                        TempData["Error"] = "UserName or Password is Invalid!";
                        return RedirectToAction("Index");

                    }
                    if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Index");
            }

            public IActionResult LogOut()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "SEC_User");
            }
        }
    }
