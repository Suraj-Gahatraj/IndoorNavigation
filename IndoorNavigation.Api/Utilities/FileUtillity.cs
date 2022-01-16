namespace IndoorNavigation.Api.Utilities
{
    public static class FileUtility
    {
        public static string GetSiteMarkerUploadPath(string siteId,string markerName,out string fileName)
        {
            var storagePath = Path.Combine(Environment.CurrentDirectory + "\\uploads\\SiteMarkerImageUploads\\"+siteId);
            fileName = siteId + "_" + markerName+"_" + DateTime.Now.Millisecond.ToString();
            return storagePath;
        }


        public static string GetExtension(this string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return string.IsNullOrEmpty(extension) ? string.Empty : extension.Replace(".", string.Empty).ToLower();
        }


        public static async Task Upload(MemoryStream ms, string filePath)
        {

        }

        public static async Task Upload(IFormFile file,string filePath,string fileName)
        {
            var extension = file.FileName.GetExtension();
            var directoryNotExist=!Directory.Exists(filePath);
            if (directoryNotExist)
            {
                Directory.CreateDirectory(filePath);    
            }

            filePath = Path.Combine(filePath, fileName+"_."+extension);
            using (var fileStream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(fileStream);
            }

        }
    }

}
