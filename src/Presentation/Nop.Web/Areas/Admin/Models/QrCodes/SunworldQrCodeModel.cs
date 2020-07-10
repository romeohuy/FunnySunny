using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.QrCodes
{
    public class SunworldQrCodeModel : BaseNopEntityModel
    {
        public string BarCode { get; set; }
        public bool Used { get; set; }
        public int? OrderItemId { get; set; }
        public string SunworldProductName { get; set; }
        public DateTime? TransactionFiscal { get; set; }
        public DateTime? Transaction { get; set; }
        public DateTime? TransactionTDSSN { get; set; }
        public string Description { get; set; }
    }
}
