using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.QrCodes;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.QrCodes;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.QrCodes;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class ManageQrCodeController : BaseAdminController
    {
        private readonly ISunworldQrCodeService _sunworldQrCodeService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IImportManager _importManager;
        private readonly IExportManager _exportManager;
        public ManageQrCodeController(ISunworldQrCodeService sunworldQrCodeService, ILocalizationService localizationService, INotificationService notificationService, IImportManager importManager, IExportManager exportManager)
        {
            _sunworldQrCodeService = sunworldQrCodeService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _importManager = importManager;
            _exportManager = exportManager;
        }

        // GET: ManageQrCodeController
        public ActionResult Index()
        {
            return View(_sunworldQrCodeService.GetAll().Select(q =>
            {
                var qrModel = q.ToModel<SunworldQrCodeModel>();
                return qrModel;
            }));
        }

        // GET: ManageQrCodeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_sunworldQrCodeService.GetById(id).ToModel<SunworldQrCodeModel>());
        }

        // GET: ManageQrCodeController/Create
        public ActionResult Create()
        {
            return View(new SunworldQrCodeModel());
        }

        // POST: ManageQrCodeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SunworldQrCodeModel model)
        {
            try
            {
                _sunworldQrCodeService.Insert(model.ToEntity<SunworldQrCode>());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageQrCodeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_sunworldQrCodeService.GetById(id).ToModel<SunworldQrCodeModel>());
        }

        // POST: ManageQrCodeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SunworldQrCodeModel model)
        {
            try
            {
                _sunworldQrCodeService.Update(model.ToEntity<SunworldQrCode>());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageQrCodeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageQrCodeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public virtual IActionResult ImportFromXlsx(IFormFile importexcelfile)
        {
            try
            {
                if (importexcelfile != null && importexcelfile.Length > 0)
                {
                    _importManager.ImportQrCodesFromXlsx(importexcelfile.OpenReadStream());
                }
                else
                {
                    _notificationService.ErrorNotification(_localizationService.GetResource("Admin.Common.UploadFile"));
                    return RedirectToAction("Index");
                }

                _notificationService.SuccessNotification(_localizationService.GetResource("Admin.ManageQrCode.ManageQrCodes.Imported"));

                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                _notificationService.ErrorNotification(exc);
                return RedirectToAction("Index");
            }
        }
        public virtual IActionResult ExportXlsx()
        {
            
            try
            {
                var bytes = _exportManager
                    .ExportQrCodeToXlsx(_sunworldQrCodeService.GetAll().ToList());

                return File(bytes, MimeTypes.TextXlsx, $"SunworldQrCodes_{DateTime.Now.ToString("dd-MM-yyyy")}_{DateTime.Now.Ticks}.xlsx");
            }
            catch (Exception exc)
            {
                _notificationService.ErrorNotification(exc);
                return RedirectToAction("Index");
            }
        }
    }
}
