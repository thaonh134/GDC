using ananlips.Areas.Admin.Models.AutoGen;
using ananlips.Service;
using ServiceStack.OrmLite;
using System;
using System.Data;
namespace ananlips.Areas.Admin.Models
{
    public class User: UserBase<User>
    {
		#region AutoGen
		public static User GetById(int Id)
		{
			IDbConnection dbConn = new OrmliteConnection().openConn();
			try
			{
				var data = dbConn.GetByIdOrDefault<User>(Id);
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