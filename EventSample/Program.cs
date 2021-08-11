using System;

namespace EventSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(100);
            //acc.Notify += new Account.AccountHandler(DisplayRedMessage);//делегат в качестве обработчика события
            //acc.Notify += DisplayMessage;   //метод в качестве обработчика события
            /*
            acc.Notify += delegate (string mes)     //анонимный метод в качестве обработчика события
            {
                Console.WriteLine(mes);
            };
            */

            acc.Notify += mes => Console.WriteLine(mes);    //лямбда в качестве обработчика события
            //acc.Notify += DisplayRedMessage;
            acc.Put(20);    // добавляем на счет 20
            //Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(70);   // пытаемся снять со счета 70
            //Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(180);  // пытаемся снять со счета 180
            //Console.WriteLine($"Сумма на счете: {acc.Sum}");
        }
        /*
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        */
        /*
        private static void DisplayRedMessage(String message)
        {
            // Устанавливаем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Сбрасываем настройки цвета
            Console.ResetColor();
        }*/
    }
}