using System;

namespace Opsi.Architecture
{
  /// <summary>Base entity for all data entities in the system. The Id should be unique within a Partition.</summary>
  public abstract class Entity 
  {
    public object Uid { get; private set; }

    public string Id { get; protected set; }

    public string ExternalId { get; set; }

    public long Version { get; protected set; }

    public Entity(string id) : this()
    {
      Id = id;
    }

    protected Entity()
    {
      Version = GenerateVersion();
    }
 
    public override string ToString()
    {
      return $"{GetType().Name}:{Id}";
    }

    public static long GenerateVersion()
    {
      return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
  }
}
