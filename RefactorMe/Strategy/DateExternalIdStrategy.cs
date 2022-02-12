using System;
using System.Threading.Tasks;

namespace RefactorMe
{
    public class DateExternalIdStrategy : IExternalIdStrategy
    {
        private readonly string _format;
        
        public DateExternalIdStrategy(string format)
        {
            _format = format;
        }
        
        public async Task<string> GetExternalIdAsync()
        {
            return await Task.Run(() =>DateTime.Now.ToString(_format));
        }
    }
}