using System;
using ConsoleClient.Mocks;
using NLog;
using TestApp1.Models;

namespace ConsoleClient
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ClientApi client = new ClientApi();

        static void Main(string[] args)
        {
            try
            {
                //Добавление сущностей
                Console.WriteLine("Добавление сущностей!");

                foreach (Person person in new MockPerson().GetPersons())
                {
                    string create = client.Create(person);
                    Console.WriteLine("Ответ: {0}", create);
                    logger.Info("Ответ: {0}", create);
                }
                
                //Выборка сущности
                Console.WriteLine("Выборка сущностeй!");

                for (int i = 0; i <= 3; i++)
                {
                    string select = client.Select(i);
                    logger.Info("Ответ: {0}", select);
                    Console.WriteLine("Ответ: {0}", select);
                    Console.WriteLine();
                }

                //Выборка сущности с фильтрами
                Console.WriteLine("Выборка сущности с фильтрами!");

                //Удаление сущности
                Console.WriteLine("Удаление сущности!");
                string delete = client.Delete(1);
                logger.Info("Ответ: {0}", delete);
                Console.WriteLine("Ответ: {0}", delete);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"При выполнении запроса возникла ошибка: {ex.Message}");
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
