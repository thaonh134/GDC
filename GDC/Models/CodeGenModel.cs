using GDC.Models.AutoGenTemplate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GDC.Models
{
    public class CodeGenModel
    {
        public static List< string> AutoGenDB(dynamic item)
        {
          
            return GenDB_CreateTableModel.AutoGen(item);
        }
        public static List<string> AutoGenModel(dynamic item)
        {

            return GenFile_Model.AutoGen(item);
        }
    }

}