using Nbp_currency.Models;

namespace Nbp_currency.Service
{
    public interface INbpService
    {
        Task<List<Root>> responseCurrencyList(UserInput userInput);
    }
}