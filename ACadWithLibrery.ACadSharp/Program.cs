using ACadSharp;
using ACadSharp.Entities;
using ACadSharp.IO;

namespace ACadWithLibrery.ACadSharp;

public class Program {
    private static void onNotification(object sender, NotificationEventArgs e) {
        Console.WriteLine(e.Message);
    }

    public static void Main() {
        string path = "C:\\Users\\shado\\OneDrive\\Desktop";
        List<string> dwgFiles = new();
        CollectDwgFiles(path, dwgFiles);
        Console.WriteLine("Middle files: ");
        dwgFiles.Remove(path);
        foreach (string file in dwgFiles) {
            Console.WriteLine(file);
            if (!file.Contains("path"))
                SearchInFile(file);
        }

        Console.ReadKey();
    }

    private static void SearchInFile(string path) {
        CadDocument doc = DwgReader.Read(path);
        var entities = doc.Entities;
        // foreach (var e in entities.GroupBy(i => i.GetType().FullName))
        // {
        //     Console.WriteLine($"\t\t{e.Key}: {e.Count()}");
        // }
        var textEntities = doc.Entities.OfType<TextEntity>();
        Dictionary<string, string> textDictionary = new();
        foreach (var e in textEntities) {
            //Console.WriteLine($"\t\t{e.ObjectName}: {e.Value}");
            if (textDictionary.TryAdd(e.Value, e.Value)) {
                if (e.Value.Equals("273,1х9,3-PW-10-1003-C-РР-2.5")) {
                    Console.WriteLine(path + " ----> " + e.Value);
                }
            }
        }
    }

    public static void CollectDwgFiles(string path, List<string> dwgFiles) {
        Stack<string> stack = new Stack<string>();
        stack.Push(path);

        while (stack.Count > 0) {
            string currentPath = stack.Pop();

            string[] files = Directory.GetFiles(currentPath, "*.dwg");
            foreach (string file in files) {
                dwgFiles.Add(file);
            }

            string[] directories = Directory.GetDirectories(currentPath);
            foreach (string directory in directories) {
                stack.Push(directory);
            }
        }
    }
}