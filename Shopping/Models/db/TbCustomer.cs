using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.db
{
    public partial class TbCustomer
    {

        public TbCustomer()
        {
            TbBill = new HashSet<TbBill>();
        }

        public int CusId { get; set; }

        [Required(ErrorMessage = "กรุณาป้อนชื่อ")]
        public string CusName { get; set; }

        [Required(ErrorMessage = "กรุณาป้อนอีเมล")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CusEmail { get; set; }

        [Required(ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์ให้ครบ 10 ตัว")]
        public string CusPhone { get; set; }

        [Required(ErrorMessage = "กรุณาป้อนที่อยู่ปัจจุบัน")]
        public string CusAddress { get; set; }
        public byte[] CusReceipt { get; set; }

        [Required(ErrorMessage = "กรุณาอัปโหลดใบแจ้งการชำระเงิน")]
        public virtual ICollection<TbBill> TbBill { get; set; }
    }
}
