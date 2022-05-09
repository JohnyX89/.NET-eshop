using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models
{
    public class FileUpload
    {
        string RootPath;
        string ContentType;
        string FolderName;

        public FileUpload(string roothPath, string folderName, string contentType)
        {
            this.RootPath = roothPath;
            this.FolderName = folderName;       // nahrada za "Carousels" nebo "Products"
            this.ContentType = contentType;     // nahrada za "image"
        }

        public bool CheckFileContent(IFormFile iFormFile)
        {
            return iFormFile != null && iFormFile.ContentType.ToLower().Contains(ContentType);
        }

        public bool CheckFileLength(IFormFile iFormFile)
        {
            return iFormFile.Length > 0 && iFormFile.Length < 2_000_000;
        }

        public async Task<string> FileUploadAsync(IFormFile iFormFile)
        {
            string filePathOutput = String.Empty;
            var img = iFormFile;

            if (CheckFileContent(iFormFile) && CheckFileLength(iFormFile))    // just img (0 - 2MB) 
            {
                var fileName = Path.GetFileNameWithoutExtension(img.FileName);      // user typed fileName without extension
                var fileExtension = Path.GetExtension(img.FileName);                // user typed fileName (just extension)
                var fileNameGenerated = Path.GetRandomFileName();                   // in case user chose same file again

                var fileRelative = Path.Combine(ContentType + "s", FolderName, fileName + fileExtension);                // composing relative path for saving
                var filePath = Path.Combine(RootPath, fileRelative);   // composing absolute path for saving

                using (var stream = new FileStream(filePath, FileMode.Create))      // FileMode.Create - we wanna create new file
                {
                    await img.CopyToAsync(stream);
                }

                filePathOutput = $"/{fileRelative}";                         // save relative path to imageSrc of just created new file
            }

            return filePathOutput;
        }


        //public async Task<bool> FileUploadAsync(Carousel carousel)
        //{
        //    bool uploadSuccess = false;
        //    var img = carousel.Image;

        //    if (img != null && img.ContentType.ToLower().Contains("image") && img.Length > 0 && img.Length < 2_000_000)    // just img (0 - 2MB) 
        //    {
        //        var fileName = Path.GetFileNameWithoutExtension(img.FileName);      // user typed fileName without extension
        //        var fileExtension = Path.GetExtension(img.FileName);                // user typed fileName (just extension)
        //        var fileNameGenerated = Path.GetRandomFileName();                   // in case user chose same file again

        //        var fileRelative = Path.Combine("images", "Carousels", fileName + fileExtension);                // composing relative path for saving
        //        var filePath = Path.Combine(RootPath, "images", "Carousels", fileName + fileExtension);   // composing absolute path for saving

        //        using (var stream = new FileStream(filePath, FileMode.Create))      // FileMode.Create - we wanna create new file
        //        {
        //            await img.CopyToAsync(stream);
        //        }

        //        carousel.ImageSrc = $"/{fileRelative}";                         // save relative path to imageSrc of just created new file

        //        uploadSuccess = true;
        //    }

        //    return uploadSuccess;
        //}
    }
}
