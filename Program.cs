using System;
using System.IO;

namespace registro_datos
{
    class Program
    {
           static string GetData ()
        {
            string id ="", names = "", lastNames = "";
            int age = 0;
            string delimiter = ", ";

            Console.Write("Cédula: ");
            id = Console.ReadLine();
            Console.Write("Nombres: ");
            names = Console.ReadLine();
            Console.Write("Apellidos: ");
            lastNames = Console.ReadLine();
            Console.Write("Edad: ");
            age = int.Parse(Console.ReadLine());
            string finalData = id + delimiter + names + delimiter + lastNames + delimiter + age;
            return finalData;
        }

        static void SaveData(string filePath)
        {
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
                string z = GetData();
                Console.WriteLine("¿Guardar (1), Descartar (2), Salir (3)");
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
        
        static void Read(string filePath)
        {
            int numLines = 0;
            string line;
            using (StreamReader sr = new StreamReader(filePath))
            {
                
                while ((line = sr.ReadLine()) !=null)
                {
                    Console.WriteLine("No.{0} -- {1}", numLines, line);
                    numLines++;
                }
            }
        }
        
        static void Search(string filePath, string id)
        {
            string line;
           
            using (StreamReader sr = new StreamReader(filePath))
            {
                
                while ((line = sr.ReadLine()) !=null)
                {
                    string subId = line.Split(',')[0];
                    if (subId == id)
                    {
                        Console.WriteLine(line);
                        Console.ReadKey(); 
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string fileName =  args[0];
            string filePath = @"C:\Users\Alejandro Ogando\Desktop\datos\" + fileName;
            int endProg = 0;
            do
            {
                int num;
                Console.WriteLine();
                Console.WriteLine("Menú Principal");
                Console.WriteLine("----------------------------------------------------------");
                Console.Write("(1). Capturar datos.\n");
                Console.Write("(2). Listar información existente.\n");
                Console.Write("(3). Busqueda.\n");
                Console.Write("(4). Salir.\n");
                Console.WriteLine("----------------------------------------------------------");
                Console.Write("Escriba el número de la opción que desea: ");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (num)
                {
                    case 1:
                        SaveData(filePath);
                    break;
                    case 2:
                        Read(filePath);
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú.");
                        Console.ReadKey();
                    break;
                    case 3:
                        string idFinder;
                        Console.Write("\nIntroduzca la cédula que desea buscar en el archivo: ");
                        idFinder = Console.ReadLine();
                        Console.WriteLine();
                        Search(filePath, idFinder);
                    break;
                    case 4:
                        endProg++;
                    break;
                    default:
                        Console.WriteLine("No es una entrada válida.");
                    break;
                }

            } while (endProg == 0);

            
        }
    }   
}
