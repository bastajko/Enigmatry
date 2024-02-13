using EnigmatryFinancial.Models.Request;
using EnigmatryFinancial.Models.Response;
using EnigmatryFinancial.Services;
using EnigmatryFinancial.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> RetrieveDocumentAsync([FromBody] DocumentRetrievalRequest request)
        {
            try
            {
                string jsonResponse = await _documentRetrievalService.RetrieveDocument(request).ConfigureAwait(false);
                return Ok(jsonResponse);
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
                // TODO: Check if status code needs to be changed.
                this._logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
    }
}
