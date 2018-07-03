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
            string targetPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/download");
            var rs = new List<string>();
            rs.Add(GetGenFileBase(sourcePath, targetPath, ".Model.cs", item));
            rs.Add(GetGenFile(sourcePath, targetPath, ".Model.cs", item));
            return rs;
        }
        public static string GetGenFileBase(string sourcePath, string targetPath,string extFileName, dynamic item)
        {
            string fileName = item.TableName+ "Base" + extFileName;
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
                    .Replace("@=ProjectName=@", item.ProjectName.ToString())
                    .Replace("@=NameSpace=@", item.NameSpace.ToString())
                    .Replace("@=TableName=@", item.TableName.ToString())
                    .Replace("@=Fields=@", GenDBFields(item.Fields))
                    //.Replace("@=Pkeys=@", GenPKkeyField(item.Pkeys))
                    ;
            }
            File.WriteAllText(destFile, fileContent);
            return destFile;
        }
        public static string GetGenFile(string sourcePath, string targetPath, string extFileName, dynamic item)
        {
            string fileName = item.TableName + extFileName;

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
                    .Replace("@=ProjectName=@", item.ProjectName.ToString())
                    .Replace("@=NameSpace=@", item.NameSpace.ToString())
                    .Replace("@=TableName=@", item.TableName.ToString());
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
            //if (rs.Length > 0) rs = rs.Substring(rs.IndexOf(',') + 1);
            return rs;
        }
        public static string GenDBField(dynamic Field)
        {
            string name = Field.name == null ? "" : Field.name.ToString();
            string type = Field.type == null ? "" : Field.type.ToString();
            //string inc = Field.inc == null ? "" : Field.inc.ToString();
            //string key = Field.key == null ? "" : Field.key.ToString();
            //string lgt = Field.lgt == null ? "" : Field.lgt.ToString();
            //string isnull = Field.isnull == null ? "0" : Field.isnull.ToString();

            var outname = "[" + name + "]";
            var outtype = "[" + type + "]";
            //var outlgt = "(" + lgt + ")";
            //var ontisnull = isnull == "1" ? "NULL" : "NOT NULL";
            //var outinc = inc == "1" ? "IDENTITY (1,1)" : "";
            //if (new List<string>(new string[] { "nvarchar", "varchar" }).Contains(type.ToString().ToLower())) outtype = outtype + " " + outlgt;


            return System.Environment.NewLine + "public " + GetDefaultValue (type) + name + " "  + " { get; set; } ";

        }
        public static string GetDefaultValue(string type)
        {
            if (type.ToLower() == "nvarchar" || type.ToLower() == "varchar") return " string ";
            else if (type.ToLower() == "datetime" || type.ToLower() == "date") return " DateTime ";
            else if (type.ToLower() == "int"  ) return " int ";
            else if (type.ToLower() == "bit") return " bool ";
            //else if (type.ToLower() == "bit") return " bool ";
            else return "xxx";
        }
        //public static string GenPKkeyField(dynamic Pkeys)
        //{
        //    var rs = "";
        //    if (Pkeys.Count == 0) return "";
        //    foreach (var pkey in Pkeys)
        //    {
        //        rs = rs + System.Environment.NewLine + "," + "[" + pkey.name.ToString() + "]";
        //    }
        //    if (rs.Length > 0) rs = rs.Substring(rs.IndexOf(',') + 1);
        //    return rs;


        //}
    }
}