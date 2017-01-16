using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WoodenMoose.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Set the Swagger "tags" field with groups defined in the <see cref="SwaggerGroupAttribute"/>
    /// </summary>
    public class SwaggerGroupOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Apply the filter
        /// </summary>
        /// <param name="operation">Swagger description</param>
        /// <param name="context">Context of the operation filter</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var action = context?.ApiDescription?.ActionDescriptor as ControllerActionDescriptor;
            var attribute = action?.MethodInfo.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(SwaggerGroupAttribute));

            if (attribute != null)
            {
                operation.Tags = (attribute.ConstructorArguments[0].Value as IReadOnlyList<CustomAttributeTypedArgument>).Select(s => s.Value.ToString()).ToArray();
            }
        }
    }
}
