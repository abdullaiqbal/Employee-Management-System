using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagmentWeb.WebApIs.Areas.Administration.Controller
{
    [Route("api/admin")]
    [AllowAnonymous]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        static List<string> list = new List<string>
        {
            "valueu1","value2","value3"
        };
        // GET: api/<AdministrationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return list;
        }

        // GET api/<AdministrationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //return "value";
            return list[id];
        }

        // POST api/<AdministrationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            list.Add(value);
        }

        // PUT api/<AdministrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            list[id] = value;
        }

        // DELETE api/<AdministrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            list.RemoveAt(id);
        }
    }
}
