using System.Net;
using System.Net.Mail;
namespace EvacUa.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerEmail { get; set; }
        public string? OwnerTel { get; set; }
        public int Places { get; set; }
        public string? FromWhere { get; set; }
        public string? ToWhere { get; set; }
        public string? Time { get; set; }
        public bool IsComplete { get; set; }
        public void EmailSendF( Vehicle vehicle)
        {
            MailAddress from = new MailAddress("mykhailobudak@gmail.com", "EvacUa");
            // кому отправляем
            MailAddress to = new MailAddress(vehicle.OwnerEmail);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Шановний";
            // текст письма
            m.Body = "<h2>" + vehicle.OwnerName + "</h2></br><h2>Дякуємо вам за домогу. Чекайте сповіщення о пасажирах</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("mykhailobudak@gmail.com", "213420213420");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public void EmailSendN(Pasanger pasanger, Vehicle vehicle)
        {
            MailAddress from = new MailAddress("mykhailobudak@gmail.com", "EvacUa");
            // кому отправляем
            MailAddress to = new MailAddress(vehicle.OwnerEmail);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Новий пасажир";
            // текст письма
            m.Body = "<h2>" +pasanger.Name +" Тел:"+pasanger.Telephone  + "</h2></br><h2>Зателефонуйте пасажиру для уточнення місця та часу</h2>";
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
