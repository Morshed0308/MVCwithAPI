using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCwithApiapp.Data;
using MVCwithApiapp.Data.Entities;
using MVCwithApiapp.Models;

namespace MVCwithApiapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiContext _ctx;
        private readonly IMapper _mapper;

        public HomeController(ApiContext ctx,IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
       // [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ReportModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _mapper.Map<ReportModel, Report>(model);

                _ctx.Add(result);
                var res=_ctx.SaveChanges();
                if (res > 0)
                {
                    ViewBag.data = "Data saved";
                }
                

            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        



        


        
      
    }
}
