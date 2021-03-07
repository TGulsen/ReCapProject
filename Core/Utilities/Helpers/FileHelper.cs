
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            //gönderilen resmin tüm yolunu (path) getirir:
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                //eklenen resim boş ise, resmin bulunduğu yerde yeni bir dosya oluşturur.dosyaya resmi kaydeder.
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = newPath(file);
            // resmi kaynak dosyadan, yeni oluşturulan path'e taşır:
            File.Move(sourcepath, result);
            return result;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
                return new SuccessResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

         
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

        // yüklenen resme yeni bir dosya yolu yazan mehthod:
        public static string newPath(IFormFile file)
        {
            //Yüklediğimiz resmin ismini alır.

            FileInfo ff = new FileInfo(file.FileName);

            //Yüklediğimiz resmin uzantısını alır: .jpeg, .png vs.
            string fileExtension = ff.Extension;

            //Geçerli çalışma dizininin tam yolunu get-set eder:
            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            //Benzersiz bir path oluşturur:
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            //String ifadedeki /,: boşluk gib ifadeleri - 'ye çevirir:
            string unique = Regex.Replace(newPath, "[/|:| ]", "-");

            //benzersiz path artık hazır:
            string result = $@"{path}\{unique}";

            return result;
        }


    }
}
