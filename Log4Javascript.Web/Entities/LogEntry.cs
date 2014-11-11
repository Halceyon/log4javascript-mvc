using System;
using System.ComponentModel.DataAnnotations;

namespace Log4Javascript.Web.Entities
{
    public class ClientLog
    {
        [Key]
        public Guid Id { get; set; }

        public string IpAddress { get; set; }

        public string Level { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public DateTime TimestampLocal { get; set; }

        public string Url { get; set; }
    }
}