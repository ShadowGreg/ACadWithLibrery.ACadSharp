namespace ACadWithLibrery.ACadSharp.Abstraction;

public interface ITextSearchInFiles {
    /// <summary>
    /// Адрес поиска
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public string? SearchInFile(string text);
}