using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GDC.Models.AutoGenTemplate
{
    public class GenDB_QuerySelect
    {
        public static List<string> AutoGen(dynamic item)
        {
            string sourcePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/template/Db");
            string targetPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/download/Db");

            var rs = new List<string>();
            rs.Add(GetGenFile(sourcePath, targetPath, "_Search.sql", item));
            return rs;
        }
        public static string GetGenFile(string sourcePath, string targetPath, string extFileName, dynamic item)
        {
            string fileName = "p_"+ item.tablename + extFileName;


            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, "Create_QuerySelect.sql");
            string destFile = Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            File.Copy(sourceFile, destFile, true);

            var fileContent = "";
            using (var sr = File.OpenText(destFile))
            {
                fileContent = sr.ReadToEnd();
                fileContent = fileContent
                    .Replace("@=tablename=@", item.tablename.ToString())
                    .Replace("@=fields=@", GenDBfields(item.fields))
                    .Replace("@=pkeys=@", GenPKkeyfield(item.pkeys));
            }
            File.WriteAllText(destFile, fileContent);
            return destFile;
        }

        public static string GenDBfields(dynamic fields)
        {
            var rs = "";
            if (fields.Count == 0) return "";
            foreach (var field in fields)
            {
                rs = rs + GenDBfield(field);
            }
            if (rs.Length > 0) rs = rs.Substring(rs.IndexOf(',') + 1);
            return rs;
        }
        public static string GenDBfield(dynamic field)
        {
            string name = field.name == null ? "" : field.name.ToString();
            string type = field.type == null ? "" : field.type.ToString();
            string inc = field.inc == null ? "" : field.inc.ToString();
            string key = field.key == null ? "" : field.key.ToString();
            string lgt = field.lgt == null ? "" : field.lgt.ToString();
            string isnull = field.isnull == null ? "0" : field.isnull.ToString();

            var outname = "[" + name + "]";
            var outtype = "[" + type + "]";
            var outlgt = "(" + lgt + ")";
            var ontisnull = isnull == "1" ? "NULL " : "NOT NULL " + GetDefaultValue(type);
            var outinc = inc == "1" ? "IDENTITY (1,1)" : "";
            if (new List<string>(new string[] { "nvarchar", "varchar" }).Contains(type.ToString().ToLower())) outtype = outtype + " " + outlgt;


            return System.Environment.NewLine + " ," + outname ;

        }
        public static string GetDefaultValue(string type)
        {
            if (type.ToLower() == "nvarchar" || type.ToLower() == "varchar") return " DEFAULT ('')";
            else if (type.ToLower() == "datetime" || type.ToLower() == "date") return " DEFAULT (GETDATE())";
            else return " DEFAULT (0)";
        }
        public static string GenPKkeyfield(dynamic pkeys)
        {
            var rs = "";
            if (pkeys.Count == 0) return "";
            foreach (var pkey in pkeys)
            {
                rs = rs + "," +  pkey.name.ToString() + " ";
            }
            //if (rs.Length > 0) rs = rs.Substring(rs.IndexOf(',') + 1);
            return rs;


        }
    }
}