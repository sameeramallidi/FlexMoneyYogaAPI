using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using YogaAPI.Models;

namespace YogaAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class YogaController : ControllerBase
    {
        ////[DisableCors]
        [HttpPost(Name = "AddYogaUser")]
        
        public HttpResponseMessage Post([FromBody] UserDetails objUser)
        {
            var response = new HttpResponseMessage();
            try
            {
                DataTable dt = new DataTable();
                string query = "INSERT INTO yoga_users VALUES ('" + objUser.Fname + "','" + objUser.Email + "','" + objUser.PhoneNum + "','" + objUser.Age + "','" + objUser.Batch + "')";
                using (var Conn = new SqlConnection("Server=DESKTOP-ORJKRE2\\SQLEXPRESS; Database=YogaDB; Trusted_Connection=True; MultipleActiveResultSets=true"))
                using (var cmd = new SqlCommand(query, Conn))
                using (var da = new SqlDataAdapter(cmd))
                { 
                     cmd.CommandType = CommandType.Text;
                     da.Fill(dt);
                }
                response = new HttpResponseMessage(HttpStatusCode.OK);
           }
            catch(Exception ex) 
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return response;
        }
    }
}
