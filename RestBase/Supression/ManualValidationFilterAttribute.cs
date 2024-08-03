using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBase.Supression;

public class ManualValidationFilterAttribute : Attribute, IActionModelConvention
{
    /// <summary>
    /// Use case: To suppress the filter that uses the ModelState Invalid property.
    /// When suppressed by using this attribute, the framework does not sent 
    /// HTTP error 400 on model binding and validation failures.
    /// </summary>
    /// <param name="action"></param>
    public void Apply(ActionModel action)
    {
        for (var i = 0; i < action.Filters.Count; i++)
        {
            if (action.Filters[i] is ModelStateInvalidFilter
                || action.Filters[i].GetType().Name == "ModelStateInvalidFilterFactory")
            {
                action.Filters.RemoveAt(i);
                break;
            }
        }
    }
}
