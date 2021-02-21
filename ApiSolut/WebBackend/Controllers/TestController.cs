using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DbEntities;
using DbEntities.Entities;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Dto;

namespace WebBackend.Controllers
{
    public class TestController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TestController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("register/user")]
        public async Task<ActionResult> GetSampleQuery([FromBody, Required] RegisterParameters registerParams)
        {
            try
            {
                await _dbContext.UserLogin.AddAsync(new UserLogin
                {
                    Email = registerParams.Email,
                    Password = registerParams.Password,
                    Username = registerParams.Username,
                    FirstName = registerParams.FirstName,
                    LastName = registerParams.LastName
                });
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }

            return Ok();
        }
    }
}