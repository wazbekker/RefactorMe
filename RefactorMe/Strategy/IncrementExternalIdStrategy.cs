using System;
using System.Threading.Tasks;

namespace RefactorMe
{
    public class IncrementExternalIdStrategy : IExternalIdStrategy
    {
        private string _type;
        public IncrementExternalIdStrategy(string type)
        {
            _type = type;
        }
        
        public async Task<string> GetExternalIdAsync()
        {
            return await Task.Run(() =>new Random().Next(100)
                .ToString());
        }
    }
}