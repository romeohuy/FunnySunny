using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Rest.Azure;
using Nop.Core.Domain.QrCodes;

namespace Nop.Services.QrCodes
{
    public  interface ISunworldQrCodeService
    {
        IList<SunworldQrCode> GetAll();
        IList<SunworldQrCode> GetByFilter();
        SunworldQrCode GetById(int id);
        SunworldQrCode GetByBarCode(string barcode);
        void Insert(SunworldQrCode model);
        void Update(SunworldQrCode model);
        void Delete(int id);
        IList<SunworldQrCode> ImportFromExcel(string filePath);
    }
}
