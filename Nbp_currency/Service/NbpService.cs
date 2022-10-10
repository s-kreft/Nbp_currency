using Nbp_currency.Models;
using Nbp_currency.Controllers;
using Newtonsoft.Json;
using System.Collections;
using Nbp_currency.Repository;

namespace Nbp_currency.Service
{
    public class NbpService : INbpService
    {
        static readonly HttpClient _httpClient = new HttpClient();
        private readonly NbpContext _dataContext;
        public NbpService(NbpContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Root>> responseCurrencyList(UserInput userInput)
        {
            var response = await _httpClient.GetStringAsync("http://api.nbp.pl/api/exchangerates/tables/A/" + userInput.StartDate + "/" + userInput.EndDate + "/?format=json");
            var currenciesList = JsonConvert.DeserializeObject<List<Root>>(response);

            List<Root> RootList = new List<Root>();
            

            foreach (var day in currenciesList)
            {
                List<Rate> RateList = new List<Rate>();
                Root NewRoot = new Root() { effectiveDate = day.effectiveDate, no = day.no, table = day.table};
                RootList.Add(NewRoot);
                foreach (var rate in day.rates)
                {
                    if (rate.code.Equals(userInput.CurrencyCode))
                    {
                        RateList.Add(rate);
                    }
                }
                NewRoot.rates = RateList;
                //RootList.Add(day);
            }
            LogRecord logRecord = new LogRecord() { CurrencyCode = userInput.CurrencyCode, StartDate = userInput.StartDate, EndDate = userInput.EndDate, RequestTime = DateTime.Now};
            _dataContext.LogRecord.Add(logRecord);
            _dataContext.SaveChanges();
            return RootList;
        }

    }
}
