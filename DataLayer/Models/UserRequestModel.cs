﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserRequestModel //Bilgileri postladığımız apiye id göndermiyoruz o otomatik yapıyor. O yüzden Id kullanmadık.
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Adress Adress { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public Company Company { get; set; }
    }
}
