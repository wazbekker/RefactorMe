using System.Threading.Tasks;

namespace RefactorMe
{
    public interface IExternalIdStrategy
    {
        public Task<string> GetExternalIdAsync();
    }
}