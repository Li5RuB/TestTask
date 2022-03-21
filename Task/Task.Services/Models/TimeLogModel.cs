using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class TimeLogModel
    {
        private static readonly string[] Formats = { "h'h 'm'm'", "h'h'", "m'm'", };

        public int TimeLogId { get; set; }

        [Required]
        public int IssueId { get; set; }

        [Required]
        public DateTime DateLog { get; set; }

        public string DateLogParse
        {
            get
            {
                return DateLog.ToString("dd/MMM", CultureInfo.GetCultureInfo("en-US"));
            }
        }

        [Required]
        [Range(typeof(TimeSpan), "00:01", "10:00")]
        public TimeSpan Time { get; set; }

        public string TimeParse {
            get
            {
                return Time.ToString("d'd 'h'h 'm'm'", new CultureInfo("en-US"));
            }
            set
            {
                var time = new TimeSpan(0, 0, 0);
                foreach (var format in Formats)
                {
                    if (TimeSpan.TryParseExact(value, format, new CultureInfo("en-US"), out time))
                    {

                        Time = time;
                        break;
                    }
                }
            }
        }
    }
}
