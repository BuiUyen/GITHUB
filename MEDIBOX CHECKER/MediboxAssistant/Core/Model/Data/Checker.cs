using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class Checker
    {
        public int CheckerID { get; set; }
        public string CheckerCode { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}
