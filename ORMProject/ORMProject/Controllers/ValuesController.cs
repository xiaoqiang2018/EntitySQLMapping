using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ORMProject.Controllers
{

    public class ValuesController : Controller
    {
        public string GetValue(string a)
        {
            return $"{a}";
        }
        [HttpPost]
        public string PostValue(string a)
        {
            return a;
        }
        [HttpPost]
        public IActionResult AcioPostValue([FromForm]string a)
        {
            
            return Json(a);
        }
        // GET values/getvalue
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET values/getvalue/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST values/getvalue
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT values/getvalue/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE values/getvalue/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
