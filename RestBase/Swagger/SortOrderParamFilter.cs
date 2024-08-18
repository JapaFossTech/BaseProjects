using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using PrjBase.ModelBase.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBase.Swagger;

public class SortOrderParamFilter : IParameterFilter
{
    public void Apply(
        OpenApiParameter parameter,
        ParameterFilterContext context)
    {
        IEnumerable<SortOrderValidatorAttribute>? attributes = context.ParameterInfo?
                .GetCustomAttributes(true)
                .Union(        //* Use this if param is complex-type i.e. GridDataRequest
                    context.ParameterInfo.ParameterType.GetProperties()
                    .Where(prop => prop.Name == parameter.Name)
                    .SelectMany(prop => prop.GetCustomAttributes(true))
                    )
                .OfType<SortOrderValidatorAttribute>();

        if (attributes is not null)
        {
            foreach (SortOrderValidatorAttribute attribute in attributes)
            {
                parameter.Schema.Extensions.Add(
                    "pattern",
                    new OpenApiString(
                        string.Join(
                            "|"
                            , attribute.SortDirectionOptions.Select(v => $"^{v}$")
                        ))
                    );
            }
        }
    }

    //* To use it, add this in program.cs (Rest API prj)
    //builder.Services.AddSwaggerGen(options =>
    //{
    //    options.ParameterFilter<SortOrderParamFilter>();
    //});
}
