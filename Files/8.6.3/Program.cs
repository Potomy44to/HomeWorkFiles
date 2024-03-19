using Application;

string pathTask3 = @"/Users/s.hlestunov/Repositories/FolderWithFilesCopy";

long initialSize = WorkWithFile.GetFolderSize(pathTask3);

Console.WriteLine("Исходный размер папки: " + initialSize + " байт");

WorkWithFile.ClearFolder(pathTask3);
long currentSize = WorkWithFile.GetFolderSize(pathTask3);

Console.WriteLine("Освобождено: " + (initialSize - currentSize) + " байт");
Console.WriteLine("Текущий размер папки: " + WorkWithFile.GetFolderSize(pathTask3) + " байт");