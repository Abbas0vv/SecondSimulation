using SimulationV2.Database.Interfaces;

namespace SimulationV2.Helpers.Extentions;

public static class FileExtention
{
    public static string CreateFile(this IFormFile file, string webRootPath, string folderName)
    {
        string fileName = Guid.NewGuid().ToString() + file.FileName;
        string path = Path.Combine(webRootPath,folderName);
        using(FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        {
            file.CopyTo(stream);
        }
        return fileName;
    }

    public static void RemoveFile(string webRootPath, string folderName, string fileName)
    {
        string path = Path.Combine(webRootPath, folderName);
        if (System.IO.File.Exists(path))
        {
            try
            {
                System.IO.File.Delete(path);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }

    public static string UpdateFile(this IFormFile file, string webRootPath, string folderName,string oldUrl)
    {
        var newImageUrl = file.CreateFile(webRootPath, folderName);
        RemoveFile(webRootPath, folderName, oldUrl);
        return newImageUrl;
    }

    public static bool IsValidFile(this IFormFile file)
    {
        if (file is null) return false;
        if (!file.FileName.Contains("image")) return false;
        if (file.Length > 2000000) return false;

        return true;
    }

    public static string GetImageUrl(this IFormFile file)
    {
        return file.FileName;
    }
}
