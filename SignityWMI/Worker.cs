using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MimeKit;
using SignityWMI.Models;
using SignityWMI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignityWMI
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Accounts account = new Accounts();
            DateAndTime datetime = new DateAndTime();
            Hardware hardware = new Hardware();
            Networking networking = new Networking();
            Services.OperatingSystem os = new Services.OperatingSystem();
            Services.Processor processor = new Services.Processor();
            Software software = new Software();
            WindowService windowservice = new WindowService();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);//basically gives timestamp
                
                //Console.WriteLine(account.GetAccountsTest());
                Console.WriteLine(account.GetAccounts());
                Console.WriteLine(account.NameOfPersonLoggedIn());
                Console.WriteLine(datetime.NameOfTimeZone());
                Console.WriteLine(hardware.DetermineTheMemory());
                Console.WriteLine(hardware.TotalPhysicalMemory());
                Console.WriteLine(hardware.NumberOfProcessors());
                Console.WriteLine(hardware.NoOfPCMCIASlot());
                Console.WriteLine(hardware.DetermineSpeedOfProcessor());
                Console.WriteLine(hardware.DetermineTypeOfSystem());
                Console.WriteLine(hardware.SerialNoOfsystem());
                Console.WriteLine(hardware.DetarmineUSBType());
                Console.WriteLine(hardware.GetHarddisk());
                Console.WriteLine(networking.MacAddress());
                Console.WriteLine(networking.IPAddress());
                os.SerialNoOfsystem();
                os.DetermineOSInstallDate();
                os.OSVersion();
                os.WindowDIrectoryPath();                
                processor.DetermineProcessThread();
                Console.WriteLine(software.GetBIOScaption());
                Console.WriteLine(software.GetBIOSmaker());
                Console.WriteLine(software.GetBiosSerialNo());
                windowservice.ServiceStatus();

                await Task.Delay(60*1000, stoppingToken);//run every 1 min
            }
        }

        //currently not used
        private async Task<string> SendMail()
        {
            try
            {
                MimeMessage message = new MimeMessage();
                MailboxAddress from = new MailboxAddress("Admin", "admin@Signity.com");
                MailboxAddress to = new MailboxAddress("toname", "to_email");
                message.From.Add(from);
                message.To.Add(to);
                message.Subject = "Signity";
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<h1>Signity</h1>";
                bodyBuilder.TextBody = "";
                message.Body = bodyBuilder.ToMessageBody();
                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("robinuniverse@gmail.com", "edwjfdgxqymujexb");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                return "Email Send";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
