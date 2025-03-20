
namespace Datar.Areas.MST_Company.Models
{
    public class CompanyModel 
    {
       public int? CompanyID {  get; set; }
       public string? CompanyName { get; set; }
       public string? City { get; set; }
       public string? UserName { get; set; }
        public string Password { get; set; }
        public int Contact { get; set; }
        public string? Email { get; set; }
    }
}