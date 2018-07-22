using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GDC.Models.AutoGenTemplate
{
    public class GenFile_ViewTree
    {
        public static List<string> AutoGen(dynamic item)
        {
            string sourcePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/template");
            string targetPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Src/download/Views");
            var rs = new List<string>();
            rs.Add(GetGenFile(sourcePath, targetPath, "Tree.cshtml", item));
            return rs;
        }
        public static string GetGenFile(string sourcePath, string targetPath, string extFileName, dynamic item)
        {
            string fileName = item.controllername + extFileName;
            targetPath = Path.Combine(targetPath, item.menuname.ToString() + item.controllername.ToString());
            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, "Create_ViewTree.cshtml");
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
                    .Replace("@=areasname=@", item.areasname.ToString())
                    .Replace("@=menuname=@", item.menuname.ToString())
                    .Replace("@=controllername=@", item.controllername.ToString())
                    //.Replace("@=fields=@", GenDBfields(item.fields))
                    //.Replace("@=pkeys=@", GenPKkeyfield(item.pkeys))
                    ;
            }
            File.WriteAllText(destFile, fileContent);
            return destFile;
        }
        #region GenDbFields

        #endregion



    }
}