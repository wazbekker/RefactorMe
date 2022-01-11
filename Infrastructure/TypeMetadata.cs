using System;
using System.Collections.Generic;

namespace Opsi.Cloud.Core.Model
{
  public class TypeMetadata
  {
    public Type Type { get; }
    public string Name { get; set; }  // Entity Type Name

    public bool IsRoot { get; }

    public bool IsPrimaryEntity { get; }
    public bool IsStateManaged { get; }

    public string[] Permissions { get; }

    public Dictionary<string, object> AuxData { get; }

    public TypeMetadata(Type type)
    {
      Type = type;
      Name = type.Name;

      AuxData = new Dictionary<string, object>();
    }

    public TypeMetadata() { }

    public void AddAux(string key, object value)
    {
      if (AuxData.ContainsKey(key))
      {
        throw new InvalidOperationException($"Aux key '{key}' already exist.");
      }

      AuxData.Add(key, value);
    }

    public T GetAux<T>(string key) where T : class
    {
      return AuxData.ContainsKey(key) ? AuxData[key] as T : null;
    }
  }
}
