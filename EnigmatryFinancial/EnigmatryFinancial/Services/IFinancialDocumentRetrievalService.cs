using EnigmatryFinancial.Models.Request;
using EnigmatryFinancial.Models.Response;

namespace EnigmatryFinancial.Services
{
    public interface IFinancialDocumentRetrievalService
    {
        Task<string> RetrieveDocument(DocumentRetrievalRequest request);
    }
}
