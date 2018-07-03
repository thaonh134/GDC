using ananlips.Areas.Admin.Models.AutoGen;
using ananlips.Service;
using ServiceStack.OrmLite;
using System;
using System.Data;
namespace ananlips.Areas.Admin.Models
{
    public class AuthMenu: AuthMenuBase<AuthMenu>
    {
		#region AutoGen
		public static AuthMenu GetById(int Id)
		{
			IDbConnection dbConn = new OrmliteConnection().openConn();
			try
			{
				var data = dbConn.GetByIdOrDefault<AuthMenu>(Id);
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