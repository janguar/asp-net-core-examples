﻿using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace WebApiDemo.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthResponseOperationFilter : IOperationFilter
    {
        private readonly IAuthorizationPolicyProvider authorizationPolicyProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorizationPolicyProvider"></param>
        public AuthResponseOperationFilter(IAuthorizationPolicyProvider authorizationPolicyProvider)
        {
            this.authorizationPolicyProvider = authorizationPolicyProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fallbackPolicy = authorizationPolicyProvider.GetFallbackPolicyAsync().GetAwaiter().GetResult();
            var requireAuthenticatedUser = fallbackPolicy?.Requirements.Any(r => r is DenyAnonymousAuthorizationRequirement) ?? false;

            var requireAuthorization = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .Any(a => a is AuthorizeAttribute) ?? false;

            var allowAnonymous = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .Any(a => a is AllowAnonymousAttribute) ?? false;

            if ((requireAuthenticatedUser || requireAuthorization) && !allowAnonymous)
            {
                operation.Responses.TryAdd(StatusCodes.Status401Unauthorized.ToString(), GetResponse(HttpStatusCode.Unauthorized.ToString()));
                operation.Responses.TryAdd(StatusCodes.Status403Forbidden.ToString(), GetResponse(HttpStatusCode.Forbidden.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        private static OpenApiResponse GetResponse(string description)
        => new()
        {
            Description = description,
            Content = new Dictionary<string, OpenApiMediaType>
            {
                [MediaTypeNames.Application.Json] = new()
                {
                    Schema = new()
                    {
                        Reference = new()
                        {
                            Id = nameof(ProblemDetails),
                            Type = ReferenceType.Schema
                        }
                    }
                }
            }
        };
    }

}
