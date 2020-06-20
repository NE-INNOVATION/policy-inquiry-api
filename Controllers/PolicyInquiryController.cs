using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace policy_Inquiry_api.Controllers
{
	[ApiController]
	[Route("api/policy/[controller]")]
	[EnableCors("*")]
	public class PolicyInquiryController : ControllerBase
	{	
		private readonly ILogger<PolicyInquiryController> _logger;
		private readonly PolicyInquiryService _policyInquiryService;

		public PolicyInquiryController(ILogger<PolicyInquiryController> logger, PolicyInquiryService policyInquiryService)
		{
			_logger = logger;
			_policyInquiryService = policyInquiryService;
		}

		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "Hello", "Hello 2" };
		}

		[HttpOptions()]
		[HttpGet]
		[Route("GetDetails/{policyNumber}")]
		public ActionResult<PolicyInquiry> Get(string policyNumber)
		{
			var policyInquiry = _policyInquiryService.Get(policyNumber);
			
			if (policyInquiry == null)
			{
				return NotFound();
			}

			return policyInquiry;
		}
	}
}
