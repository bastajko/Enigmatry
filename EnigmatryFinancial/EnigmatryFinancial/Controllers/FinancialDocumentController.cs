using EnigmatryFinancial.Models.Request;
using EnigmatryFinancial.Models.Response;
using EnigmatryFinancial.Services;
using EnigmatryFinancial.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EnigmatryFinancial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialDocumentController : ControllerBase
    {
        private readonly IFinancialDocumentRetrievalService _documentRetrievalService;

        private readonly ILogger<FinancialDocumentController> _logger;

        public FinancialDocumentController(IFinancialDocumentRetrievalService documentRetrievalService, ILogger<FinancialDocumentController> logger)
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
            catch (BadHttpRequestException ex)
            {
                if (Util.IsDevelopmentEnvironment())
                {
                    // Log the full stack trace only in development environment
                    this._logger.LogError(ex.Message, ex.StackTrace);
                }
                else
                {
                    this._logger.LogError(ex.Message);
                }

                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
