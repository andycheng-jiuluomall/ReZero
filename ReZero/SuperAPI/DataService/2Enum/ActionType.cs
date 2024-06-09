﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ReZero.SuperAPI
{
    public enum ActionType
    {
         
        #region Query
        [ChineseText("根据主键查询")]
        [EnglishText("Query by primary key")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_QueryCN, PubConst.DataSource_ActionTypeGroupName_QueryEN)]
        QueryByPrimaryKey = 10000,

        [ChineseText("通用查询")]
        [EnglishText("Common query")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_QueryCN, PubConst.DataSource_ActionTypeGroupName_QueryEN)]
        QueryCommon = 10001,

        [ChineseText("树型查询")]
        [EnglishText("Common tree")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_QueryCN, PubConst.DataSource_ActionTypeGroupName_QueryEN)]
        QueryTree = 10002,

        [ChineseText("全表查询")]
        [EnglishText("Query all")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_QueryCN, PubConst.DataSource_ActionTypeGroupName_QueryEN)]
        QueryAll = 10003,
        #endregion


        #region Insert
        [ChineseText("插入根据实体")]
        [EnglishText("Insert by entity")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_InsertCN, PubConst.DataSource_ActionTypeGroupName_InsertEN)]
        InsertObject = 20000,

        [ChineseText("批量插入")]
        [EnglishText("Insert range")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_InsertCN, PubConst.DataSource_ActionTypeGroupName_InsertEN)]
        InsertRange = 20001,
        #endregion


        #region Delete
        [ChineseText("删除根据实体")]
        [EnglishText("Delete by entity")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_DeleteCN, PubConst.DataSource_ActionTypeGroupName_DeleteEN)]
        DeleteObject = 30000,  

        [ChineseText("逻辑删除根据实体")]
        [EnglishText("logic delete by entity")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_DeleteCN, PubConst.DataSource_ActionTypeGroupName_DeleteEN)]
        BizDeleteObject = 30001,
        #endregion


        #region  Update
        [ChineseText("更新根据实体")]
        [EnglishText("Update by entity")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_UpdateCN, PubConst.DataSource_ActionTypeGroupName_UpdateEN)]
        UpdateObject = 40000,

        [ChineseText("批量更新")]
        [EnglishText("Update Range")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_UpdateCN, PubConst.DataSource_ActionTypeGroupName_UpdateEN)]
        UpdateRange = 40001,
        #endregion


        #region DDL
        [ChineseText("获取数据库")]
        [EnglishText("Get database list")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_DDLCN, PubConst.DataSource_ActionTypeGroupName_DDLEN)]
        DllDatabaseList = 50000,
        [ChineseText("创建数据库")]
        [EnglishText("Create database")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_DDLCN, PubConst.DataSource_ActionTypeGroupName_DDLEN)]
        DllCreateDb = 50001,
        [ChineseText("创建表")]
        [EnglishText("Create tables")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_DDLCN, PubConst.DataSource_ActionTypeGroupName_DDLEN)]
        DllCreateTables = 50002,
        [ChineseText("获取表")]
        [EnglishText("Get tables")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_DDLCN, PubConst.DataSource_ActionTypeGroupName_DDLEN)]
        DllGetTables = 50003,
        #endregion


        #region 自定义方法
        [ChineseText("SQL脚本")]
        [EnglishText("SQL Script")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_MyMethodCN, PubConst.DataSource_ActionTypeGroupName_MyMethodEN)]
        SqlScript = 90000,

        [ChineseText("C#方法")]
        [EnglishText("C# Script")]
        [TextGroupAttribute(PubConst.DataSource_ActionTypeGroupName_MyMethodCN, PubConst.DataSource_ActionTypeGroupName_MyMethodEN)]
        MethodGeneratorAPI = 99999, 
        #endregion
    }
}
