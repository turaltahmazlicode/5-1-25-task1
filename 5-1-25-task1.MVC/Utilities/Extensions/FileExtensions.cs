using System.Threading.Tasks;

namespace _5_1_25_task1.MVC.Utilities.Extensions;

public static class FileExtensions
{
    public static async Task<string> UploadFileAsync(this IFormFile file, string rootPath, string folderName)
    {
        string fileName = file.FileName;

        if (fileName.Length > 64)
            fileName = fileName[^64..];

        fileName = Guid.NewGuid() + fileName;

        using FileStream fs = new FileStream(Path.Combine(rootPath, folderName, fileName), FileMode.Create);

        await file.CopyToAsync(fs);

        return fileName;
    }

    public static bool DeleteFile(string rootPath, string folderName, string fileName)
    {
        string path = Path.Combine(rootPath, folderName, fileName);
        if (!File.Exists(path))
            return false;

        File.Delete(path);
        return true;
    }
}
