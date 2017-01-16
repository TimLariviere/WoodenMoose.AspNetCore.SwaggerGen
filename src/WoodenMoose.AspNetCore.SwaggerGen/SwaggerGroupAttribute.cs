using System;

namespace WoodenMoose.AspNetCore.SwaggerGen
{
    /// <summary>
    /// Specifies in which groups Swagger should put the annoted method 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class SwaggerGroupAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerGroupAttribute"/> class 
        /// </summary>
        /// <param name="groups">Groups of the annoted method</param>
        public SwaggerGroupAttribute(params string[] groups)
        {
            Groups = groups;
        }

        /// <summary>
        /// Gets the groups of the annoted method
        /// </summary>
        public string[] Groups { get; }
    }
}
