using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserResponseModel // kullanıcının adresinin ve telefon no sunun gözükmesini istemediğimizden yazmadık
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public Company Company { get; set; }
    }
}
