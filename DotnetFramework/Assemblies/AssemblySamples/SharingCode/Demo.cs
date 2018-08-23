
namespace SharingCode
{
    public class Demo
    {
        public string PlatformString()
        {
#if SILVERLIGHT
        return "Silverlight";
#elif NETFX_CORE
        return "Windows Store App";
#else
            return "Default";
#endif
        }
    }
}
