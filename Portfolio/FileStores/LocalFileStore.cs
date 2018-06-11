using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Portfolio.FileStores
{
    public class LocalFileStore : IFileStore 
    {
        public string Store(HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);
            string dir = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Images/");
            string path = Path.Combine(dir, fileName);

            file.SaveAs(path);

            return fileName;
        }
    }
}