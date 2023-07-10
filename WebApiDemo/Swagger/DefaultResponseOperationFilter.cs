using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApiDemo.Swagger
{
 
    /// <summary>
    /// 
    /// </summary>
    public class DefaultResponseOperationFilter : IOperationFilter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
            => operation.Responses.TryAdd("default", GetResponse("Unexpected error"));

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
