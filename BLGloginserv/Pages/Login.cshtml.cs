
//using javax.jws;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Web;
using System.Threading.Tasks;

namespace BLGloginserv.Pages
{
    
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostSubmitAsync()//string username, string password)
        {
            return new JsonResult("success");
        }
        public async Task<IActionResult> OnPostLoginFuncAsync()//string username, string password)
        {
            return new JsonResult("success");
        }
        public async Task<IActionResult> OnPostLoginFunc()//string username, string password)
        {
            return new JsonResult("Success");
        }
        
        public async Task<IActionResult>  LoginFunc()
        {
            return new JsonResult("Success");
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
