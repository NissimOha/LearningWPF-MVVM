using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LinesClaculatorBL
{
    public class FolderCalculatorModel
    {
        public async Task<string> CalculateLines(string p_path, List<string> p_formats, bool p_includeSubDirectories)
        {
            return await Task.Run(() =>
            {
                SearchOption include = p_includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                List<string[]> files = new List<string[]>();
                int result = 0;
                int i = 0;

                foreach (var format in p_formats)
                {
                    files.Add(Directory.GetFiles(p_path, format, include));
                    foreach (var file in files[i])
                    {
                        var lines = File.ReadAllLines(file);
                        result += lines.Length;
                    }
                }

                return result.ToString();
            });
        }
    }
}
