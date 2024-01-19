using ACadSharp.Entities;
using ACadWithLibrery.ACadSharp.Service;

namespace TestProject1;

public class TextEntitySearchTests {
    [Fact]
    public void SearchInFile_ReturnsMatchingText() {
        // Arrange
        var textEntities = new List<TextEntity>
        {
            new TextEntity { Value = "Hello, world!" },
            new TextEntity { Value = "Lorem ipsum dolor sit amet" },
            new TextEntity { Value = "ACadSharp is awesome" }
        };
        var searchService = new TextEntitySearch(textEntities);
        var searchText = "ACadSharp";

        // Act
        var result = searchService.SearchInFile(searchText);

        // Assert
        Assert.Equal("ACadSharp is awesome", result);
    }

    [Fact]
    public void SearchInFile_ReturnsNullIfNoMatch() {
        // Arrange
        var textEntities = new List<TextEntity>
        {
            new TextEntity { Value = "Hello, world!" },
            new TextEntity { Value = "Lorem ipsum dolor sit amet" },
            new TextEntity { Value = "ACadSharp is awesome" }
        };
        var searchService = new TextEntitySearch(textEntities);
        var searchText = "foo";

        // Act
        var result = searchService.SearchInFile(searchText);

        // Assert
        Assert.Null(result);
    }
}