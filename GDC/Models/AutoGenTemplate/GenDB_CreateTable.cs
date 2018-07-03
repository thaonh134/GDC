using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GDC.Models.AutoGenTemplate
{
    public class GenDB_CreateTableModel
    {
        public static List<string> AutoGen(dynamic item)
        {
            string sourcePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/template/Db");
            string targetPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/download/Db");

            var rs = new List<string>();
            rs.Add(GetGenFile(sourcePath, targetPath, "_Table.sql", item));
            return rs;
        }
        public static string GetGenFile(string sourcePath, string targetPath, string extFileName, dynamic item)
        {
            string fileName = item.TableName + extFileName;


            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, "Create_Table.sql");
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
                    .Replace("@=TableName=@", item.TableName.ToString())
                    .Replace("@=Fields=@", GenDBFields(item.Fields))
                    .Replace("@=Pkeys=@", GenPKkeyField(item.Pkeys));
            }
            File.WriteAllText(destFile, fileContent);
            return destFile;
        }

        public static string GenDBFields(dynamic Fields)
        {
            var rs = "";
            if (Fields.Count == 0) return "";
            foreach (var field in Fields)
            {
                rs = rs + GenDBField(field);
            }
            if (rs.Length > 0) rs = rs.Substring(rs.IndexOf(',') + 1);
            return rs;
        }
        public static string GenDBField(dynamic Field)
        {
            string name = Field.name==null?"":Field.name.ToString();
            string type = Field.type == null ? "" : Field.type.ToString();
            string inc = Field.inc == null ? "" : Field.inc.ToString();
            string key = Field.key == null ? "" : Field.key.ToString();
            string lgt = Field.lgt == null ? "" : Field.lgt.ToString();
            string isnull = Field.isnull == null ? "0" : Field.isnull.ToString();

            var outname = "[" + name + "]";
            var outtype = "[" + type + "]";
            var outlgt = "(" + lgt + ")";
            var ontisnull = isnull == "1" ? "NULL " : "NOT NULL " + GetDefaultValue(type);
            var outinc = inc == "1" ? "IDENTITY (1,1)" : "";
            if (new List<string>(new string[] { "nvarchar", "varchar" }).Contains(type.ToString().ToLower())) outtype = outtype + " " + outlgt;


            return System.Environment.NewLine + " ," + outname + " " + outtype + " " + outinc + " " + ontisnull + " " ;

        }
        public static string GetDefaultValue(string type)
        {
            if (type.ToLower() == "nvarchar" || type.ToLower() == "varchar" ) return " DEFAULT ('')";
            else if (type.ToLower() == "datetime" || type.ToLower() == "date") return " DEFAULT (GETDATE())";
            else return " DEFAULT (0)";
        }
        public static string GenPKkeyField(dynamic Pkeys)
        {
            var rs = "";
            if (Pkeys.Count == 0) return "";
            foreach (var pkey in Pkeys)
            {
                rs = rs +  System.Environment.NewLine + "," + "[" + pkey.name.ToString() + "]" ;
            }
            //if (rs.Length > 0) rs = rs.Substring(rs.IndexOf(',') + 1);
            return rs;


        }
    }
}