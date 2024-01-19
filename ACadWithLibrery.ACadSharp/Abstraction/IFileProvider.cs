using ACadSharp;
using ACadSharp.IO;

namespace ACadWithLibrery.ACadSharp.Abstraction;

public interface IFileProvider {
    public CadDocument GetCadDocument<T>(string filePath) where T : ICadReader;
}