using System.Web;
using System.Web.Mvc;

namespace VideoStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); //Global filtering
            filters.Add(new RequireHttpsAttribute()); //For OAuth with Social Websites

        }
    }
}
