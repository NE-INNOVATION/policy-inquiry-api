﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace policy_Inquiry_api.Controllers
{
	[ApiController]
	[Route("api/policy/[controller]")]
	[EnableCors("MyPolicy")]
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
			return new string[] { "Pinged successfull" };
		}

		[HttpOptions()]
		[HttpGet]
		[Route("GetDetails/{policyNumber}")]
		public ActionResult Get(string policyNumber)
		{
			var policyInquiry = _policyInquiryService.Get(policyNumber);
			
			if (policyInquiry == null)
			{
				return new JsonResult("Record not found for " + policyNumber);
			}

			return Ok(policyInquiry);
		}

		[HttpPost]
		public ActionResult Post(InquiryRequest inquiry)
		{
			string policyInquiry = "";

			if (!string.IsNullOrEmpty(inquiry.firstName))
            {
			   policyInquiry = _policyInquiryService.GetAllWithName("firstName", inquiry.firstName);
			}
            else
            {
				policyInquiry = _policyInquiryService.GetAllWithName("lastName", inquiry.lastName);
			}
				
			if (string.IsNullOrEmpty(policyInquiry))
			{
				return NotFound();
			}

			return Ok(policyInquiry);
		}
	}
}
