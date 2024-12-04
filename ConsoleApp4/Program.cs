using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<decimal> totalPrices = new List<decimal>();
        bool continueAdding = true;

        while (continueAdding)
        {
            Console.WriteLine("Operator adı daxil edin:");
            string operatorName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(operatorName) || operatorName.Length < 3 || operatorName.Length > 15)
            {
                Console.WriteLine("Xahis edirik düzgün operator adı daxil edin!");
                continue;
            }

            Console.Write("Ayaqqabının markasını daxil edin: ");
            string marka = Console.ReadLine();

            int size;
            Console.Write("Ayaqqabının razmerini daxil edin (rəqəm olaraq): ");
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Zəhmət olmasa razmeri düzgün daxil edin.");
            }

            string[] validColors = { "Red", "Black", "Blue", "Orange", "White", "Brown", "Yellow", "Purple" };
            string color;
            Console.Write("Ayaqqabının rəngini seçin (Red, Black, Blue və s.): ");
            while (true)
            {
                color = Console.ReadLine();
                if (Array.Exists(validColors, c => c.Equals(color, StringComparison.OrdinalIgnoreCase)))
                {
                    break;
                }
                Console.WriteLine("Zəhmət olmasa rəngi düzgün daxil edin.");
            }

            int count;
            Console.Write("Ayaqqabının sayını daxil edin: ");
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0 || count > 99)
            {
                Console.WriteLine("Zəhmət olmasa sayını düzgün daxil edin (1-99 arasında).");
            }

            decimal price;
            Console.Write("Ayaqqabının qiymətini daxil edin (AZN): ");
            while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.WriteLine("Zəhmət olmasa qiyməti düzgün daxil edin.");
            }

            decimal total = count * price;
            totalPrices.Add(total);

            Console.Write("Yeni ayaqqabı əlavə etmək istəyirsinizmi? (Bəli/Xeyr): ");
            string choice;
            while (true)
            {
                choice = Console.ReadLine()?.Trim().ToLower();
                if (choice == "bəli" || choice == "xeyr")
                {
                    break;
                }
                Console.WriteLine("Zəhmət olmasa cavabı düzgün daxil edin (Bəli/Xeyr).");
            }

            if (choice == "xeyr")
            {
                continueAdding = false;
            }
        }

        decimal grandTotal = 0;
        foreach (var total in totalPrices)
        {
            grandTotal += total;
        }

        Console.WriteLine($"Ümumi məbləğ: {grandTotal} AZN");
    }
}
