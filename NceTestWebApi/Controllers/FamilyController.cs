using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NceTestWebApi.Data;
using NceTestWebApi.Models;

namespace NceTestWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Family")]
    [Authorize]
    public class FamilyController : Controller
    {
        private nse_testContext _dbContext;

        public FamilyController(nse_testContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                var family = _dbContext.Family.Where(f => f.UserId == id).ToList();
                if (family != null)
                {
                    return Ok(family);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]FamilyModel familyModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }
                    return BadRequest(new { message = errors });
                }

                var user = _dbContext.User.Where(x => x.Id == familyModel.UserId).FirstOrDefault();
                if (user != null)
                {
                    Family family = Mapper.Map<Family>(familyModel);
                    _dbContext.Family.Add(family);
                    _dbContext.SaveChanges();

                    return Created($"api/family/{family.Id}", family);
                }
                else
                {
                    return NotFound(new { message = "user does not exist" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

       [HttpPut("{id}")]
       public IActionResult Put([FromBody]FamilyModel familyModel,[FromRoute]int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }
                    return BadRequest(new { message = errors });
                }

                var user = _dbContext.User.Where(x => x.Id == familyModel.UserId).Include(u => u.Family).FirstOrDefault();

                if (user != null)
                {
                    Family family = user.Family.Where(f => f.Id == id).FirstOrDefault();

                    family.Name = familyModel.Name;
                    family.Age = familyModel.Age;
                    family.Relationship = familyModel.Relationship;
                    family.Phone = familyModel.Phone;
                    _dbContext.Entry(family).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    //return Created($"api/family/{family.Id}", family);
                    return Ok(family);

                }
                else
                {
                    return NotFound(new { mesage = "user does not exist" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}