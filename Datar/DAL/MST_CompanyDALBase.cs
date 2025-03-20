using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Datar.Areas.MST_Company.Models;

namespace Datar.DAL
{
    public class MST_CompanyDALBase : DALHelpers
    {
        #region SelectAll

        public DataTable dbo_PR_Company_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Company_SelectAll");


                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Delete

        public bool? dbo_PR_Company_DeleteByPK(int? CompanyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Company_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CompanyID", SqlDbType.Int, CompanyID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Save
        public void Save(CompanyModel companymodel)
        {
            DbCommand objCmd;
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            if (companymodel.CompanyID == null)
            {
                objCmd = sqlDB.GetStoredProcCommand("PR_Company_Insert");

            }
            else
            {
                objCmd = sqlDB.GetStoredProcCommand("PR_Company_UpdateByPK");
                sqlDB.AddInParameter(objCmd, "@CompanyID", SqlDbType.Int, companymodel.CompanyID);
            }
            sqlDB.AddInParameter(objCmd, "CompanyName", SqlDbType.VarChar, companymodel.CompanyName);
            sqlDB.AddInParameter(objCmd, "City", SqlDbType.VarChar, companymodel.City);
            sqlDB.AddInParameter(objCmd, "Contact", SqlDbType.VarChar, companymodel.Contact);
            sqlDB.AddInParameter(objCmd, "Email", SqlDbType.VarChar, companymodel.Email);
            sqlDB.AddInParameter(objCmd, "UserName", SqlDbType.VarChar, companymodel.UserName);
            sqlDB.AddInParameter(objCmd, "Password", SqlDbType.VarChar, companymodel.Password);


            sqlDB.ExecuteNonQuery(objCmd);

        }
        #endregion
    }
}
