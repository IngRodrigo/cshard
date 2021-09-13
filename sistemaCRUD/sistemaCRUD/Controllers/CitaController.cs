using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCRUD.Controllers
{
    public class CitaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
