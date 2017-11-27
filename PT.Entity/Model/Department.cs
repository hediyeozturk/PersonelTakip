using PT.Entity.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.Model
{
    [Table("Department")]
    public class Department:BaseModel
    {
        [Required]
        [StringLength(55, ErrorMessage="Bu alan zorunludur", MinimumLength =3)]
        public string DepartmentName { get; set; }
        public virtual List<ApplicationUser> Users { get; set; } =new List<ApplicationUser>();
    }
}
