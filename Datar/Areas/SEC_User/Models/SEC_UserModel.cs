
using System.ComponentModel.DataAnnotations;

namespace Datar.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {


        public int UserID { get; set; }

        [Required]

        public string UserName { get; set; }

        [Required]
        public string PassWord { get; set; }
        public string EmailAddress { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsAdmin { get; set; }

    }
}
