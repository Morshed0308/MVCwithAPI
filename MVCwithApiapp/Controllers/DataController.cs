using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCwithApiapp.Data;
using MVCwithApiapp.Data.Entities;
using MVCwithApiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCwithApiapp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DataController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _ctx;
        private readonly IApiRepository _repository;

        public DataController(IMapper mapper,IApiRepository repository)
        {
            _mapper = mapper;
            
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post(ReportModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _mapper.Map<ReportModel, Report>(model);

                    _repository.AddReport(result);
                  
                    if (_repository.SaveAll())
                    {
                        return Ok("Successfully saved data");
                    }


                }
                else {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                
                
            }
            return BadRequest("There is some error please fix it!");


        }
        [Route("api/Data/{id?}")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReportModel[]>> Get(int id)
        {
            try
            {
                return Ok(_repository.GetAllReportByUserId(id));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<ReportModel[]>> Get()
        {
            try
            {
                return Ok(_repository.GetAllReports());

            }
            catch (Exception)
            {

                return BadRequest("Sorry! All Items couldn't be fetched!");
            }
        }



    }
}
