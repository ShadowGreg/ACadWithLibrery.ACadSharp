using ACadSharp;
using ACadSharp.Entities;
using ACadWithLibrery.ACadSharp.Abstraction;

namespace ACadWithLibrery.ACadSharp.Service;

public class TextEntitySearch : ITextSearchInFiles {
    private IEnumerable<TextEntity> _textEntities;

    public TextEntitySearch(IEnumerable<TextEntity> textEntities) {
        _textEntities = textEntities;
    }

    public string? SearchInFile(string text) {
        return (from e in _textEntities where e.Value.Contains(text) select e.Value).FirstOrDefault();
    }
}