using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PrjBase.ModelBase.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBase.Swagger;

public class SortColumnParamFilter : IParameterFilter
{
    public void Apply(
        OpenApiParameter parameter,
        ParameterFilterContext context)
    {
        IEnumerable<SortColumnValidatorAttribute>? attributes = context.ParameterInfo?
                .GetCustomAttributes(true)
                .Union(     //* Use this if param is complex-type i.e. GridDataRequest
                    context.ParameterInfo.ParameterType.GetProperties()
                    .Where(p => p.Name == parameter.Name)
                    .SelectMany(p => p.GetCustomAttributes(true))
                    )
                .OfType<SortColumnValidatorAttribute>();

        if (attributes is not null)
        {
            foreach (SortColumnValidatorAttribute attribute in attributes)
            {
                if (attribute.ModelType is not null)
                {
                    IEnumerable<string> pattern = attribute.ModelType
                        .GetProperties()
                        .Select(p => p.Name);

                    parameter.Schema.Extensions.Add(
                        "pattern",
                        new OpenApiString(
                            string.Join("|", pattern.Select(v => $"^{v}$"))
                            )
                        );
                }
            }
        }
    }

    //* To use it, add this in program.cs (Rest API prj)
    //builder.Services.AddSwaggerGen(options =>
    //{
    //    options.ParameterFilter<SortColumnParamFilter>();
    //});
}
