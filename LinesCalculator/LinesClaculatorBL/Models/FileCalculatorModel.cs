using System.IO;
using System.Threading.Tasks;

namespace LinesClaculatorBL
{
    public class FileCalculatorModel
    {
        public async Task<string> CalculateLines(string p_path)
        {
            return await Task.Run(() =>
            {
                var result = File.ReadAllLines(p_path);

                return result.Length.ToString();
            });
        }
    }
}
