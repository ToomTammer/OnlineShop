using System;
using System.Collections.Generic;

namespace Shopping.Models.db
{
    public partial class TbCart
    {
        public int CartId { get; set; }
        public byte[] CartImg { get; set; }
        public string CartName { get; set; }
        public double? CartPrice { get; set; }
        public int? CartQty { get; set; }
        public double? CartTotal { get; set; }
    }
}
