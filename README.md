# WoodenMoose.AspNetCore.SwaggerGen
A small library for ASP.NET Core that allows to more finely tune Swagger API description generation.
This will allow better code generation from tools like NSwag and AutoRest

For instance, AutoRest will fail to generate code if the "consumes" field is not filled for POST actions.
SwaggerGen doesn't take the `ConsumesAttribute` of ASP.NET by default, so `SwaggerConsumesAttribute` comes in handy.

Prerequisites
-------
This library will only work with ASP.NET Core projects targeting at least .NET Core 1.0, and you will need to configure SwaggerGen (https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

Installation
-------
A NuGet package of the library is available here : https://www.nuget.org/packages/WoodenMoose.AspNetCore.SwaggerGen/

Features
-------
Available operation filters
Name|Description|Swagger field
----|----|----
SwaggerConsumesOperationFilter|Change the accepted content type(s) for an action|consumes
SwaggerOperationNameOperationFilter|Change the operation id of an action (used by code generators to name methods)|operationId
SwaggerGroupOperationFilter|Change the grouping of actions on SwaggerUi|tags

Usage
-------
Once the NuGet package added in your project.json file, you will need to configure Swagger to use the Operation filters that you need.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSwaggerGen(options =>
    {
        options.OperationFilter<SwaggerConsumesOperationFilter>();
        options.OperationFilter<SwaggerOperationNameOperationFilter>();
        options.OperationFilter<SwaggerGroupOperationFilter>();
    });
}
```

Now you can use it into your controllers by adding attributes to your actions

```csharp
[HttpGet("{id}")]
[SwaggerOperationName("GetApplicationById")]
public User Get(int id)
{
    (...)
}

[HttpPost]
[SwaggerOperationName("CreateApplication"), SwaggerConsumes("application/json")]
public int CreateApplication([FromBody] Application application)
{
    (...)
}

[HttpPost("~/users/{id}/applications")]
[SwaggerGroup("Users"), SwaggerOperationName("AddApplicationToUser")]
public IEnumerable<User> AddApplicationToUser(int id)
{
    (...)
}
```