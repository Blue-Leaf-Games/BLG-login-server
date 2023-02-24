using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Numerics;
using System.Globalization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLGloginserv
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class LoginFuncController : ControllerBase
    {
        string connstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
            model.password = Hash512(model.password);
            _logger.LogInformation("Received request to login username - " + model.username + " password - " + model.password + " identifier - " + id);
            switch (id)
            {
                case 0:
                    return Login(model);
                case 1:
                    return RegisterUser(model);
                    
                default:
                    return new JsonResult("Bad ID");
            }
        }

        private string Hash512(string password)
        {
            string CurrPassword = "";
            //string BinaryPassword = Convert.ToString(Convert.ToInt64(CurrPassword, 16),2);
            foreach(char c in password)
            {
                string i = Convert.ToString(Convert.ToByte(c), 2);
                CurrPassword += i + i;// + i.Substring(3,1);
            }
            BigInteger IntPassword = BigInteger.Parse(CurrPassword,NumberStyles.AllowHexSpecifier);
            BigInteger modint = BigInteger.Parse(password, NumberStyles.AllowHexSpecifier);//Convert.ToUInt64(password.Substring(0, 1) + password.Substring(32, 2) + password.Substring(17, 1) + password.Substring(46, 3) + password.Substring(24, 1), 16);
            IntPassword = IntPassword % modint;
            CurrPassword = IntPassword.ToString("X");
            return CurrPassword;
        }

        private IActionResult RegisterUser(LoginModel model)
        {
            string StoredUsername = "";

            using (SqlConnection conn = new SqlConnection(connstring))
            {
                SqlCommand comm = new SqlCommand("SELECT Username FROM Users WHERE Username='" + model.username + "'");
                comm.Connection = conn;
                comm.Connection.Open();
                using (SqlDataReader oReader = comm.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        StoredUsername = oReader["Username"].ToString();
                    }
                }
                if (StoredUsername == "" || StoredUsername == null)
                {
                    comm.CommandText = "INSERT INTO Users (Username, Password) VALUES ('" + model.username + "','" + model.password + "')";
                    comm.ExecuteNonQuery();
                }
                else
                {
                    comm.Connection.Close();
                    return new JsonResult("Username already in use");
                }
            }
            return new JsonResult("Registered");
        }

        public IActionResult Login(LoginModel model)
        {
            string StoredUsername = "";
            string StoredPassword = "";
            
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                SqlCommand comm = new SqlCommand("SELECT Username, Password FROM Users WHERE Username='" + model.username + "'");
                comm.Connection = conn;
                comm.Connection.Open();
                using (SqlDataReader oReader = comm.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        StoredUsername = oReader["Username"].ToString();
                        StoredPassword = oReader["Password"].ToString();
                    }


                }
            }

            return (StoredPassword == model.password) ? new JsonResult("Logged in as " + model.username) : new JsonResult("Incorrect username or password ");
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
