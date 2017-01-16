using System;

namespace WoodenMoose.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Specifies which id Swagger should set when generating description for the annoted method.
    /// This id is what code generators will use to name proxies to call the annoted method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public sealed class SwaggerOperationNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerOperationNameAttribute"/>
        /// </summary>
        /// <param name="name">Name of the operation</param>
        public SwaggerOperationNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Get the name of the operation
        /// </summary>
        public string Name { get; }
    }
}
