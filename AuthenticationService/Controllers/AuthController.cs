using AuthenticationService.Models;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly MongoDBService _mongoDBService;

    public AuthController(ILogger<AuthController> logger, MongoDBService mongoDBService)
    {
        _logger = logger;
        _mongoDBService = mongoDBService;
    }

    [HttpGet("GetUserList")]
    public async Task<List<User>> GetUserList()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpGet("GetUserByEmail")]
    public async Task<User> GetUserByEmail()
    {
        return await _mongoDBService.GetByUserAsync("mark_addy@gameofthron.es", "$2b$12$yGqxLG9LZpXA2xVDhuPnSOZd.VURVkz7wgOLY3pnO0s7u2S1ZO32y");
    }
    

}

