namespace Application
{
	public class WorkWithFile
	{
        public static void ClearFolder(string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);

            if (folder.Exists)
            {
                try
                {
                    var files = folder.GetFiles();
                    foreach (var file in files)
                    {
                        if (CheckTimeOfUse(file))
                            file.Delete();
                    }
                    foreach (var dir in folder.GetDirectories())
                    {
                        ClearFolder(dir.FullName);
                        if (CheckTimeOfUse(dir) && (dir.GetFiles().Length == 0 && dir.GetDirectories().Length == 0))
                            dir.Delete(true);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
            else
                Console.WriteLine("Папка не существует");
        }

        public static bool CheckTimeOfUse(FileSystemInfo item)
        {
            bool result;
            DateTime now = DateTime.Now;
            DateTime last = item.LastAccessTime;
            TimeSpan timeInterval = TimeSpan.FromMinutes(1);
            TimeSpan difference = now.Subtract(last);
            if (difference > timeInterval)
                result = true;
            else
                result = false;
            return result;
        }

        public static long GetFolderSize(string dirName)
        {
            long sizeSum = 0;
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (dir.Exists)
            {
                try
                {
                    var files = dir.GetFiles();
                    foreach (var file in files)
                    {
                        sizeSum += file.Length;
                    }
                    foreach (var di in dir.GetDirectories())
                    {
                        sizeSum += GetFolderSize(di.FullName);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
            else
                Console.WriteLine("Папка не существует");

            return sizeSum;
        }
    }
}

