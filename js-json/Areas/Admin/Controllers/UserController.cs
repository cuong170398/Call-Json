using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using js_json.Areas.Admin.Models;
using Newtonsoft.Json;

namespace js_json.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        string Baseurl = "https://reqres.in/";
        public async Task<ActionResult> Index()
        {
            JsonModel userInfo = new JsonModel();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                try{
                HttpResponseMessage Res = await client.GetAsync("api/users?page=2");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    userInfo = JsonConvert.DeserializeObject<JsonModel>(EmpResponse);
                    Console.Write(userInfo);
                }
                }
                catch(excaption ex)
                {
                throw ex;
                }
                //returning the employee list to view  
                return View(userInfo);
            }
        }
    }
}
