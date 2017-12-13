using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NDA3
{
    public class SymbolReader
    {
        private const string Path = "symbols.txt";

        private int index = 0;
        public int lineIndex { get; private set; } = 0;
        private List<IEnumerable<int>> Symbols { get; } = ExtractSymbols().ToList();

        private static IEnumerable<IEnumerable<int>> ExtractSymbols()
        {
            int ign;
            return
                File.ReadAllText(Path)
                    .Split('#')
                    .Select(x => x.Split(','))
                    .Where(x => x.All(y => int.TryParse(y, out ign)))
                    .Select(x => x.Select(int.Parse))
                    .Where(x => x.All(y => y >= 0 && y <= 9)).ToList();
        }

        public void Reset()
        {
            this.index = 0;
            this.lineIndex = 0;
        }

        public int LineCount => this.Symbols.Count;

        public int? ReadOne()
        {
            var readOne = this.Symbols
                .ElementAtOrDefault(this.lineIndex)?
                .Cast<int?>()
                .ElementAtOrDefault(this.index++);
            if (readOne == null)
            {
                this.lineIndex++;
                this.index = 0;
            }
            return readOne;
        }
    }
}