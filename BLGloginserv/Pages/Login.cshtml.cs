using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Routing;
using javax.jws;

namespace BLGloginserv.Pages
{
    
    public class LoginModel : PageModel
    {
        public async Task<IActionResult> OnPostSubmitAsync()//HttpContext http, JsonDocument json)//string username, string password)
        {
            return new JsonResult("success");
        }
        /*
        public async Task<IActionResult> OnPostLoginFuncAsync()//HttpContext http, JsonDocument json)//string username, string password)
        {
            return new JsonResult("success");
        }
        */
        [WebMethod]
        public static async Task<IActionResult> OnPostLoginFuncAsync(HttpContext http, JsonDocument json)
        {
            string username = json.RootElement.GetProperty("username").GetString();
            string password = json.RootElement.GetProperty("password").GetString();

            // Perform authentication and authorization logic here
            // ...

            return new JsonResult(new { message = "success" });
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return new JsonResult("success");
        }

    }

    //public class Login : ApiController
    //{
    //    public string LoginErrorTxt = "";
    //    public void getLoginError()
    //    {

    //    }
    //    public IHttpActionResult Post(string username, string password)
    //    {
    //        LoginErrorTxt = "Test";
    //        Redirect("/Index");
    //        return StatusCode(HttpStatusCode.OK);
    //    }
    //}]
    
}
