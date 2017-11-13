// <copyright file="WebApiConfig.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataService
{
    using System.Web.Http;

    /// <summary>
    /// Configuration for WebAPI.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the available routes.
        /// </summary>
        /// <param name="config">The configuration instance.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
