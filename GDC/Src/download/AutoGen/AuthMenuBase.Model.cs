using ananlips.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
/*AutoGen: ThaoNH*/
namespace ananlips.Areas.Admin.Models.AutoGen
{
	public abstract  class AuthMenuBase<T> where T : AuthMenuBase<T>
    {
	 [AutoIncrement]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
public  string NameVi  { get; set; } 
public  string MenuId  { get; set; } 
public  string ParentMenuId  { get; set; } 
public  int MenuIndex  { get; set; } 
public  string ControllerName  { get; set; } 
public  string Icon  { get; set; } 
public  bool Active  { get; set; } 	
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }

        public DataSourceResult GetPage(DataSourceRequest request, string whereCondition)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Page", request.Page));
            param.Add(new SqlParameter("@PageSize", request.PageSize));
            param.Add(new SqlParameter("@WhereCondition", whereCondition));
            param.Add(new SqlParameter("@Sort", CustomModel.GetSortStringFormRequest(request)));

            var data = new SqlHelper().ExecuteQuery("p_AuthMenu_Search", param);
            request.Page = 1;
            request.Filters = null;
            var result = data.ToDataSourceResult(request);
            result.Total = data.Rows.Count > 0 ? Convert.ToInt32(data.Rows[0]["RowCount"]) : 0;
            return result;
        }

        public List<T> GetExport(DataSourceRequest request, string whereCondition)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Page", 1));
            param.Add(new SqlParameter("@PageSize", CustomModel.GetExportPageSize()));
            param.Add(new SqlParameter("@WhereCondition", whereCondition));
            return CustomModel.ConvertDataTable<T>(new SqlHelper().ExecuteQuery("p_AuthMenu_Search", param));
        }

	}
}