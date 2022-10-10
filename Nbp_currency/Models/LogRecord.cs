namespace Nbp_currency.Models
{
    public class LogRecord
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime RequestTime { get; set; }

        public LogRecord()
        {

        }
    }
}
