using System.Collections.Concurrent;
using ACadWithLibrery.ACadSharp.Abstraction;

namespace ACadWithLibrery.ACadSharp.Service;

public class PathCollections : IEndPathSearcher {
    public IEnumerable<string> SearchFullPath(string startPath, string fileExtension = "*.dwg") {
        var dwgFiles = new List<string>();
        var stack = new Stack<string>();
        stack.Push(startPath);

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

        return dwgFiles;
    }

    public async Task<IEnumerable<string>> SearchFullPathAsync(string startPath, string fileExtension = "*.dwg") {
        var dwgFiles = new ConcurrentBag<string>();
        var stack = new Stack<string>();
        stack.Push(startPath);

        while (stack.Count > 0) {
            string currentPath = stack.Pop();

            string[] files = await Task.Run(() => Directory.GetFiles(currentPath, fileExtension));

            Parallel.ForEach(files, file => { dwgFiles.Add(file); });

            string[] directories = await Task.Run(() => Directory.GetDirectories(currentPath));

            Parallel.ForEach(directories, directory => { stack.Push(directory); });
        }

        return dwgFiles;
    }
}