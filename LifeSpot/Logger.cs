using System;
using System.Text;

namespace LifeSpot
{
    public class Logger
    {
        /// <summary>
        /// This method gets a reference to the Action delegate 
        /// as a parameter, which can be used to call different methods inside
        /// </summary>
        public static void PrintMessage(Action logMode)
        {
            // Lambdas.Test();
            
            Console.OutputEncoding = Encoding.Unicode;
            // Start logger
            Console.WriteLine("Логгер запущен");
            
            // Вызываем делегат
            // "Под капотом" будет вызван метод, на который указывает делегат, что по сути очень 
            // похоже на то, как работает передача функций в качестве параметра в JS
            logMode.Invoke();
        }
        
        // Вывод информационныз сообщений 
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        // Вывод предупреждений 
        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        // Вывод сообщений об ошибках
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}