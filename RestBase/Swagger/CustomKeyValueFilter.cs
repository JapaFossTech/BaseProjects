using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PrjBase.ModelBase.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RestBase.Swagger;

public class CustomKeyValueFilter : ISchemaFilter
{
    public void Apply(
        OpenApiSchema schema,
        SchemaFilterContext context)
    {
        var caProvider = context.MemberInfo ?? 
                        context.ParameterInfo as ICustomAttributeProvider;

        var attributes = caProvider?
            .GetCustomAttributes(true)
            .OfType<CustomKeyValueAttribute>();

        if (attributes != null)
        {
            foreach (var attribute in attributes)
            {
                schema.Extensions.Add(
                    attribute.Key,
                    new OpenApiString(attribute.Value)
                    );
            }
        }
    }
}