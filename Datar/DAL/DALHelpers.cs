using Microsoft.AspNetCore.Mvc;

namespace Datar.DAL
{
    public class DALHelpers : Controller
    {
        #region Database Connection String

        public static string myConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");

        #endregion
    }
}
