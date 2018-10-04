using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GDC.Models.AutoGenTemplate
{
    public class GenFile_Model
    {
        public static List<string> AutoGen(dynamic item)
        {
            string sourcePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/template");
            string targetPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/download/Models");
            var rs = new List<string>();
            rs.Add(GetGenFileBase(sourcePath, targetPath, ".Model.cs", item));
            rs.Add(GetGenFile(sourcePath, targetPath, ".Model.cs", item));
            return rs;
        }
        public static string GetGenFileBase(string sourcePath, string targetPath,string extFileName, dynamic item)
        {
            string fileName = item.tablename+ "Base" + extFileName;
            targetPath = Path.Combine(targetPath, "AutoGen");
            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, "Create_ModelBase.cs");
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
                    .Replace("@=projectname=@", item.projectname.ToString())
                    .Replace("@=namespacename=@", item.namespacename.ToString())
                    .Replace("@=tablename=@", item.tablename.ToString())
                    .Replace("@=fields=@", GenDBfields(item.fields))
                    //.Replace("@=pkeys=@", GenPKkeyfield(item.pkeys))
                    ;
            }
            File.WriteAllText(destFile, fileContent);
            return destFile;
        }
        public static string GetGenFile(string sourcePath, string targetPath, string extFileName, dynamic item)
        {
            string fileName = item.tablename + extFileName;

            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, "Create_Model.cs");
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
                    .Replace("@=projectname=@", item.projectname.ToString())
                    .Replace("@=namespacename=@", item.namespacename.ToString())
                    .Replace("@=tablename=@", item.tablename.ToString())
                    .Replace("@=fields=@", GenCustomfields(item.fields));
            }
            File.WriteAllText(destFile, fileContent);
            return destFile;
        }
        #region GenDbFields
        public static string GenDBfields(dynamic fields)
        {
            var rs = "";
            if (fields.Count == 0) return "";
            foreach (var field in fields)
            {
                rs = rs + GenDBfield(field);
            }
            //if (rs.Length > 0) rs = rs.Substring(rs.IndexOf(',') + 1);
            return rs;
        }
        public static string GenDBfield(dynamic field)
        {
            string name = field.name == null ? "" : field.name.ToString();
            string type = field.type == null ? "" : field.type.ToString();
            //string inc = field.inc == null ? "" : field.inc.ToString();
            //string key = field.key == null ? "" : field.key.ToString();
            //string lgt = field.lgt == null ? "" : field.lgt.ToString();
            //string isnull = field.isnull == null ? "0" : field.isnull.ToString();

            var outname = "[" + name + "]";
            var outtype = "[" + type + "]";
            //var outlgt = "(" + lgt + ")";
            //var ontisnull = isnull == "1" ? "NULL" : "NOT NULL";
            //var outinc = inc == "1" ? "IDENTITY (1,1)" : "";
            //if (new List<string>(new string[] { "nvarchar", "varchar" }).Contains(type.ToString().ToLower())) outtype = outtype + " " + outlgt;


            return System.Environment.NewLine + "public " + GetDefaultValue(type) + name + " " + " { get; set; } ";

        }
        public static string GetDefaultValue(string type)
        {
            if (type.ToLower() == "nvarchar" || type.ToLower() == "varchar") return " string ";
            else if (type.ToLower() == "datetime" || type.ToLower() == "date") return " DateTime ";
            else if (type.ToLower() == "int") return " int ";
            else if (type.ToLower() == "bit") return " bool ";
            else if (type.ToLower() == "float") return " double ";
            //else if (type.ToLower() == "bit") return " bool ";
            else return "xxx";
        }
        #endregion

        #region GenCustomField
        public static string GenCustomfields(dynamic fields)
        {
            var rs = "";
            if (fields.Count == 0) return "";
            foreach (var field in fields)
            {
                rs = rs + GenCustomfield(field);
            }
            //if (rs.Length > 0) rs = rs.Substring(rs.IndexOf(',') + 1);
            return rs;
        }
        public static string GenCustomfield(dynamic field)
        {
            string name = field.name == null ? "" : field.name.ToString();
            string type = field.type == null ? "" : field.type.ToString();
            //string inc = field.inc == null ? "" : field.inc.ToString();
            //string key = field.key == null ? "" : field.key.ToString();
            //string lgt = field.lgt == null ? "" : field.lgt.ToString();
            //string isnull = field.isnull == null ? "0" : field.isnull.ToString();

            var outname = "[" + name + "]";
            var outtype = "[" + type + "]";
            //var outlgt = "(" + lgt + ")";
            //var ontisnull = isnull == "1" ? "NULL" : "NOT NULL";
            //var outinc = inc == "1" ? "IDENTITY (1,1)" : "";
            //if (new List<string>(new string[] { "nvarchar", "varchar" }).Contains(type.ToString().ToLower())) outtype = outtype + " " + outlgt;


            return GetDefaultValueCustomfield(name, type);

        }
        public static string GetDefaultValueCustomfield(string name,string type)
        {
            
            if (type.ToLower() == "datetime" || type.ToLower() == "date") return System.Environment.NewLine + "[Ignore]" +  System.Environment.NewLine + "public string " + name+"_str "+  " { get; set; } ";
            else return "";
        }
        #endregion

    }
}