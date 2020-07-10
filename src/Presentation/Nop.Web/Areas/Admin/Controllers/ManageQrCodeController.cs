using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.QrCodes;
using Nop.Services.QrCodes;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.QrCodes;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class ManageQrCodeController : BaseAdminController
    {
        private readonly ISunworldQrCodeService _sunworldQrCodeService;

        public ManageQrCodeController(ISunworldQrCodeService sunworldQrCodeService)
        {
            _sunworldQrCodeService = sunworldQrCodeService;
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
            return View();
        }

        // POST: ManageQrCodeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
    }
}
