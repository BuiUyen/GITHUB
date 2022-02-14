using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class Checker
    {
        public int CheckerID { get; set; }
        public string Gia { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string LinkAnh { get; set; }
        public List<string> ListAnh { get; set; }
    }
}
