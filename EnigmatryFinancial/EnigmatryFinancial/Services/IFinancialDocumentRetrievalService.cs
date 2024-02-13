using EnigmatryFinancial.Models.Request;
using EnigmatryFinancial.Models.Response;

namespace EnigmatryFinancial.Services
{
    public interface IFinancialDocumentRetrievalService
    {
        Task<FinancialDocumentResponse> RetrieveDocument(DocumentRetrievalRequest request);
    }
}
