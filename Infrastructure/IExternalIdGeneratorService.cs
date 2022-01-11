using System.Collections.Generic;
using System.Threading.Tasks;

using Opsi.Architecture;
using Opsi.Cloud.Core.Model;

namespace Opsi.Cloud.Core.Interface
{
  public interface IExternalIdGeneratorService
  {
    // Generate entity external ID from some provided string template.
    Task<ServiceActionResult> GenerateAsync(List<Dictionary<string, object>> entities, TypeMetadata typeMetadata);
  }
}
