using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;

namespace YFK.MvcFramework.RouteExtensions
{
    public static class RouteCollectionExtensions
    {
        public static void MapAreaRoute(this RouteCollection routes, string areaName, params Route[] newRoutes)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            if (newRoutes == null)
            {
                throw new ArgumentNullException("newRoutes");
            }

            foreach (var route in newRoutes)
            {
                route.DataTokens["area"] = areaName;
            }
        }

        public static Route MapRouteDomain(this RouteCollection routes, string name, string domain, string url)
        {
            return MapRouteDomain(routes, name, domain, url, null, null, null);
        }

        public static Route MapRouteDomain(this RouteCollection routes, string name, string domain, string url, object defaults)
        {
            return MapRouteDomain(routes, name, domain, url, defaults, null, null);
        }

        public static Route MapRouteDomain(this RouteCollection routes, string name, string domain, string url, string[] namespaces)
        {
            return MapRouteDomain(routes, name, domain, url, null, null, namespaces);
        }

        public static Route MapRouteDomain(this RouteCollection routes, string name, string domain, string url, object defaults, object constraints)
        {
            return MapRouteDomain(routes, name, domain, url, defaults, constraints, null);
        }

        public static Route MapRouteDomain(this RouteCollection routes, string name, string domain, string url, object defaults, string[] namespaces)
        {
            return MapRouteDomain(routes, name, domain, url, defaults, null, namespaces);
        }

        public static Route MapRouteDomain(this RouteCollection routes, string name, string domain, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            DomainRoute route = new DomainRoute(domain, url, defaults, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };

            if ((namespaces != null) && (namespaces.Length > 0))
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url)
        {
            return MapRouteLowercase(routes, name, url, null, null, null);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults)
        {
            return MapRouteLowercase(routes, name, url, defaults, null, null);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            return MapRouteLowercase(routes, name, url, null, null, namespaces);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            return MapRouteLowercase(routes, name, url, defaults, constraints, null);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            return MapRouteLowercase(routes, name, url, defaults, null, namespaces);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var route = new LowercaseRoute(url, new MvcRouteHandler())
                           {
                               Defaults = new RouteValueDictionary(defaults),
                               Constraints = new RouteValueDictionary(constraints),
                               DataTokens = new RouteValueDictionary(namespaces),
                           };

            if (namespaces != null && namespaces.Length > 0)
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url)
        {
            return MapRouteLowercase(context, name, url, null, null, null);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults)
        {
            return MapRouteLowercase(context, name, url, defaults, null, null);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, string[] namespaces)
        {
            return MapRouteLowercase(context, name, url, null, null, namespaces);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, object constraints)
        {
            return MapRouteLowercase(context, name, url, defaults, constraints, null);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, string[] namespaces)
        {
            return MapRouteLowercase(context, name, url, defaults, null, namespaces);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (namespaces == null && context.Namespaces != null)
            {
                namespaces = context.Namespaces.ToArray();
            }


            var route = new LowercaseRoute(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };


            if ((namespaces != null) && (namespaces.Length > 0))
            {
                route.DataTokens["Namespaces"] = namespaces;
            }


            route.DataTokens["area"] = context.AreaName;

            bool useNamespaceFallback = (namespaces == null || namespaces.Length == 0);
            route.DataTokens["UseNamespaceFallback"] = useNamespaceFallback;


            if (String.IsNullOrEmpty(name))
            {
                context.Routes.Add(route);
            }
            else
            {
                context.Routes.Add(name, route);
            }


            return route;
        }
    }
}