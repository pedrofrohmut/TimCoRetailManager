using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;

namespace TRMDataManager.Controllers
{
  [Authorize]
  public class ValuesController : ApiController
  {
    // GET api/values
    public IHttpActionResult Get()
    {
      string userId = RequestContext.Principal.Identity.GetUserId();
      return Ok<IEnumerable<string>>(new string[] { "value1", "value2", userId });
    }

    // GET api/values/5
    public string Get(int id)
    {
      return "value";
    }

    // POST api/values
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    public void Delete(int id)
    {
    }
  }
}