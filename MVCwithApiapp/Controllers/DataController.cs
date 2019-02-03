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

        
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]ReportModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _mapper.Map<ReportModel, Report>(model);
                    
                    _repository.AddReport(result);
                  
                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok("Successfully saved data");
                    }
                    //_mapper.Map<Report, ReportModel>(result);

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
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<ReportModel>> Get(int id)
        {
            try
            {
                var result = _repository.GetAllReportByUserId(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else {
                    return NotFound("Sorry wrong user id.");
                }
                
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
                return Ok(await _repository.GetAllReports());

            }
            catch (Exception)
            {

                return BadRequest("Sorry! All Items couldn't be fetched!");
            }
        }
        [Route("delete/{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var report =await _repository.GetReportByReportId(id);
            if (report==null)
            {
                return NotFound("This report doesnot exist");
            }
           // return Ok(report);
             _repository.RemoveEntity(report);
            if (await _repository.SaveChangeAsync())
            {
                return Ok("Successfully Deleted");
            }
            return BadRequest("Sorry!");
            
        }


    }
}
