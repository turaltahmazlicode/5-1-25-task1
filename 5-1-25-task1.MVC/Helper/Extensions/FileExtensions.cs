using System.Text;

namespace _5_1_25_task1.MVC.Helper.Extensions;

public static class FileExtensions
{
    public static string Upload(this IFormFile file, string rootPath, string folderName)
    {
        string fileName = file.FileName;

        if (fileName.Length > 64)
            fileName = fileName[^64..];

        fileName = $"{Guid.NewGuid()}_{fileName}";

        string path = Path.Combine(rootPath, folderName, fileName);
        Console.WriteLine(path);
        using FileStream fs = new FileStream(path, FileMode.Create);
        file.CopyTo(fs);

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
