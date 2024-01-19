using ACadSharp;
using ACadSharp.Entities;
using ACadSharp.IO;

namespace ACadWithLibrery.ACadSharp;

public class Program {
    public static void Main(string[] args) {
        SearchInFile(null, null);
        Console.WriteLine("Not enough arguments. Restart the program");
    }


    private static void SearchInFile(
        string? path,
        string? text
    ) {
        try {
            if (path == null && text == null) {
                path =
                    "Z:\\ПРОЕКТЫ\\_2023\\03-23-01\\Проработка\\ЭТО\\Изометрии\\4550.50.GS00.008.0155.362675.20.133AI.Sh01-37.Rev_a0 ТОП-11, ТКМ-11 ТКМ-11_1.dwg";
                text = "СМ.ЛИСТ 30";
            }

            Console.ReadKey();
            CadDocument doc = DwgReader.Read(path);

            var entities = doc.Entities;

            var textEntities = doc.Entities.OfType<TextEntity>();
            Dictionary<string, string> textDictionary = new();
            foreach (var e in textEntities) {
                //Console.WriteLine($"\t\t{e.ObjectName}: {e.Value}");
                if (textDictionary.TryAdd(e.Value, e.Value)) {
                    if (e.Value.Contains(text)) {
                        Console.WriteLine(path + " ----> " + e.Value);
                    }
                }
            }
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}