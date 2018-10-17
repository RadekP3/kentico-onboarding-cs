using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.Web.Http.Routing;

namespace TodoList.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                }
            };
            config.MapHttpAttributeRoutes(constraintResolver);
            config.AddApiVersioning();
        }
    }
}
