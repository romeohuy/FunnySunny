using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Helpers;
using Nop.Web.Framework.Controllers;

namespace Nop.Web.Controllers
{
    public class ManageQrCodeController : BasePublicController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string qrText)
        {
            
            return View(QrCodeHelper.GenerateQrCodeBytes(qrText));
        }
    }
}
