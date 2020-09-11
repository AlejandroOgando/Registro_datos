using System;
using System.IO;

namespace registro_datos
{
    class Program
    {
        static string Data (string filePath)
        {
            string id = "", names = "", lastName = "";
            int age = 0;
            string delimiter = ", ";
           
            Console.Write("Cédula: ");
            id = Console.ReadLine();
            Console.Write("Nombres: ");
            names = Console.ReadLine();
            Console.Write("Apellidos: ");
            lastName = Console.ReadLine();
            Console.Write("Edad: ");
            age = int.Parse(Console.ReadLine());
            string finalData = id + delimiter + names + delimiter + lastName + delimiter + age;
            return finalData;
        }
      

        static void Main(string[] args)
        {
            string fileName = args[0];
            string filePath = @"C:\Users\Alejandro Ogando\Desktop\"+ fileName;
            int menu;
            int endprog = 0;

            string defaultext = "Cedula, Nombres, Apellidos, Edad";
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(defaultext);
                sw.Close(); 
            }
            do
            {
                string z = Data(filePath);
                Console.WriteLine("¿Guardar (1), Descartar (2), Salir (3)?");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        using (StreamWriter sw = File.AppendText(filePath))
                        {
                            sw.WriteLine(z);
                            sw.Close(); 
                        }
                    break;
                    case 2:
                    break;
                    case 3:
                        endprog++;
                        break;
                    default:
                        Console.WriteLine("Entrada no válida.");
                    break;
                }
            } while (endprog==0);
           
        }    
    }   
}
