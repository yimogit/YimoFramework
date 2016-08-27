using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace YFK.MvcFramework.RouteExtensions
{
    public class DomainData
    {
        public string Protocol { get; set; }
        public string HostName { get; set; }
        public string Fragment { get; set; }
    }

    public class DomainRoute : Route
    {
        private Regex domainRegex;
        private Regex pathRegex;


        public string Domain { get; set; }


        public DomainRoute(string domain, string url, RouteValueDictionary defaults)
            : base(url, defaults, new MvcRouteHandler())
        {
            Domain = domain;
        }


        public DomainRoute(string domain, string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
            Domain = domain;
        }

        public DomainRoute(string domain, string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
            Domain = domain;
        }

        public DomainRoute(string domain, string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
            Domain = domain;
        }

        public DomainRoute(string domain, string url, object defaults)
            : base(url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        {
            Domain = domain;
        }


        public DomainRoute(string domain, string url, object defaults, IRouteHandler routeHandler)
            : base(url, new RouteValueDictionary(defaults), routeHandler)
        {
            Domain = domain;
        }


        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            domainRegex = CreateRegex(Domain);
            pathRegex = CreateRegex(Url);


            string requestDomain = httpContext.Request.Headers["host"];
            if (!string.IsNullOrEmpty(requestDomain))
            {
                if (requestDomain.IndexOf(":") > 0)
                {
                    requestDomain = requestDomain.Substring(0, requestDomain.IndexOf(":"));
                }
            }
            else
            {
                requestDomain = httpContext.Request.Url.Host;
            }
            string requestPath = httpContext.Request.AppRelativeCurrentExecutionFilePath.Substring(2) + httpContext.Request.PathInfo;


            Match domainMatch = domainRegex.Match(requestDomain);
            Match pathMatch = pathRegex.Match(requestPath);


            RouteData data = null;
            if (domainMatch.Success && pathMatch.Success)
            {
                data = new RouteData(this, RouteHandler);


                if (Defaults != null)
                {
                    foreach (KeyValuePair<string, object> item in Defaults)
                    {
                        data.Values[item.Key] = item.Value;
                    }
                }


                for (int i = 1; i < domainMatch.Groups.Count; i++)
                {
                    Group group = domainMatch.Groups[i];
                    if (group.Success)
                    {
                        string key = domainRegex.GroupNameFromNumber(i);


                        if (!string.IsNullOrEmpty(key) && !char.IsNumber(key, 0))
                        {
                            if (!string.IsNullOrEmpty(group.Value))
                            {
                                data.Values[key] = group.Value;
                            }
                        }
                    }
                }


                for (int i = 1; i < pathMatch.Groups.Count; i++)
                {
                    Group group = pathMatch.Groups[i];
                    if (group.Success)
                    {
                        string key = pathRegex.GroupNameFromNumber(i);


                        if (!string.IsNullOrEmpty(key) && !char.IsNumber(key, 0))
                        {
                            if (!string.IsNullOrEmpty(group.Value))
                            {
                                data.Values[key] = group.Value;
                            }
                        }
                    }
                }

                foreach (var item in this.DataTokens)
                {
                    data.DataTokens.Add(item.Key, item.Value);
                }
            }


            return data;
        }


        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData path = base.GetVirtualPath(requestContext, values);

            if (path != null)
            {
                string virtualPath = path.VirtualPath;
                var lastIndexOf = virtualPath.LastIndexOf("?");

                if (lastIndexOf != 0)
                {
                    if (lastIndexOf > 0)
                    {
                        string leftPart = virtualPath.Substring(0, lastIndexOf).ToLowerInvariant();
                        string queryPart = virtualPath.Substring(lastIndexOf);
                        path.VirtualPath = leftPart + queryPart;
                    }
                    else
                    {
                        path.VirtualPath = path.VirtualPath.ToLowerInvariant();
                    }
                }
            }

            return path;
        }


        public DomainData GetDomainData(RequestContext requestContext, RouteValueDictionary values)
        {
            string hostname = Domain;
            foreach (KeyValuePair<string, object> pair in values)
            {
                hostname = hostname.Replace("{" + pair.Key + "}", pair.Value.ToString());
            }


            return new DomainData
            {
                Protocol = "http",
                HostName = hostname,
                Fragment = ""
            };
        }


        private Regex CreateRegex(string source)
        {
            source = source.Replace("/", @"\/?");
            source = source.Replace(".", @"\.?");
            source = source.Replace("-", @"\-?");
            source = source.Replace("{", @"(?<");
            source = source.Replace("}", @">([a-zA-Z0-9_]*))");


            return new Regex("^" + source + "$");
        }


        private RouteValueDictionary RemoveDomainTokens(RouteValueDictionary values)
        {
            Regex tokenRegex = new Regex(@"({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?({[a-zA-Z0-9_]*})*-?\.?\/?");
            Match tokenMatch = tokenRegex.Match(Domain);
            for (int i = 0; i < tokenMatch.Groups.Count; i++)
            {
                Group group = tokenMatch.Groups[i];
                if (group.Success)
                {
                    string key = group.Value.Replace("{", "").Replace("}", "");
                    if (values.ContainsKey(key))
                        values.Remove(key);
                }
            }
            return values;
        }
    }
}
