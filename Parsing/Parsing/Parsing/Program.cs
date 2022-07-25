using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace Parsing
{
    class Program
    {
        public static void Main(string[] args)
        {
            // StreamReader streamReader = new StreamReader("C://Users//user//Desktop//GameDevAcademy//Введение в Unity//Parsing//Parsing//source.txt");
            
            StreamReader streamReader = new StreamReader("source.txt");//файл нужно положить в корень проекта bin\Debug\net6.0
            
            /*while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                Console.WriteLine(line);// выводим на экран считанный текстовый документ
            }*/

            // LevelSettings levelSettings = new LevelSettings(streamReader);// создали объект levelSettings
            LevelSettings res = new LevelSettings(streamReader);
                
                //Parse(streamReader);// конечный готовый результат парсинга
            
            Console.WriteLine(res);
            streamReader.Close();
        }
    }

/* 1. Количество фишек
	 
	2. Количество точек
	3. Координаты точек
	 
	4. Расположение фишек стартовое
	5. Расположение фишек конечное
	 
	6. Сколько ребер между точками
	7. Ребра*/
}