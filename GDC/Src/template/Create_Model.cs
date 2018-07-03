using @=ProjectName=@.@=NameSpace=@.Models.AutoGen;
using @=ProjectName=@.Service;
using ServiceStack.OrmLite;
using System;
using System.Data;
namespace @=ProjectName=@.@=NameSpace=@.Models
{
    public class @=TableName=@: @=TableName=@Base<@=TableName=@>
    {
		#region AutoGen
		public static @=TableName=@ GetById(int Id)
		{
			IDbConnection dbConn = new OrmliteConnection().openConn();
			try
			{
				var data = dbConn.GetByIdOrDefault<@=TableName=@>(Id);
				return data;
			}
			catch (Exception e)
			{
				return null;
			}
			finally { dbConn.Close(); }
		}
		
		#endregion
    }
}