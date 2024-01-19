using System.Diagnostics;
using ACadWithLibrery.ACadSharp.Service;

namespace TestProject1;

public class PathCollectionsTests {
    private string startPath = @"C:\workspace\ACadWithLibrery.ACadSharp\TestProject1\Static";

    [Fact]
    public void SearchFullPath_ReturnsCorrectNumberOfDwgFiles() {
        // Arrange
        var pathCollections = new PathCollections();
        var expectedFileCount = 11;

        // Act
        var stopwatch = Stopwatch.StartNew();
        var actualFiles = pathCollections.SearchFullPath(startPath).ToList();
        stopwatch.Stop();

        // Assert
        Assert.Equal(expectedFileCount, actualFiles.Count);
        SaveExecutionTime("SearchFullPath", stopwatch.ElapsedMilliseconds);
    }

    [Fact]
    public async Task SearchFullPathAsync_ReturnsCorrectNumberOfDwgFiles() {
        // Arrange
        var pathCollections = new PathCollections();
        var expectedFileCount = 11;

        // Act
        var stopwatch = Stopwatch.StartNew();
        var actualFiles = (await pathCollections.SearchFullPathAsync(startPath)).ToList();
        stopwatch.Stop();

        // Assert
        Assert.Equal(expectedFileCount, actualFiles.Count);
        SaveExecutionTime("SearchFullPathAsync", stopwatch.ElapsedMilliseconds);
    }

    private void SaveExecutionTime(string methodName, long executionTime) {
        var filePath = "C:\\workspace\\ACadWithLibrery.ACadSharp\\TestProject1\\Results\\execution_times.txt";
        var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var logMessage = $"{currentTime} - {methodName}: {executionTime} ms";

        using (var writer = new StreamWriter(filePath, true)) {
            writer.WriteLine(logMessage);
        }
    }
}