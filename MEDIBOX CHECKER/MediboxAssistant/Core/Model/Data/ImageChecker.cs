using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class ImageChecker
    {
        public int ImageID { get; set; }
        public string Link { get; set; }
        public string Alt { get; set; }
        public string CheckerCode { get; set; }
    }
}
