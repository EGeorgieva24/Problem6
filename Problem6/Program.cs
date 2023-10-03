class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter student's name: ");
        string studentName = Console.ReadLine();

        string baseDirectory = $"D:\\Programming guysss";

        DirectoryInfo studentDirectory = new DirectoryInfo(Path.Combine(baseDirectory, "Student"));

        if (!studentDirectory.Exists)
        {
            studentDirectory.Create();
        }

        string studentFilePath = Path.Combine(studentDirectory.FullName, studentName + ".txt");

        // Prompt the user for student details
        Console.WriteLine("Enter student details:");
        Console.Write("Enter student ID: ");
        string studentID = Console.ReadLine();
        Console.Write("Enter student email: ");
        string studentEmail = Console.ReadLine();

        // Save student information to the file
        using (StreamWriter writer = File.CreateText(studentFilePath))
        {
            writer.WriteLine("Name: " + studentName);
            writer.WriteLine("ID: " + studentID);
            writer.WriteLine("Email: " + studentEmail);
        }

        Console.WriteLine("Student information saved successfully.");

        // Print the content of the saved file using StreamReader
        Console.WriteLine("\nContent of the saved file:");
        using (StreamReader reader = File.OpenText(studentFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        // View directory details
        Console.WriteLine("\nDirectory details:");
        Console.WriteLine($"Directory Name: {studentDirectory.Name}");
        Console.WriteLine($"Directory Path: {studentDirectory.FullName}");
        Console.WriteLine($"Number of Files: {studentDirectory.GetFiles().Length}");

        Console.ReadLine(); // Wait for user input to exit
    }
}
