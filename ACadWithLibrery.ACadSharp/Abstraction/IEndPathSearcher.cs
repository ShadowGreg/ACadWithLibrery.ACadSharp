namespace ACadWithLibrery.ACadSharp.Abstraction;

public interface IEndPathSearcher {
    public IEnumerable<string> SearchFullPath(string startPath, string fileExtension);
    public Task<IEnumerable<string>> SearchFullPathAsync(string startPath, string fileExtension = "*.dwg");
}