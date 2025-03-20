using Datar.Areas.MST_Company.Models;
using Datar.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace Datar.Areas.MST_Company.Controllers
{
    [Area("MST_Company")]
    [Route("MST_Company/[Controller]/[action]")]
    public class MST_CompanyController : Controller
    {

        private IConfiguration Configuration;

        public MST_CompanyController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        MST_CompanyDAL company_dal = new MST_CompanyDAL();

        #region SelectAll
        public IActionResult CompanyList()
        {
            CompanyModel company = new CompanyModel();
            DataTable dt = company_dal.dbo_PR_Company_SelectAll();

            return View(dt);

        }
        #endregion


        #region Detail
        public IActionResult CompanyDetail()
        {

            CompanyModel company = new CompanyModel();
            DataTable dt = company_dal.dbo_PR_Company_SelectAll();

            return View(dt);

        }
        #endregion


        #region AddEdit
        public IActionResult AddEdit(int? CompanyID)
        {


            if (CompanyID != null)
            {
                SqlConnection Conn = new
               SqlConnection(Configuration.GetConnectionString("myConnectionString"));
                Conn.Open();
                SqlCommand Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "PR_Company_SelectByPK";
                Cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

                SqlDataReader sdr = Cmd.ExecuteReader();
                CompanyModel companymodel = new CompanyModel();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {


                        companymodel.CompanyName = sdr["CompanyName"].ToString();
                        companymodel.Contact = Convert.ToInt32(sdr["Contact"]);
                        companymodel.City = sdr["City"].ToString();
                        companymodel.UserName = sdr["UserName"].ToString();
                        companymodel.Password = sdr["Password"].ToString();
                        companymodel.Email = sdr["Email"].ToString();
                    }
                }
                return View("AddEditCompany", companymodel);
            }

            return View("AddEditCompany");
        }
        #endregion


        #region Save

        [HttpPost]
        public IActionResult Save(CompanyModel companymodel)
        {

            company_dal.Save(companymodel);

            if (companymodel.CompanyID != null && companymodel.CompanyID > 0)
            {
                TempData["Message"] = "Record Updated Successfully";
                return RedirectToAction("CompanyList");
            }
            else
            {
                TempData["Message"] = "Record Insert Successfully";
            }


            return RedirectToAction("CompanyList");
        }

        #endregion


        #region Delete
        public IActionResult Delete(int CompanyID)
        {
            if (Convert.ToBoolean(company_dal.dbo_PR_Company_DeleteByPK(CompanyID)))
            {
                TempData["DeleteMessage"] = "Record Deleted Successfully";
                return RedirectToAction("CompanyList");
            }
            else
            {

                TempData["MessageFKReference"] = "Record is Not Deleted beacuse of FK Refrenece To Another Table";
                return RedirectToAction("CompanyList");

            }
        }

        #endregion


        #region Clear
        public IActionResult Clear()
        {
            return RedirectToAction("CompanyList");
        }

        #endregion
    }
}
