using System;
using System.Collections.Generic;

namespace Shopping.Models.db
{
    public partial class TbProduct
    {
        public TbProduct()
        {
            TbBill = new HashSet<TbBill>();
        }

        public int PdId { get; set; }
        public byte[] PdImg { get; set; }
        public string PdName { get; set; }
        public double? PdPrice { get; set; }
        public int? PdStock { get; set; }
        public string PdStatus { get; set; }
        public int? CateId { get; set; }
        public string PdDetail { get; set; }
        public string PdSubHead { get; set; }
        public int? PdDelete { get; set; }

        public virtual TbCategory Cate { get; set; }
        public virtual ICollection<TbBill> TbBill { get; set; }

    }
}
