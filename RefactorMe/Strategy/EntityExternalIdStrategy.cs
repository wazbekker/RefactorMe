using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RefactorMe
{
    public class EntityExternalIdStrategy : IExternalIdStrategy
    {
        private const string DictionaryProperty = "Item";

        private readonly string _attribute;
        private readonly object _entity;

        public EntityExternalIdStrategy(string attribute, object entity)
        {
            _entity = entity;
            _attribute = attribute;
        }

        public async Task<string> GetExternalIdAsync()
        {
            var resultObject = _entity;
            var result = string.Empty;

            foreach (var attr in GetSplitPath())
            {
                try
                {
                    resultObject = resultObject?.GetType().GetProperty(DictionaryProperty)
                        ?.GetValue(resultObject, new[] { attr });
                }
                catch (Exception ex)
                {
                    //not too sure how I should handle a case when the properties that the string template
                    //is expecting are not present in the entity ie entity2?
                    //returning string.Empty for now since the Program.cs file is expecting to be able to still
                    //read the externalId property on the entity without the values for the template.
                    
                    //my suggestion would be to throw the exception or create a custom exception and throw that
                    //and catch it in the GenerateAsync service method and handle it somehow using the ServiceActionResult
                    
                    //throw new EntityAttributesMissingException(attr, _entity);

                    return string.Empty;
                }
            }

            if (resultObject != null)
            {
                result = resultObject.ToString();
            }

            return await Task.Run(() => result);
        }

        private string[] GetSplitPath()
        {
            return Regex.Split(_attribute, RegExConstants.AttributeRegexMatch)
                .Where(s => s != string.Empty)
                .ToArray();
        }
    }
}