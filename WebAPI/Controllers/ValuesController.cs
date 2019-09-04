using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Post plain text xml to http://localhost:49749/api/values to test api";
        }

  

        // POST api/values
        [HttpPost]
        public async Task<ContentResult> Post([FromBody] string body)
        {
            
            XDocument doc = XDocument.Parse(body);
            string valid = "0";

            if (doc.Root.Element("DeclarationList").Element("Declaration").Attribute("Command").Value != "DEFAULT")
                valid = "-1";

            if (doc.Root.Element("DeclarationList").Element("Declaration").Element("DeclarationHeader").Element("SiteID").Value != "DUB")
                valid = "-2";

            var response = new ContentResult
            {
                Content = valid,
                StatusCode = 200
            };
            return await Task.FromResult(response);
        }
    }
}
