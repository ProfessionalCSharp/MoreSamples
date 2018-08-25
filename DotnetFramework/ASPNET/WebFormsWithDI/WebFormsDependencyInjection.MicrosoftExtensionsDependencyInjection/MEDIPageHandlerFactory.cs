using System.Web;
using System.Web.UI;

namespace WebFormsDependencyInjection.MEDI
{
    public class MEDIPageHandlerFactory : PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            IHttpHandler handler =  base.GetHandler(context, requestType, virtualPath, path);
            return handler;
        }
    }
   
}
