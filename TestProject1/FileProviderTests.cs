using ACadSharp;
using ACadSharp.IO;
using ACadWithLibrery.ACadSharp.Service;

namespace TestProject1;

public class FileProviderTests {
    [Fact]
    public void GetCadDocument_ShouldReturnCadDocument() {
        // Arrange
        var fileProvider = new FileProvider();
        var filePath = "C:\\workspace\\ACadWithLibrery.ACadSharp\\TestProject1\\Static\\Изометрии\\4550.50.GS00.008.0155.362675.20.133AI.Sh01-37.Rev_a0 ТОП-11, ТКМ-11 ТКМ-11_1.dwg";

        // Act
        var result = fileProvider.GetCadDocument<DwgReader>(filePath);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CadDocument>(result);
    }

    [Fact]
    public void GetCadDocument_ShouldThrowException_WhenFileNotFound() {
        // Arrange
        var fileProvider = new FileProvider();
        var filePath = "C:\\workspace\\ACadWithLibrery.ACadSharp\\TestProject1\\Static\\Изометрии\\4550.50.GS00.008.0155.362675.20.133AI.Sh01-37.Rev_a0 ТОП-11, ТКМ-11 ТКМ-11_1.dwg";

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => fileProvider.GetCadDocument<DwgReader>(filePath));
    }
}