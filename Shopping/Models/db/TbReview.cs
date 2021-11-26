using System;
using System.Collections.Generic;

namespace Shopping.Models.db
{
    public partial class TbReview
    {
        public int RevId { get; set; }
        public string UserName { get; set; }
        public string PdName { get; set; }
        public string RevTitle { get; set; }
        public string RevMessage { get; set; }
        public DateTime? RevDate { get; set; }
        public double? Rating { get; set; }
    }
}
