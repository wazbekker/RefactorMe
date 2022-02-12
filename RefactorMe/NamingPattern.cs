using System.Collections.Generic;

namespace RefactorMe
{
    public static class NamingPattern
    {
        public static readonly Dictionary<string, string> NamingPatterns = new Dictionary<string, string>
        {
            { "Order", "ORD-{date:ddMMyyyy}-{increment:order}" }, // ORD-12122022-01
            { "Site", "ST-{entity:location.address.postalOrZipCode}-{increment:site}"}, // ST-0042-01
            { "Product", "PRD-{increment:product}" }, // PRD-01
        };
    }
}