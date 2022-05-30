using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EvacUa.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace EvacUa.Models
{
    public class Pasanger
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public void EmailSendP(Pasanger pasanger, Vehicle vehicle)
        {
            MailAddress from = new MailAddress("mykhailobudak@gmail.com", "EvacUa");
            // кому отправляем
            MailAddress to = new MailAddress(pasanger.Email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Ваш водій:";
            // текст письма
            m.Body = "<h2>"+vehicle.OwnerName+"  Тел:"+vehicle.OwnerTel+"</h2></br><h2>Зателефонуйте водієві для уточненя місця від'їзду.</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("mykhailobudak@gmail.com", "213420213420");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
