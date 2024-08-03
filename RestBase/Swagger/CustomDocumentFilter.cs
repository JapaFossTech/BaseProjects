using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBase.Swagger;
public class CustomDocumentFilter : IDocumentFilter
{
    public void Apply(
        OpenApiDocument swaggerDoc,
        DocumentFilterContext context)
    {
        swaggerDoc.Info.Title = "MyBGList Web API";
    }
}

