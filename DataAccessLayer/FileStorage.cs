using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class FileStorage
    {
        public static string GetFilePathForUser(string folderName)
        {
            string filePath = "";
            // 1. Get the path to the current user's "my Documents" folder.
            // This returns a path like "C:\Users\Username\Documents"
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // 2. Define the name for your application's specific folder.
            string appFolderName = folderName;
            // 3. Combine the paths to get the full target directory path.
            filePath = Path.Combine(myDocumentsPath, appFolderName);
            // 4. Check if the directory already exists
            if (!Directory.Exists(filePath))
            {
                try
                {
                    // 5. Create the directory if it does not exist.
                    Directory.CreateDirectory(filePath);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return filePath;
        }
    }
}
