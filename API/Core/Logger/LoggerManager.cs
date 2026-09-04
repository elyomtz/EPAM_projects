using log4net;

namespace API.Core.Logger
{
    public static class LoggerManager
    {
        public static ILog Create<T>()
        {
            Log4NetConfigurator.Configure();
            return LogManager.GetLogger(typeof(T));
        }
    }
}
