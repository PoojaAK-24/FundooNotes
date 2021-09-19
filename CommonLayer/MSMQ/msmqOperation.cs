﻿using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace CommonLayer.MSMQ
{
    public class msmqOperation
    {
        MessageQueue msmq = new MessageQueue();
        public void SendingData(string token)
        {
            msmq.Path = @".\private$\tohenQueue";

            if (!MessageQueue.Exists(msmq.Path))
            {
                //if not exixts
                MessageQueue.Create(msmq.Path);
            }
            SendingToken(token);
        }

        public void SendingToken(string token)
        {
            //For adding Xml formatter to the message
            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            msmq.ReceiveCompleted += Msmq_ReceiveCompleted;

            //for sending token to the queue
            msmq.Send(token);
            msmq.BeginReceive();
            msmq.Close();
        }

        private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                //getting  token from receiver
                var msg = msmq.EndReceive(e.AsyncResult);

                string token = msg.Body.ToString();
                //sending a mail via SMTP

                mailSending(token);
                msmq.BeginReceive();
            }
            catch (MessageQueueException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void mailSending(string token)
        {
            MailMessage mailMessage = new MailMessage("pooja12reddy@gmail.com", "pooja12reddy@gmail.com");
            mailMessage.Subject = "Reset password link";

            var body = new StringBuilder();

            body.AppendLine("Hello User, To reset your account Password click the link below");
            body.AppendLine("<a href=\"https://localhost:44365/User/ResetPassword/" + token + "\">Click Here</a>");
            mailMessage.Body = body.ToString();
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new NetworkCredential()
            {
                UserName = "pooja12reddy@gmail.com",
                Password = "pooja8880422433"
             };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}
