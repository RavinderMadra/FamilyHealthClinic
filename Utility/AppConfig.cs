
using System.Configuration;

namespace Utility
{
    /// <summary>
    /// Get the App Setting nodes
    /// </summary>
    public static class AppConfig
    {
        public static string FromEmail { get; set; }
        public static string FromPassword { get; set; }
        public static string FromUserName { get; set; }
        public static string Port { get; set; }
        public static string MailTo { get; set; }
        public static string Host { get; set; }

       
        /// <summary>
        /// class constructor
        /// </summary>
        static AppConfig()
        {
            FromEmail = ConfigurationManager.AppSettings["fromEmail"]?.ToString();
            FromPassword = ConfigurationManager.AppSettings["fromPassword"]?.ToString();
            FromUserName = ConfigurationManager.AppSettings["fromUserName"]?.ToString();
            Port = ConfigurationManager.AppSettings["port"]?.ToString();
            MailTo = ConfigurationManager.AppSettings["mailTo"]?.ToString();
            Host = ConfigurationManager.AppSettings["host"]?.ToString();
            
        }
    }
}
