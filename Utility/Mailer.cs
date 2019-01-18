using DemoModel.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Mailer
    {
        public static bool SendEmail(string subject, string filePath, 
            AppointmentViewModel objAppointment)
        {
            try
            {
                //Read the stram from the file and update the text
                StreamReader reader = System.IO.File.OpenText(filePath);
                string body = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                
                body = body.Replace("$Name", objAppointment.Name);
                body = body.Replace("$AppointmentDate", String.Format("{0:dd/MM/yyyy}",objAppointment.AppointmentDate));
                body = body.Replace("$Email", objAppointment.Email);
                body = body.Replace("$AppointmentTimeName",objAppointment.AppointmentTimeName); 
                body = body.Replace("$Phone", objAppointment.Phone);
                EmailSendUsingSmtpClient(AppConfig.Host,
                    AppConfig.FromUserName, AppConfig.FromPassword,
                    subject, body.ToString(), AppConfig.FromEmail,
                    objAppointment.Email, int.Parse(AppConfig.Port), false, true);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public static void EmailSendUsingSmtpClient(string sMTPClientName, string fromUserName, 
            string fromPassword, string subject, string emailBody, string fromEmailaddress,
            string toEmailaddress, int port, bool IsBodyHtml, bool EnableSsl)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(sMTPClientName);
                smtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                System.Net.NetworkCredential(fromUserName, fromPassword);
                smtpClient.Credentials = basicAuthenticationInfo;
                smtpClient.Port = port;
                smtpClient.Host = sMTPClientName;
                MailAddress from = new MailAddress(fromEmailaddress);
                MailAddress to = new MailAddress(toEmailaddress);
                MailMessage mailMessage = new MailMessage(from, to);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Body = emailBody;
                //mailMessage.BodyEncoding = Encoding.UTF8;
                //mailMessage.IsBodyHtml = IsBodyHtml;
                smtpClient.EnableSsl = EnableSsl;
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
