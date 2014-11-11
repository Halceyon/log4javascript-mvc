using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Log4Javascript.Web.Models;

namespace Log4Javascript.Web.Controllers
{
    public class LogsController : ApiController
    {
        private readonly DataContext _dataContext;

        public LogsController()
        {
            _dataContext = new DataContext();
        }
        public void Write(LogEntry[] data)
        {
            if (data != null)
            {
                foreach (var entry in data)
                {
                    var timestampUtc =
                        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(entry.Timestamp);
                    var timestampLocal = timestampUtc.ToLocalTime();
                    var ip = HttpContext.Current.Request.UserHostAddress;
                    _dataContext.ClientLogs.Add(new Entities.ClientLog()
                    {
                        Id = Guid.NewGuid(),
                        IpAddress = ip,
                        Level = entry.Level,
                        Logger = entry.Logger,
                        Message = entry.Message,
                        TimestampLocal = timestampLocal,
                        Url = entry.Url
                    });
                }
                _dataContext.SaveChanges();
            }
        }
    }
}