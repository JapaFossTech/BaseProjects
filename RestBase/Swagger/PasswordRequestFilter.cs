using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBase.Swagger;

public class PasswordRequestFilter : IRequestBodyFilter
{
    public void Apply(
        OpenApiRequestBody requestBody,
        RequestBodyFilterContext context)
    {
        var fieldName = "password";

        if (context.BodyParameterDescription.Name
            .Equals(fieldName,
                StringComparison.OrdinalIgnoreCase)
            || context.BodyParameterDescription.Type
            .GetProperties().Any(prop => prop.Name
                .Equals(fieldName,
                    StringComparison.OrdinalIgnoreCase)))
        {
            requestBody.Description =
                "IMPORTANT: be sure to always use a strong password " +
                "and store it in a secure location!";
        }
    }
}
