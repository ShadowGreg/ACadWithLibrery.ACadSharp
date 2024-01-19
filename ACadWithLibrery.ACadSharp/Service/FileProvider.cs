using ACadSharp;
using ACadSharp.IO;
using ACadWithLibrery.ACadSharp.Abstraction;

namespace ACadWithLibrery.ACadSharp.Service;

public class FileProvider : IFileProvider {
    public CadDocument GetCadDocument<TE>(string filePath) where TE : ICadReader {
        CadDocument getCadDocument = new CadDocument();
        try {
            using FileStream fileStream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite);
            getCadDocument = DwgReader.Read(fileStream);
        }
        catch (Exception ex) {
            Console.WriteLine("Error loading log file: " + ex.Message);
        }

        return getCadDocument;
    }
}