using ex023_metodosAbstratos.Entities;
using System;
using System.Globalization;
using System.Net.Http.Headers;

namespace ex023
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of Tax Payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax Payer #{i} data:");
                Console.Write("Individual or Company ( i / c )? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: $ ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                if (ch == 'i')
                {
                    Console.Write("Health Expenditures: $ ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of Employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());

                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }

            double sum = 0.0;
            Console.WriteLine("\nTAXES PAID:");
            foreach(TaxPayer p in list)
            {
                Console.WriteLine(p.Name
                    + ": $ "
                    + p.Tax().ToString("f2", CultureInfo.InvariantCulture));
                sum += p.Tax();
            }

            Console.WriteLine("\nTOTAL TAXES: $ " + sum.ToString("f2", CultureInfo.InvariantCulture));
        }
    }
}