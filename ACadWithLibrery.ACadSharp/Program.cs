using System.Collections.Concurrent;
using ACadSharp;
using ACadSharp.Entities;
using ACadSharp.IO;
using ACadWithLibrery.ACadSharp.Service;

namespace ACadWithLibrery.ACadSharp;

public class Program {
    public static void Main(string[] args) {
        string? path = Prompt("Введите адрес для поиска >");
        string? text = Prompt("Введите поисковый запрос >");

        var pathCollections = new PathCollections();
        var pathes = pathCollections.SearchFullPathAsync(path).Result;
        var dwgFiles = new ConcurrentDictionary<string, string>();

        Parallel.ForEach(pathes, path =>
        {
            var fileProvider = new FileProvider();
            var cadDocument = fileProvider.GetCadDocument<DwgReader>(path);
            var textEntities = cadDocument.Entities.OfType<TextEntity>();
            var textEntitySearch = new TextEntitySearch(textEntities);
            var value = textEntitySearch.SearchInFile(text);
            if (value != null) dwgFiles.TryAdd(path, value);
        });

        foreach (var variable in dwgFiles) {
            Console.WriteLine($"{variable.Key}  ---> {variable.Value}");
        }
    }

    public static string? Prompt(string msg) {
        Console.WriteLine(msg);
        return Console.ReadLine();
    }
}