using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using System.Configuration;
using Datar.DAL;

namespace Datar.DAL.SEC
{
    public class SEC_DALBase : DALHelpers
    {

        //select all

        //insert

        //update

        //delete

        //selectbypk

        //Fill dropdrown

        // selectbyusernameand password

        #region Method: SelectUserByUsernameAndPassword

        public DataTable SelectUserByUsernameAndPassword(string MyconnString, string UserName, string PassWord)
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("SelectUserByUsernameAndPassword");
            sqlDB.AddInParameter(dbCMD, "UserName",SqlDbType.VarChar, UserName);
            sqlDB.AddInParameter(dbCMD, "PassWord", SqlDbType.VarChar, PassWord);
            DataTable dt = new DataTable();
           
            using(IDataReader dr = sqlDB.ExecuteReader(dbCMD)) { 
                dt.Load(dr);
            }
            return dt;
        }

    }
}
#endregion