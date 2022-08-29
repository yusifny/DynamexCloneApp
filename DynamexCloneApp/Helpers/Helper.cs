using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DynamexCloneApp.Helpers
{
    public class Helper
    {
        public static void DeleteFile(IWebHostEnvironment env, string folder1, string folder2, string folder3, string filename)
        {
            string path = env.WebRootPath;
            string resultPath = Path.Combine(path, folder1, folder2, folder3, filename);

            if (System.IO.File.Exists(resultPath))
            {
                System.IO.File.Delete(resultPath);
            }
        }
    }
}