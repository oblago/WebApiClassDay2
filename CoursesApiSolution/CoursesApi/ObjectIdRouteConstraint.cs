using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson;

namespace CoursesApi
{

    // "bsonid"
    public class ObjectIdRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var routeValue))
            {
                var parameterValue = Convert.ToString(routeValue);
                if (ObjectId.TryParse(parameterValue, out var _))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string CONSTRAINT_KEY = "bsonid";

    }
}


