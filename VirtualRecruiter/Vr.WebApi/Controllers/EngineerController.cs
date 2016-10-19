using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vr.Biz;
using Vr.Domain;

namespace Vr.WebApi.Controllers
{
    public class EngineerController : ApiController
    {
	    private readonly IRecruiterBusiness _biz;

	    public EngineerController(IRecruiterBusiness biz)
	    {
		    _biz = biz;
	    }

		[ResponseType(typeof(IEnumerable<Engineer>))]
		public IHttpActionResult Get()
		{
			return Ok(_biz.GetAllEngineers());
		}

		[ResponseType(typeof(Engineer))]
		public IHttpActionResult Get(int id)
		{
			Engineer engineer = null;
			try
			{
				engineer = _biz.GetEngineerDetails(id);
				if (engineer != null)
				{
					return Ok(engineer);
				}
			}
			catch (Exception)
			{
				return NotFound();
			}

			return NotFound();
		}

		public Engineer Put(int id, Engineer engineer)
		{
			engineer.PersonId = id;
			return _biz.UpdateEngineer(engineer);
		}

		public void Delete(int id)
		{
			_biz.DeleteEngineer(id);
		}
	}
}
