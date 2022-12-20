﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(IAccountService accountService, IMapper mapper, 
            ILogger<AccountsController> logger)
        {
            _accountService = accountService;
            _mapper = mapper;
            _logger = logger;   
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<UserResponse>> SignUp([FromBody] SignUpRequestDTO input)
        {
            var newUser = await _accountService.SignUpAsync(input);
            return Ok(newUser);
        }
        [HttpPost("SignIn")]
        public async Task<ActionResult<UserResponse>> SignIn([FromBody] SignInRequestDTO input)
        {
            await _accountService.SignInAsync(input);
            var result = _mapper.Map<UserResponse>(input);
            if (result == null)
            {
                _logger.LogWarning("Account does not exist");
                return BadRequest(new ErrorResponse("Account not existed"));
            }
            return Ok(result);
        }
    }
}
