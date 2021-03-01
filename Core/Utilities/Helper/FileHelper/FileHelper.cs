
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper.FileHelper
{
   public class FileHelper
    {

        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
            }
            var result = newPath(file);
            File.Move(sourcepath, result);
            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;//extension uzantı demek dosyanın uzantısını aldım png, jpeg gibi düşünün
            
            string path = Environment.CurrentDirectory + @"\Images\carImages"; // Environment.CurrentDirectory geçerli çalışma dizininin tam yolunu alır veya ayarlar
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            //  Guid bilgisayar yazılımlarında tanımlayıcı olarak kullanılan benzersiz bir referans numarasıdır
           
            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
