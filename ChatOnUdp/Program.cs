using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatOnUdp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // Получаем данные, необходимые для соединения
                Console.WriteLine("Укажите локальный порт");
                Chat.localPort = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Укажите удаленный порт");
                Chat.remotePort = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Укажите удаленный IP-адрес");
                Chat.remoteIPAddress = IPAddress.Parse(Console.ReadLine());

                // Создаем поток для прослушивания
                Thread tRec = new Thread(new ThreadStart(Chat.Receiver));
                tRec.Start();

                while (true)
                {
                    Chat.Send(Console.ReadLine());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Возникло исключение: " + ex.ToString() + "\n  " + ex.Message);
            }
        }
    }
}
