using EnigmatryFinancial.Http;
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

        [HttpGet("retrieve/{documentId}/{productCode}")]
        public async Task<IActionResult> RetrieveDocumentAsync(Guid documentId, string productCode)
        {
            using (_logger.BeginScope($"{nameof(RetrieveDocumentAsync)} documentId: {documentId} productCode: {productCode}"))
            {

                if (documentId == Guid.Empty || productCode == string.Empty)
                {
                    return BadRequest("Not valid documentId or productCode");
                }

                try
                {
                    Guid tenantId = HttpContext.GetTenantId();

                    string jsonResponse = await _documentRetrievalService.RetrieveDocument(tenantId, documentId, productCode).ConfigureAwait(false);
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
                    this._logger.LogError(ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
                }
            }
        }
    }
}

