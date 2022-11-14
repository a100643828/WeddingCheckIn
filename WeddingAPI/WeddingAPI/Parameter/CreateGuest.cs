using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingAPI.Parameter
{
    public class CreateGuest
    {
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public Relation Relation { get; set; }
        public bool WeddingCake { get; set; }
        public string Partner { get; set; }
    }
}
