using System;
using ConsoleClient.Mocks;
using NLog;
using TestApp1.Models;
using System.Collections;

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
                    string SelectId = client.SelectId(i);
                    logger.Info("Ответ: {0}", SelectId);
                    Console.WriteLine("Ответ: {0}", SelectId);
                    Console.WriteLine();
                }

                //Выборка сущности с фильтрами
                Console.WriteLine("Выборка сущности с фильтрами!");

                Hashtable list = new Hashtable();
                list.Add("first_name", "Антон");
                string SelectFilter = client.SelectFilter(list);
                logger.Info("Фильтр по имени: {0}", SelectFilter);
                Console.WriteLine("Фильтр по имени: {0}", SelectFilter);

                list.Add("id", "2");
                SelectFilter = client.SelectFilter(list);
                logger.Info("Фильтр по имени: {0}", SelectFilter);
                Console.WriteLine("Фильтр по имени и ID: {0}", SelectFilter);
                
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
