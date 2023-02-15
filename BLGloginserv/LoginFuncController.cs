using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLGloginserv
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginFuncController : ControllerBase
    {
        public class LoginModel
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        private readonly ILogger<LoginFuncController> _logger;
        public LoginFuncController(ILogger<LoginFuncController> logger)
        {
            _logger = logger;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost("{id}")]
        public IActionResult Post([FromBody] LoginModel model, int id)
        {
            _logger.LogInformation("Received request to login username - " + model.username + " password - " + model.password + " identifier - " + id);

            return new JsonResult("Success");
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
