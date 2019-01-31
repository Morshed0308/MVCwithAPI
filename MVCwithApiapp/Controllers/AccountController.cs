using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCwithApiapp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

    }
}
