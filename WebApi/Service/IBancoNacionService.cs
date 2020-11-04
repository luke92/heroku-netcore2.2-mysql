namespace WebApiBancoNacion.Service
{
    using System.Threading.Tasks;
    using WebApiBancoNacion.Models;

    public interface IBancoNacionService
    {
        Task<string> UpdateQuotesAsync();
        string InsertQuote(JsonHttpPost cotizacion);
        JsonResponse GetQuotes();
    }
}
