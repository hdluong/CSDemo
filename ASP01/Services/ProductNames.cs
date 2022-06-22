using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP01
{
    public class ProductNames
    {
        private List<string> Names { get; set; }

        public ProductNames()
        {
            Names = new List<string>()
            {
                "Iphone X",
                "SamSung G7",
                "Nokia 113"
            };
        }

        public List<string> GetNames() => Names;
    }
}
