using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nop.Core.Domain.QrCodes;
using Nop.Data;

namespace Nop.Services.QrCodes
{
   public class SunworldQrCodeService : ISunworldQrCodeService
   {
       private readonly IRepository<SunworldQrCode> _sunworldQrCodeRepository;

       public SunworldQrCodeService(IRepository<SunworldQrCode> sunworldQrCodeRepository)
       {
           _sunworldQrCodeRepository = sunworldQrCodeRepository;
       }

       public IList<SunworldQrCode> GetAll()
       {
           return _sunworldQrCodeRepository.Table.ToList();
       }

        public IList<SunworldQrCode> GetByFilter()
        {
            return _sunworldQrCodeRepository.Table.ToList();
        }

        public SunworldQrCode GetById(int id)
        {
            return _sunworldQrCodeRepository.GetById(id);
        }

        public SunworldQrCode GetByBarCode(string barcode)
        {
            return _sunworldQrCodeRepository.Table.FirstOrDefault(_ => _.BarCode == barcode);
        }

        public void Insert(SunworldQrCode model)
        {
            _sunworldQrCodeRepository.Insert(model);
        }

        public void Update(SunworldQrCode model)
        {
            _sunworldQrCodeRepository.Update(model);
        }

        public void Delete(int id)
        {
            _sunworldQrCodeRepository.Delete(x=> x.Id == id);
        }

        public IList<SunworldQrCode> ImportFromExcel(string filePath)
        {
            throw new NotImplementedException();
        }

        public SunworldQrCode GetAvaliableSunworldQrCode()
        {
            return _sunworldQrCodeRepository.Table.FirstOrDefault(_ => _.Used == false);
        }

        public SunworldQrCode GetByOrderItemId(int orderItemId)
        {
            return _sunworldQrCodeRepository.Table.FirstOrDefault(_ => _.OrderItemId == orderItemId);
        }
   }
}
