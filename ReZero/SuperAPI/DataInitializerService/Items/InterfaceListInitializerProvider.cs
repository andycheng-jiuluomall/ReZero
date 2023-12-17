﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReZero.SuperAPI
{
    internal partial class InterfaceListInitializerProvider
    {
        List<ZeroInterfaceList> zeroInterfaceList = new List<ZeroInterfaceList>() { };
        public InterfaceListInitializerProvider(List<ZeroInterfaceList> zeroInterfaceList)
        {
            this.zeroInterfaceList = zeroInterfaceList;
        }
        internal void Set()
        {
            GetZeroInterfaceList();
            GetInterfaceCategory();
            GetDatabaseList();
            GetCodeList();
            GetEntityList();
        }

        private void GetEntityList()
        {
            //获取实体列表
            ZeroInterfaceList data2 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = GetEntityInfoListId;
                it.GroupName = nameof(ZeroEntityInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(GetEntityInfoListId);
                it.Url = GetUrl(it, "GetEntityInoList");
                it.CustomResultModel = new ResultModel()
                {
                    ResultType = ResultType.Grid,
                    ResultColumnModels=new List<ResultColumnModel>() 
                    {
                         new ResultColumnModel()
                         {
                               ResultColumnType=ResultColumnType.SubqueryName,
                               PropertyName= nameof(ZeroEntityInfo.DataBaseId),
                                
                         }
                    } 
                };
                it.DataModel = new DataModel()
                {
                    CommonPage = new DataModelPageParameter
                    {
                        PageSize = 20,
                        PageNumber = 1
                    },
                    Columns = new List<DataColumnParameter>()
                    {

                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroEntityInfo.Id) ,
                            Description=TextHandler.GetCommonTexst("ID", "Primary key")
                        },
                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroEntityInfo.ClassName) ,
                            Description=TextHandler.GetCommonTexst("类名", "Class name")
                        },
                       new DataColumnParameter(){
                            PropertyName= nameof(ZeroEntityInfo.DbTableName) ,
                            Description=TextHandler.GetCommonTexst("表名", "Table name")
                        },
                         new DataColumnParameter(){
                            PropertyName= nameof(ZeroEntityInfo.DataBaseId) ,
                            Description=TextHandler.GetCommonTexst("数据库", "DataBase id")
                        },
                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroEntityInfo.Description) ,
                            Description=TextHandler.GetCommonTexst("备注", "Description")
                        }
                    },
                    TableId = EntityInfoInitializerProvider.Id_ZeroEntityInfo,
                    ActionType = ActionType.QueryCommon,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.IsDeleted),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(bool).Name,Value="false",ValueIsReadOnly=true, Description = TextHandler.GetCommonTexst("IsDeleted", "IsDeleted") },
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.Name),   FieldOperator=FieldOperatorType.Like,  ValueType = typeof(string).Name,Value=null , Description = TextHandler.GetCommonTexst("名称", "class Name") },
                             new DefaultParameter() { Name=nameof(DataModelPageParameter.PageNumber) ,Value=1,FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name, Description = TextHandler.GetCommonTexst("第几页", "Page number") },
                             new DefaultParameter() { Name=nameof(DataModelPageParameter.PageSize) ,Value=20,FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name, Description = TextHandler.GetCommonTexst("每页几条", "Pageize") }
                    }
                };
            });
            zeroInterfaceList.Add(data2);


            //实体删除
            ZeroInterfaceList data3 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = DeleteEntityInfoById;
                it.GroupName = nameof(ZeroEntityInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(DeleteEntityInfoById);
                it.Url = GetUrl(it, "DeleteEntityInfo");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroEntityInfo,
                    ActionType = ActionType.BizDeleteObject,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroEntityInfo.Id),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name,Value=0, Description = TextHandler.GetCommonTexst("主键", "Id") },
                              new DefaultParameter() { Name = nameof(ZeroEntityInfo.IsDeleted),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(bool).Name,Value="true", Description = TextHandler.GetCommonTexst("是否删除", "IsDeleted") }
                         }
                };
            });
            zeroInterfaceList.Add(data3);

            //添加实体
            ZeroInterfaceList data4 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.POST.ToString();
                it.Id = AddEntityInfoId;
                it.GroupName = nameof(ZeroEntityInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(AddEntityInfoId);
                it.Url = GetUrl(it, "AddEntityInfo");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroEntityInfo,
                    ActionType = ActionType.InsertObject,
                    DefaultParameters = new List<DefaultParameter>()
                    {
                        new DefaultParameter() { 
                                                   Name=nameof(ZeroEntityInfo.ClassName) ,
                                                   ParameterValidate=new ParameterValidate(){IsRequired=true},ValueType = typeof(string).Name },
                         new DefaultParameter() {
                                                   Name=nameof(ZeroEntityInfo.DbTableName) ,
                                                   ParameterValidate=new ParameterValidate(){IsRequired=true},ValueType = typeof(string).Name },
                        new DefaultParameter() { 
                                                  Name=nameof(ZeroEntityInfo.DataBaseId) ,
                                                  ParameterValidate=
                                                  new ParameterValidate()
                                                   {
                                                     IsRequired=true
                                                  },

                                                  ValueType = typeof(long).Name }, 
                       new DefaultParameter() {
                                                  Name=nameof(ZeroEntityInfo.Description) ,
                                                  ValueType = typeof(string).Name },
                                                  DataInitHelper.GetIsDynamicParameter(),
                        new DefaultParameter() { 
                                                Name=nameof(ZeroEntityInfo.Creator),
                                                InsertParameter=new InsertParameter(){
                                                     IsUserName=true
                                                },
                                                 Value="" ,
                                                 ValueType = typeof(string).Name },

                    }
                };
            });
            zeroInterfaceList.Add(data4);


            //修改实体
            ZeroInterfaceList data5 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.POST.ToString();
                it.Id = UpdateEntityInfoId;
                it.GroupName = nameof(ZeroEntityInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(UpdateEntityInfoId);
                it.Url = GetUrl(it, "UpdateEntityInfo");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroEntityInfo,
                    ActionType = ActionType.UpdateObject,
                    DefaultParameters = new List<DefaultParameter>()
                    {
                        new DefaultParameter() { Name=nameof(ZeroEntityInfo.Id),ValueType = typeof(long).Name },
                        new DefaultParameter() { Name=nameof(ZeroEntityInfo.ClassName) ,ParameterValidate=
                        new ParameterValidate()
                        {
                            IsRequired=true
                        } ,ValueType = typeof(string).Name },
                        new DefaultParameter() { Name=nameof(ZeroEntityInfo.DbTableName) ,ParameterValidate=
                        new ParameterValidate()
                        {
                            IsRequired=true
                        } ,ValueType = typeof(string).Name },
                        new DefaultParameter() { Name=nameof(ZeroEntityInfo.DataBaseId), ParameterValidate= new ParameterValidate()
                        {
                            IsRequired=true
                        },ValueType = typeof(string).Name },
                        new DefaultParameter() { Name=nameof(ZeroEntityInfo.Description),ValueType = typeof(string).Name },
                    }
                };
            });
            zeroInterfaceList.Add(data5);


            //根据主键获取实体
            ZeroInterfaceList data6 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = GetEntityInfoById;
                it.GroupName = nameof(ZeroInterfaceCategory);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(GetEntityInfoById);
                it.Url = GetUrl(it, "GetEntityInfoById");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroEntityInfo,
                    ActionType = ActionType.QueryByPrimaryKey,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.Id),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name,Value=0, Description = TextHandler.GetCommonTexst("主键", "Id") }
                         }
                };
            });
            zeroInterfaceList.Add(data6);
        }

        private void GetCodeList()
        {
            ZeroInterfaceList data = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = GetDbTypeList;
                it.GroupName = nameof(EnumApi);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100004;
                it.Name = TextHandler.GetInterfaceListText(GetDbTypeList);
                it.Url = GetUrl(it, "GetDbTypeList");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.MyMethod,
                    MyMethodInfo = new MyMethodInfo()
                    {
                        MethodClassFullName = typeof(EnumApi).FullName,
                        MethodArgsCount = 0,
                        MethodName = nameof(EnumApi.GetDbTypeSelectDataSource)
                    }
                };
            });
            zeroInterfaceList.Add(data);
        }

        private void GetDatabaseList()
        {
            //获取数据库所有
            ZeroInterfaceList data1 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = GetDbAllId;
                it.GroupName = nameof(ZeroDatabaseInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100004;
                it.Name = TextHandler.GetInterfaceListText(GetDbAllId);
                it.Url = GetUrl(it, "GetDatabaseInfoAllList"); 
                it.DataModel = new DataModel()
                { 
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.QueryCommon,
                    DefaultParameters = new List<DefaultParameter>() 
                    {
                        new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.IsDeleted),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(bool).Name,Value="false",ValueIsReadOnly=true, Description = TextHandler.GetCommonTexst("IsDeleted", "IsDeleted") },
                    }
                };
            });
            zeroInterfaceList.Add(data1);


            //获取数据库列表
            ZeroInterfaceList data2 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = DbManId;
                it.GroupName = nameof(ZeroDatabaseInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(IntCateListId);
                it.Url = GetUrl(it, "GetDatabaseInfoList");
                it.CustomResultModel = new ResultModel()
                {
                    ResultType = ResultType.Grid
                };
                it.DataModel = new DataModel()
                {
                    CommonPage = new DataModelPageParameter
                    {
                        PageSize = 20,
                        PageNumber = 1
                    },
                    Columns = new List<DataColumnParameter>()
                    {

                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroDatabaseInfo.Id) ,
                            Description=TextHandler.GetCommonTexst("ID", "Primary key")
                        },
                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroDatabaseInfo.Name) ,
                            Description=TextHandler.GetCommonTexst("库说明", "Name")
                        },
                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroDatabaseInfo.DbType) ,
                            Description=TextHandler.GetCommonTexst("类型", "Type")
                        },
                       new DataColumnParameter(){
                            PropertyName= nameof(ZeroDatabaseInfo.Connection) ,
                            Description=TextHandler.GetCommonTexst("字符串", "Connection")
                        }
                    },
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.QueryCommon,
                    DefaultParameters = new List<DefaultParameter>() {

                             new DefaultParameter() { Name = nameof(ZeroDatabaseInfo.Name),   FieldOperator=FieldOperatorType.Like,  ValueType = typeof(string).Name,Value=null , Description = TextHandler.GetCommonTexst("库说明", "Name") },
                             new DefaultParameter() { Name=nameof(DataModelPageParameter.PageNumber) ,Value=1,FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name, Description = TextHandler.GetCommonTexst("第几页", "Page number") },
                             new DefaultParameter() { Name=nameof(DataModelPageParameter.PageSize) ,Value=20,FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name, Description = TextHandler.GetCommonTexst("每页几条", "Pageize") },
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.IsDeleted),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(bool).Name,Value="false",ValueIsReadOnly=true, Description = TextHandler.GetCommonTexst("IsDeleted", "IsDeleted") },
                    }
                };
            });
            zeroInterfaceList.Add(data2);

            //删除数据库
            ZeroInterfaceList data3 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = DelDbManId;
                it.GroupName = nameof(ZeroDatabaseInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(DeleteCateTreeId);
                it.Url = GetUrl(it, "DeleteDatabaseInfo");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.BizDeleteObject,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroDatabaseInfo.Id),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name,Value=0, Description = TextHandler.GetCommonTexst("主键", "Id") },
                              new DefaultParameter() { Name = nameof(ZeroDatabaseInfo.IsDeleted),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(bool).Name,Value="true", Description = TextHandler.GetCommonTexst("是否删除", "IsDeleted") }
                         }
                };
            });
            zeroInterfaceList.Add(data3);

            //添加数据库
            ZeroInterfaceList data4 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.POST.ToString();
                it.Id = AddDbManId;
                it.GroupName = nameof(ZeroDatabaseInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(AddCateTreeId);
                it.Url = GetUrl(it, "AddDatabaseInfo");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.InsertObject,
                    DefaultParameters = new List<DefaultParameter>()
                    {
                        new DefaultParameter() { Name=nameof(ZeroDatabaseInfo.Name) ,ParameterValidate=
                        new ParameterValidate(){IsRequired=true},ValueType = typeof(string).Name }, new DefaultParameter() { Name=nameof(ZeroDatabaseInfo.Connection), ValueType = typeof(string).Name,ParameterValidate=new ParameterValidate(){IsRequired=true}},

                         new DefaultParameter() { Name=nameof(ZeroDatabaseInfo.DbType) ,ValueType = typeof(int).Name,ParameterValidate=new ParameterValidate(){
                         IsRequired=true
                         }},

                        new DefaultParameter() { Name=nameof(ZeroDatabaseInfo.Creator),
                        InsertParameter=new InsertParameter(){IsUserName=true},Value="" ,ValueType = typeof(string).Name },

                    }
                };
            });
            zeroInterfaceList.Add(data4);


            //修改数据库
            ZeroInterfaceList data5 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.POST.ToString();
                it.Id = EditDbManId;
                it.GroupName = nameof(ZeroDatabaseInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(UpdateCateTreeId);
                it.Url = GetUrl(it, "UpdateDatabaseInfo");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.UpdateObject,
                    DefaultParameters = new List<DefaultParameter>()
                    {
                        new DefaultParameter() { Name=nameof(ZeroDatabaseInfo.Id),ValueType = typeof(long).Name },
                        new DefaultParameter() { 
                             Name=nameof(ZeroDatabaseInfo.Name) ,
                             ParameterValidate=
                             new ParameterValidate()
                             {
                                IsRequired=true
                             } ,
                             ValueType = typeof(string).Name },
                        new DefaultParameter() {
                            Name=nameof(ZeroDatabaseInfo.DbType) ,ParameterValidate=
                            new ParameterValidate()
                            {
                                IsRequired=true
                            } ,
                            ValueType = typeof(string).Name 
                        },
                        new DefaultParameter()
                        {
                            Name=nameof(ZeroDatabaseInfo.Connection),
                            ParameterValidate=
                            new ParameterValidate()
                            {
                                IsRequired=true
                            } ,ValueType = typeof(string).Name
                        }
                    }
                };
            });
            zeroInterfaceList.Add(data5);


            //获取数据库根据主键获取详情
            ZeroInterfaceList data6 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = GetDbManIdById;
                it.GroupName = nameof(ZeroDatabaseInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(GetCateTreeById);
                it.Url = GetUrl(it, "GetDatabaseInfoById");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.QueryByPrimaryKey,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroDatabaseInfo.Id),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name,Value=0, Description = TextHandler.GetCommonTexst("主键", "Id") }
                         }
                };
            });
            zeroInterfaceList.Add(data6);



            //测试数据库
            ZeroInterfaceList data7 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = TestDatabaseId;
                it.GroupName = nameof(ZeroDatabaseInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(TestDatabaseId);
                it.Url = GetUrl(it, "TestDatabaseInfo");
                it.DataModel = new DataModel()
                {
                        MyMethodInfo=new MyMethodInfo() {
                        MethodClassFullName = typeof(MethodApi).FullName,
                        MethodArgsCount = 1,
                        MethodName = nameof(MethodApi.TestDb)
                    },
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.MyMethod,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroDatabaseInfo.Id),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name,Value=0, Description = TextHandler.GetCommonTexst("主键", "Id") }
                         }
                };
            });
            zeroInterfaceList.Add(data7);


            //创建数据库
            ZeroInterfaceList data8 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = CreateDatabaseId;
                it.GroupName = nameof(ZeroDatabaseInfo);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(CreateDatabaseId);
                it.Url = GetUrl(it, "CreateDatabaseInfo");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroDatabaseInfo,
                    ActionType = ActionType.DllCreateDb,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = "Connection",   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(string).Name,Value=0, Description = TextHandler.GetCommonTexst("连接字符串", "Connection string") },
                             new DefaultParameter() { Name = "DbType",   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(int).Name,Value=0, Description = TextHandler.GetCommonTexst("库类型", "DbType") }
                         }
                };
            });
            zeroInterfaceList.Add(data8);
        }

        public void GetZeroInterfaceList()
        {
            Intenal();

            Dynamic();

        }

        private void Dynamic()
        {
            //动态测试接口
            ZeroInterfaceList data3 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = TestId;
                it.GroupName = nameof(ZeroInterfaceList);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id200100;
                it.Name = TextHandler.GetInterfaceListText(TestId);
                it.Url = "/MyTest/API";
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceList,
                    ActionType = ActionType.QueryByPrimaryKey,
                    DefaultParameters = new List<DefaultParameter>() {
                            new DefaultParameter(){
                                  Name="Id",
                                  ParameterValidate=new ParameterValidate{
                                  IsRequired=true
                                },
                                FieldOperator=FieldOperatorType.Equal,
                                ValueType=typeof(long).Name,
                                Description=TextHandler.GetCommonTexst("根据主键获取接口","Get interface detail") },
                         }
                };
                it.IsInitialized = false;
            });
            zeroInterfaceList.Add(data3);
        }

        private void Intenal()
        {
            //内部接口列表
            ZeroInterfaceList data = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = IntIntListId;
                it.CustomResultModel = new ResultModel() { ResultType = ResultType.Group, GroupName = nameof(ZeroInterfaceList.GroupName) };
                it.GroupName = nameof(ZeroInterfaceList);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(IntIntListId);
                it.Url = GetUrl(it, "GetInternalInterfaceList");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceList,
                    ActionType = ActionType.QueryCommon,
                    DefaultParameters = new List<DefaultParameter>() {
                            new DefaultParameter(){ Name="InterfaceCategoryId",FieldOperator=FieldOperatorType.In,  ValueType=typeof(long).Name, Description=TextHandler.GetCommonTexst("接口分类Id","Interface Category Id") },
                            new DefaultParameter(){ Name="Name", FieldOperator=FieldOperatorType.Like, ValueType=typeof(string).Name, Description=TextHandler.GetCommonTexst("接口名称","Interface Name") },
                            new DefaultParameter() { Name = "IsInitialized",FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(bool).Name, Description = TextHandler.GetCommonTexst("是否内置数据", "Is initialized") },
                            new DefaultParameter(){ Name="Url",MergeForName="Name",ValueIsReadOnly=true, FieldOperator=FieldOperatorType.Like, ValueType=typeof(string).Name, Description=TextHandler.GetCommonTexst("Url","Url") },
                    }
                };
            });
            zeroInterfaceList.Add(data);

            //内部接口列表详情
            ZeroInterfaceList data2 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = IntDetId;
                it.GroupName = nameof(ZeroInterfaceList);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(IntDetId);
                it.Url = GetUrl(it, "GetInternalDetail");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceList,
                    ActionType = ActionType.QueryByPrimaryKey,
                    DefaultParameters = new List<DefaultParameter>() {
                            new DefaultParameter(){ Name="Id", ParameterValidate=new ParameterValidate{
                             IsRequired=true
                            },FieldOperator=FieldOperatorType.Equal,  ValueType=typeof(long).Name, Description=TextHandler.GetCommonTexst("根据主键获取接口","Get interface detail") },
                         }
                };
            });
            zeroInterfaceList.Add(data2);
        }

        public void GetInterfaceCategory()
        {
            //接口分类树
            ZeroInterfaceList data1 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = IntCateTreeId;
                it.GroupName = nameof(ZeroInterfaceCategory);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100002;
                it.Name = TextHandler.GetInterfaceListText(IntCateTreeId);
                it.Url = GetUrl(it, "GetInterfaceCategoryList");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceCategory,
                    ActionType = ActionType.QueryTree,
                    TreeParameter = new DataModelTreeParameter()
                    {
                        ChildPropertyName = nameof(ZeroInterfaceCategory.SubInterfaceCategories),
                        RootValue = 0,
                        CodePropertyName = nameof(ZeroInterfaceCategory.Id),
                        ParentCodePropertyName = nameof(ZeroInterfaceCategory.ParentId),
                    },
                    DefaultParameters = new List<DefaultParameter>()
                    {
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.Id) ,Value=InterfaceCategoryInitializerProvider.Id,FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name, Description = TextHandler.GetCommonTexst("根目录ID", "Root id") },

                    }
                };
            });
            zeroInterfaceList.Add(data1);


            //获取动态接口分类
            ZeroInterfaceList data2 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = IntCateListId;
                it.GroupName = nameof(ZeroInterfaceCategory);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(IntCateListId);
                it.Url = GetUrl(it, "GetDynamicInterfaceCategoryList");
                it.CustomResultModel = new ResultModel()
                {
                    ResultType = ResultType.Grid
                };
                it.DataModel = new DataModel()
                {
                    CommonPage = new DataModelPageParameter
                    {
                        PageSize = 20,
                        PageNumber = 1
                    },
                    Columns = new List<DataColumnParameter>()
                    {

                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroInterfaceCategory.Id) ,
                            Description=TextHandler.GetCommonTexst("ID", "Primary key")
                        },
                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroInterfaceCategory.Name) ,
                            Description=TextHandler.GetCommonTexst("名称", "Name")
                        },
                       new DataColumnParameter(){
                            PropertyName= nameof(ZeroInterfaceCategory.Description) ,
                            Description=TextHandler.GetCommonTexst("备注", "Description")
                        },
                        new DataColumnParameter(){
                            PropertyName= nameof(ZeroInterfaceCategory.Url) ,
                            Description=TextHandler.GetCommonTexst("跳转地址", "Url")
                        }
                    },
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceCategory,
                    ActionType = ActionType.QueryCommon,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.ParentId),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name,Value=200,ValueIsReadOnly=true, Description = TextHandler.GetCommonTexst("上级Id", "ParentId") },
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.IsDeleted),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(bool).Name,Value="false",ValueIsReadOnly=true, Description = TextHandler.GetCommonTexst("IsDeleted", "IsDeleted") },
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.Name),   FieldOperator=FieldOperatorType.Like,  ValueType = typeof(string).Name,Value=null , Description = TextHandler.GetCommonTexst("名称", "Name") },
                             new DefaultParameter() { Name=nameof(DataModelPageParameter.PageNumber) ,Value=1,FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name, Description = TextHandler.GetCommonTexst("第几页", "Page number") },
                             new DefaultParameter() { Name=nameof(DataModelPageParameter.PageSize) ,Value=20,FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name, Description = TextHandler.GetCommonTexst("每页几条", "Pageize") }
                    }
                };
            });
            zeroInterfaceList.Add(data2);


            //动态接口分类删除
            ZeroInterfaceList data3 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = DeleteCateTreeId;
                it.GroupName = nameof(ZeroInterfaceCategory);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(DeleteCateTreeId);
                it.Url = GetUrl(it, "DeleteDynamicInterfaceCategory");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceCategory,
                    ActionType = ActionType.BizDeleteObject,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.Id),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name,Value=0, Description = TextHandler.GetCommonTexst("主键", "Id") },
                              new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.IsDeleted),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(bool).Name,Value="true", Description = TextHandler.GetCommonTexst("是否删除", "IsDeleted") }
                         }
                };
            });
            zeroInterfaceList.Add(data3);

            //添加动态接口分类
            ZeroInterfaceList data4 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.POST.ToString();
                it.Id = AddCateTreeId;
                it.GroupName = nameof(ZeroInterfaceCategory);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(AddCateTreeId);
                it.Url = GetUrl(it, "AddDynamicInterfaceCategory");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceCategory,
                    ActionType = ActionType.InsertObject,
                    DefaultParameters = new List<DefaultParameter>()
                    {
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.Name) ,ParameterValidate=
                        new ParameterValidate()
                        {
                             IsRequired=true
                        },ValueType = typeof(string).Name },
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.ParentId),Value=InterfaceCategoryInitializerProvider.Id200,ValueIsReadOnly=true,ValueType = typeof(long).Name },
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.Description) ,ValueType = typeof(string).Name },
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.Url),ValueIsReadOnly=true,Value= "/rezero/dynamic_interface.html?InterfaceCategoryId="+PubConst.TreeUrlFormatId,ValueType = typeof(string).Name },
                        DataInitHelper.GetIsDynamicParameter(),
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.Creator),
                        InsertParameter=new InsertParameter(){
                             IsUserName=true
                        },Value="" ,ValueType = typeof(string).Name },

                    }
                };
            });
            zeroInterfaceList.Add(data4);


            //修改动态接口分类
            ZeroInterfaceList data5 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.POST.ToString();
                it.Id = UpdateCateTreeId;
                it.GroupName = nameof(ZeroInterfaceCategory);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(UpdateCateTreeId);
                it.Url = GetUrl(it, "UpdateDynamicInterfaceCategory");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceCategory,
                    ActionType = ActionType.UpdateObject,
                    DefaultParameters = new List<DefaultParameter>()
                    {
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.Id),ValueType = typeof(long).Name },
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.Name) ,ParameterValidate=
                        new ParameterValidate()
                        {
                            IsRequired=true
                        } ,ValueType = typeof(string).Name },
                        new DefaultParameter() { Name=nameof(ZeroInterfaceCategory.Description),ValueType = typeof(string).Name }
                    }
                };
            });
            zeroInterfaceList.Add(data5);


            //动态接口分类根据主键获取详情
            ZeroInterfaceList data6 = GetNewItem(it =>
            {
                it.HttpMethod = HttpRequestMethod.GET.ToString();
                it.Id = GetCateTreeById;
                it.GroupName = nameof(ZeroInterfaceCategory);
                it.InterfaceCategoryId = InterfaceCategoryInitializerProvider.Id100003;
                it.Name = TextHandler.GetInterfaceListText(GetCateTreeById);
                it.Url = GetUrl(it, "GetDynamicInterfaceCategoryById");
                it.DataModel = new DataModel()
                {
                    TableId = EntityInfoInitializerProvider.Id_ZeroInterfaceCategory,
                    ActionType = ActionType.QueryByPrimaryKey,
                    DefaultParameters = new List<DefaultParameter>() {
                             new DefaultParameter() { Name = nameof(ZeroInterfaceCategory.Id),   FieldOperator=FieldOperatorType.Equal,  ValueType = typeof(long).Name,Value=0, Description = TextHandler.GetCommonTexst("主键", "Id") }
                         }
                };
            });
            zeroInterfaceList.Add(data6);
        }
    }
}
