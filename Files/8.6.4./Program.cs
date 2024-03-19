string pathTask4 = @"/Users/s.hlestunov/Repositories/Students";
string filePath = @"/Users/s.hlestunov/Repositories/students.dat";

List<Student> studentsList = new List<Student>
{
    new Student { Name = "Жульен", Group = "G1", DateOfBirth = new DateTime(2001, 10, 22), AverageScore = 3.3M },
    new Student { Name = "Боб", Group = "G1", DateOfBirth = new DateTime(1999, 5, 25), AverageScore = 4.5M},
    new Student { Name = "Лилия", Group = "F2", DateOfBirth = new DateTime(1999, 1, 11), AverageScore = 5M},
    new Student { Name = "Роза", Group = "F2", DateOfBirth = new DateTime(1989, 9, 19), AverageScore = 3.7M}
};

if (!Directory.Exists(pathTask4))
{
    Directory.CreateDirectory(pathTask4);
}

WriteFile(studentsList, filePath);
DisplayData(filePath);

static void WriteFile(List<Student> students, string file)
{
    if (File.Exists(file))
    {
        using (var stream = File.Open(file, FileMode.Create))
        {
            using (var writer = new BinaryWriter(stream))
            {
                foreach (Student student in students)
                {
                    writer.Write(student.Name);
                    writer.Write(student.Group);
                    writer.Write(student.DateOfBirth.ToBinary());
                    writer.Write(student.AverageScore);
                }
            }
        }
    }
    else
    {
        Console.WriteLine("Файл не найден");
    }

}

static void DisplayData(string file)
{
    if (File.Exists(file))
    {
        using (var stream = File.Open(file, FileMode.Open))
        {
            using (var reader = new BinaryReader(stream))
            {

                while (stream.Position < stream.Length)
                {
                    Student student = new Student();
                    student.Name = reader.ReadString();
                    student.Group = reader.ReadString();
                    long dt = reader.ReadInt64();
                    student.DateOfBirth = DateTime.FromBinary(dt);
                    student.AverageScore = reader.ReadDecimal();

                    Console.WriteLine("Имя: " + student.Name + ", Группа: " + student.Group + ", Дата рождения: " + student.DateOfBirth.ToShortDateString() + ", Средний балл: " + student.AverageScore);
                }

            }
        }
    }
    else
    {
        Console.WriteLine("Файл не найден");
    }

}

class Student
{
    public string Name { get; set; }
    public string Group { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal AverageScore { get; set; }
}