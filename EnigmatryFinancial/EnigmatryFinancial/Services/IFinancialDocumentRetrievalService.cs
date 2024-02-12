using EnigmatryFinancial.Models.Request;
using EnigmatryFinancial.Models.Response;

namespace EnigmatryFinancial.Services
{
    public interface IFinancialDocumentRetrievalService
    {
        FinancialDocumentResponse RetrieveDocument(DocumentRetrievalRequest request);
    }
}
