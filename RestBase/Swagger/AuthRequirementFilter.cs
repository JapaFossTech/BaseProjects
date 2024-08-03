using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBase.Swagger;

public class AuthRequirementFilter : IOperationFilter
{
    public void Apply(
        OpenApiOperation operation,
        OperationFilterContext context)
    {
        bool isAny_AuthorizedAttribute = context.ApiDescription.ActionDescriptor
            .EndpointMetadata
            .OfType<AuthorizeAttribute>()
            .Any();

        if (!isAny_AuthorizedAttribute)
            return;     //* There are no Authorize Attributes, do nothing

        var securitySchemeToAdd = new OpenApiSecurityScheme(){
            Name = "Bearer",
            In = ParameterLocation.Header,
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        };

        var securityRequirement = new OpenApiSecurityRequirement();

        securityRequirement.Add(
                                key: securitySchemeToAdd
                                , value: Array.Empty<string>() );

        //* old
        operation.Security = new List<OpenApiSecurityRequirement> 
                                { securityRequirement };
        //* new simplification
        //operation.Security = [securityRequirement];


        //operation.Security = new List<OpenApiSecurityRequirement>
        //    {
        //        new OpenApiSecurityRequirement
        //        {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Name = "Bearer",
        //                    In = ParameterLocation.Header,
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type=ReferenceType.SecurityScheme,
        //                        Id="Bearer"
        //                    }
        //                },
        //                Array.Empty<string>()
        //            }
        //        }
        //    };
    }
}

