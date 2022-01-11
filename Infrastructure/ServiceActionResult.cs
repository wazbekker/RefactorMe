using System;
using System.Collections.Generic;

namespace Opsi.Architecture
{
  public class ServiceActionResult
  {
    public bool Success { get; protected set; } = true;
    public bool Failed => !Success;
    public bool NoOp { get; set; } = false;

    public object Value { get; set; }

    public List<string> ActionLog { get; private set; } = new List<string>();
    public List<string> Warnings { get; private set; } = new List<string>();
    public List<string> Errors { get; private set; } = new List<string>();

    public ServiceActionResult() { }

    public void AddError(string module, string type, string message = null, string entityId = null)
    {
    }

    public void AddError(string actionError)
    {
      Success = false;
      Errors.Add(actionError);
    }

    public void AddErrors(IEnumerable<string> actionErrors)
    {
      Success = false;
      Errors.AddRange(actionErrors);
    }

    public void AddWarning(string module, string type, string message = null, string entityId = null)
    {
      AddWarning(message);
    }

    public void AddWarning(string actionWarning)
    {
      Warnings.Add(actionWarning);
    }

    public void AddWarning(IEnumerable<string> actionWarnings)
    {
      Warnings.AddRange(actionWarnings);
    }

    public void Merge(IEnumerable<ServiceActionResult> results)
    {
      if (results == null)
      {
        return;
      }

      foreach (var result in results)
      {
        Merge(result);
      }
    }

    public void Merge(ServiceActionResult result)
    {
      if (result == null)
      {
        return;
      }

      if (result.Failed)
      {
        Success = false;
      }

      if (result.Value != null)
      {
        if (Value is List<object> values)
        {
          values.Add(result.Value);
        }
        else if (Value is null)
        {
          var list = new List<object>();
          list.Add(result.Value);
          Value = list;
        }
        else
        {
          var list = new List<object>();
          list.Add(Value);
          list.Add(result.Value);
          Value = list;
        }
      }

      ActionLog.AddRange(result.ActionLog);
      Warnings.AddRange(result.Warnings);
      Errors.AddRange(result.Errors);
    }
  }
}
