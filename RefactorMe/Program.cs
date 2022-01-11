using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Opsi.Cloud.Core;
using Opsi.Cloud.Core.Model;

namespace RefactorMe
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var gen = new ExternalIdService(null);

      var entity1 = new Dictionary<string, object> {
        { "id", 1 },
        { "location", new Dictionary<string, object> {
          {"address", new Dictionary<string, object> { { "postalOrZipCode", "0042" } } }
        } }
      };

      var entity2 = new Dictionary<string, object> { { "id", 2 } };

      await gen.GenerateAsync(
         new List<Dictionary<string, object>> { entity1, entity2
    },
         new TypeMetadata { Name = "Site" });

      Console.WriteLine(entity1["externalId"]);
      Console.WriteLine(entity2["externalId"]);
    }
  }
}
