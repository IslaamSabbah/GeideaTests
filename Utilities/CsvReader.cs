using System.Collections.Generic;
using System.IO;

namespace GeideaTests.Utilities
{
    public static class CsvReader
    {
        public static IEnumerable<object[]> GetLoginData(string path)
        {
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var values = line.Split(',');
                yield return new object[] { values[0], values[1] };
            }
        }
    }
}
