using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace WoodenMoose.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Set the Swagger "operationId" field with name defined in the <see cref="SwaggerOperationNameAttribute"/>
    /// </summary>
    public class SwaggerOperationNameOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Apply the filter
        /// </summary>
        /// <param name="operation">Swagger description</param>
        /// <param name="context">Context of the operation filter</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var action = context?.ApiDescription?.ActionDescriptor as ControllerActionDescriptor;
            var attribute = action?.MethodInfo.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(SwaggerOperationNameAttribute));

            if (attribute != null)
            {
                operation.OperationId = attribute.ConstructorArguments[0].Value as string;
            }
        }
    }
}
