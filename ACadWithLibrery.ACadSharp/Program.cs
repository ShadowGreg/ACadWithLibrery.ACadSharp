using ACadSharp;
using ACadSharp.Entities;
using ACadSharp.IO;

namespace ACadWithLibrery.ACadSharp;

public class Program
{
    private static void onNotification(object sender, NotificationEventArgs e)
    {
        Console.WriteLine(e.Message);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(
            "Input path and text for search between spaces. For example: C:\\Users\\shado\\OneDrive\\Desktop 273,1х9,3-PW-10-1003-C-РР-2.5 >");
        args = Console.ReadLine().Split(" ");
        if (args.Length == 2)
        {
            string path = args[0];
            List<string> dwgFiles = new();
            CollectDwgFiles(path, dwgFiles);
            Console.WriteLine("Middle files: ");

            foreach (string file in dwgFiles)
            {
                Console.Write("-");
                if (!file.Contains("path"))
                    SearchInFile(file, args[1]);
            }

            Console.ReadKey();
        }

        Console.WriteLine("Not enough arguments. Restart the program");
    }

    private static void SearchInFile(string path, string text = "273,1х9,3-PW-10-1003-C-РР-2.5")
    {
        try
        {

            CadDocument doc = DwgReader.Read(path);

            var entities = doc.Entities;
           
            var textEntities = doc.Entities.OfType<TextEntity>();
            Dictionary<string, string> textDictionary = new();
            foreach (var e in textEntities)
            {
                //Console.WriteLine($"\t\t{e.ObjectName}: {e.Value}");
                if (textDictionary.TryAdd(e.Value, e.Value))
                {
                    if (e.Value.Contains(text))
                    {
                        Console.WriteLine(path + " ----> " + e.Value);
                    }
                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void CollectDwgFiles(string path, List<string> dwgFiles)
    {
        Stack<string> stack = new Stack<string>();
        stack.Push(path);

        while (stack.Count > 0)
        {
            string currentPath = stack.Pop();

            string[] files = Directory.GetFiles(currentPath, "*.dwg");
            foreach (string file in files)
            {
                dwgFiles.Add(file);
            }

            string[] directories = Directory.GetDirectories(currentPath);
            foreach (string directory in directories)
            {
                stack.Push(directory);
            }
        }
    }
}