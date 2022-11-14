using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingAPI
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public Relation Relation { get; set; }
        public int? CashGift { get; set; }
        public int? TableId { get; set; }
        public WeddingCake WeddingCake { get; set; }
        public string Partner { get; set; }
    }
}
