using projeto_enum.Entities;
using projeto_enum.Entities.Enums;
using System;
using System.Globalization;
using System.Xml.Linq;

namespace projeto_enum
{
    class Program
    {
        private static NumberStyles cultureInfo;

        static void Main(string[] args)
        {
            Console.Write("Digite o nome do departamento: ");
            string departament = Console.ReadLine();
            Console.WriteLine("Insira os dados do trabalhador:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Level (Junior/Pleno/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salário base: ");
            double salarioBase = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department departamento = new Department(departament);
            Worker worker = new Worker(nome, level, salarioBase, departamento);

            Console.Write("Quantos contratos para este trabalhador? ");
            int contratos = int.Parse(Console.ReadLine());

            for (int i = 1; i <= contratos; i++)
            {
                Console.Write("Insira os dados do contrato #" + i + ":");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valorPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (Horas): ");
                int horas = int.Parse(Console.ReadLine());
                Console.WriteLine();
                HourContract contrato = new HourContract(data, valorPorHora, horas);
                worker.AddContract(contrato);
            }

            Console.Write("Digite o mês e o ano para calcular o rendimento (MM/YYYY): ");
            string rendimento = Console.ReadLine();
            int month = int.Parse(rendimento.Substring(0, 2));
            int year = int.Parse(rendimento.Substring(3));
            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Income for " + rendimento + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
