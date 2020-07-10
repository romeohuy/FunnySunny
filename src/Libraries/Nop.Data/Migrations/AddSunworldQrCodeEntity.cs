using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using Nop.Core.Domain.QrCodes;

namespace Nop.Data.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("2020/07/10 11:24:16:2551771", "Add New AddSunworldQrCodeEntity ")]
    public class AddSunworldQrCodeEntity : AutoReversingMigration
    {
        private IMigrationManager _migrationManager;

        public AddSunworldQrCodeEntity(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        public override void Up()
        {
            
            _migrationManager.BuildTable<SunworldQrCode>(Create);
        }
    }
}
