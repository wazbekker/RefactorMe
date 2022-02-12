using System;

namespace RefactorMe
{
    public class EntityAttributesMissingException : Exception
    {
        private object Entity { get; }
        private string Attribute { get; }
        
        public EntityAttributesMissingException(string attribute, object entity)
        {
            Attribute = attribute;
            Entity = entity;
        }
    }
}