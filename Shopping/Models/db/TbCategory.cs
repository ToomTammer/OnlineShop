using System;
using System.Collections.Generic;

namespace Shopping.Models.db
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbProduct = new HashSet<TbProduct>();
        }

        public int CateId { get; set; }
        public string CateName { get; set; }

        public virtual ICollection<TbProduct> TbProduct { get; set; }
    }
}
