
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Web;

namespace BLGloginserv.Pages
{
    
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostSubmitAsync()
        {
            return new JsonResult("success");
        }
        /*
        public async Task<IActionResult> OnPostLoginFuncAsync()//string username, string password)
        {
            return new JsonResult("Success");
        }
        */
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
