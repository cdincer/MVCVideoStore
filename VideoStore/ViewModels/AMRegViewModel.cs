using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.ViewModels
{
    //For use with register page.
    public class AMRegViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string IDNumber { get; set; }
        public string Password { get; set; }
        public RolesList RoleList { get; set; }

    }
}