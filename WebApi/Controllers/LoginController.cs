using AutoMapper;
using Domain.Security;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoginController(MyDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateSession([FromBody] CreateSessionPostRequestModel login)
        {
            try
            {
                var validCredential = _dbContext.Logins.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();

                SecurityService securityService = new SecurityService();

                if (validCredential)
                    return Ok(_mapper.Map<Login, CreateSessionPostResponseModel>(securityService.GetToken(validCredential)));
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
