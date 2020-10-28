using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;

namespace PastesCatalina.Components
{
    public class AdminMenu : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AdminMenuItem>
            {
                new AdminMenuItem()
                {
                    DisplayValue = "User Management",
                    ActionValue = "UserManagment"
                },

                new AdminMenuItem()
                {
                    DisplayValue = "Role Management",
                    ActionValue = "RoleManagement"
                }
            };

            return View(menuItems);
        }

        private class AdminMenuItem
        {
            public string DisplayValue { get; set; }

            public string ActionValue { get; set; }
        }
    }
}
