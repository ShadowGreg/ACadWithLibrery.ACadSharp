using ACadSharp;

namespace ACadWithLibrery.ACadSharp.Abstraction; 

public interface ISearchTextInFile {
    /// <summary>
    /// Возвращает адрес файла и текст в нём
    /// </summary>
    /// <param name="cadDocument"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    public Dictionary<string, string> SearchTextInFile(CadDocument cadDocument, ITextSearchInFiles e);
}