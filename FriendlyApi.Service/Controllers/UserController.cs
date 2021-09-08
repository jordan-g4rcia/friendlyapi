using System;
using System.Threading.Tasks;
using FriendlyApi.Service.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FriendlyApi.Service.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:password0123@cluster0.xqhm9.mongodb.net/friendlyapi?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("friendlyapi");

            var userCollection = await database.GetCollection<User>("users").AsQueryable().ToListAsync();
            return Ok(userCollection);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:password0123@cluster0.xqhm9.mongodb.net/friendlyapi?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("friendlyapi");

            await database.GetCollection<User>("users").InsertOneAsync(user);
            return Ok(user);
        }
    }
}