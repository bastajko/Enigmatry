using EnigmatryFinancial.Models.Request;
using EnigmatryFinancial.Models.Response;
using EnigmatryFinancial.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnigmatryFinancial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialDocumentController : ControllerBase
    {
        private readonly IFinancialDocumentService _documentRetrievalService;

        private readonly ILogger<FinancialDocumentController> _logger;

        public FinancialDocumentController(IFinancialDocumentService documentRetrievalService, ILogger<FinancialDocumentController> logger)
        {
            _documentRetrievalService = documentRetrievalService;
            _logger = logger;
        }

        [HttpPost("retrieve")]
        public IActionResult RetrieveDocument([FromBody] DocumentRetrievalRequest request)
        {
            try
            {
                FinancialDocumentResponse response = _documentRetrievalService.RetrieveDocument(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
