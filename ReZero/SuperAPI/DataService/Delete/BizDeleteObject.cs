﻿using Kdbndp.TypeHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReZero.SuperAPI 
{
    internal class BizDeleteObject : CommonDataService, IDataService
    {
        public async Task<object> ExecuteAction(DataModel dataModel)
        {
            var db = App.GetDbTableId(dataModel.TableId) ?? App.Db;
            var type = await EntityGeneratorManager.GetTypeAsync(dataModel.TableId);
            base.InitData(type, db, dataModel);
            var entity = db.EntityMaintenance.GetEntityInfo(type);
            if (!entity.Columns.Any(it => it.PropertyName.EqualsCase(nameof(DbBase.IsDeleted))))
            {
                throw new Exception(TextHandler.GetCommonText(type.Name + "没有IsDeleted属性不能逻辑删除", type.Name + "Cannot be logically deleted without IsDeleted attribute"));
            }
            CheckSystemData(db,dataModel, type, entity);
            await db.UpdateableByObject(dataModel.Data)
                    .UpdateColumns("isdeleted")
                    .ExecuteCommandAsync();
            return true;
        }
    }
}
