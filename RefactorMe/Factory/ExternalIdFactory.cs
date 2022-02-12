using System;

namespace RefactorMe.Factory
{
    public static class ExternalIdFactory
    {
        public static IExternalIdStrategy CreateExternalIdStrategy(string externalIdType, string value, object entity)
        {
            return externalIdType switch
            {
                "date" => new DateExternalIdStrategy(value),
                "increment" => new IncrementExternalIdStrategy(value),
                "entity" => new EntityExternalIdStrategy(value, entity),
                "reference" => new ReferenceExternalIdStrategy(value, entity),
                _ => throw new ArgumentException("A valid external Id type needs to be provided")
            };
        }
    }
}