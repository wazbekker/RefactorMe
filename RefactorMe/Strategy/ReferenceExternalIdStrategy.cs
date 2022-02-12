using System.Threading.Tasks;

namespace RefactorMe
{
    public class ReferenceExternalIdStrategy : IExternalIdStrategy
    {
        private readonly string _attribute;
        private readonly object _entity;

        public ReferenceExternalIdStrategy(string attribute, object entity)
        {
            _attribute = attribute;
            _entity = entity;
        }

        public async Task<string> GetExternalIdAsync()
        {
            return await Task.Run(() => _entity.GetType().GetProperty(_attribute)?.GetValue(_entity, null)?.ToString());
        }
    }
}