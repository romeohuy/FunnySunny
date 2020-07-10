using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.QrCodes;

namespace Nop.Data.Mapping.Builders.QrCodes
{
     public class SunworldQrCodeBuilder : NopEntityBuilder<SunworldQrCode>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SunworldQrCode.BarCode)).AsString(20).NotNullable()
                .WithColumn(nameof(SunworldQrCode.Used)).AsBoolean().NotNullable()
                .WithColumn(nameof(SunworldQrCode.OrderItemId)).AsInt16().Nullable()
                .WithColumn(nameof(SunworldQrCode.SunworldProductName)).AsString(1000).Nullable()
                .WithColumn(nameof(SunworldQrCode.TransactionFiscal)).AsDate().Nullable()
                .WithColumn(nameof(SunworldQrCode.Transaction)).AsDate().Nullable()
                .WithColumn(nameof(SunworldQrCode.TransactionTDSSN)).AsString(1000).Nullable()
                .WithColumn(nameof(SunworldQrCode.Description)).AsString(1000).Nullable();
        }
    }
}
