using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; }
        public string status { get; set; }
    }
}
