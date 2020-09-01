using System;
using System.Collections.Generic;
using TestApp1.Models;

namespace ConsoleClient.Mocks
{
    class MockPerson
    {
        public IEnumerable<Person> GetPersons()
        {
            return new List<Person> {
                new Person {
                    last_name = "Васичкин",
                    first_name = "Андрей",
                    middle_name = "Егоров",
                    age = new Random().Next(20, 40),
                },
                new Person {
                    last_name = "Семенов",
                    first_name = "Антон",
                    middle_name = "Семенович",
                    age = new Random().Next(20, 40),
                },
                new Person {
                    last_name = "Петров",
                    first_name = "Антон",
                    middle_name = "Алексеевич",
                    age = new Random().Next(20, 40),
                }
            };
        }
    }
}
