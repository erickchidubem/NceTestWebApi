using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NceTestWebApi.Data;
using NceTestWebApi.Models;

namespace NceTestWebApi.Controllers
{

    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private nse_testContext _dbContext;

        public UserController(nse_testContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Register([FromBody]UserModel userModel)
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

                User user = Mapper.Map<User>(userModel);

                _dbContext.User.Add(user);
                _dbContext.SaveChanges();

                return Created($"api/user/{user.Id}", user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //private IUser Iuser;
        //public UserController()
        //{
        //    this.Iuser = new UserRepository(new Models.nse_testContext());
        //}

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var list = Iuser.GetUsers().ToList();
        //    return Ok(list);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get([FromRoute]int id)
        //{
        //    try
        //    {
        //        var user = Iuser.GetUserByID(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(user);

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody]Models.User user)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            var errors = new List<string>();
        //            foreach (var state in ModelState)
        //            {
        //                foreach (var error in state.Value.Errors)
        //                {
        //                    errors.Add(error.ErrorMessage);
        //                }
        //            }
        //            return BadRequest(new { message = errors });
        //        }

        //        Iuser.InsertUser(user);
        //        return Ok(new { message = "successfully created", messageid = 1, userinfo = user });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{

        //}

    }
}