using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Company_users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string input = String.Empty;


            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" -> ");
                string company = command[0];
                string user = command[1];

                if (companies.ContainsKey(company))
                {
                    if (!companies[company].Contains(user))
                    {
                        companies[company].Add(user);
                    }
                }
                else
                {
                    companies.Add(company, new List<string>() { user });
                }
            }

            foreach (var company in companies.OrderBy(x=>x.Key))
            {
                Console.WriteLine(company.Key);

                foreach (var item in company.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
