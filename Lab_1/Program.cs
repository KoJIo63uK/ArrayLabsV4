using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: "); // Вывод сообщения на экран
            var length = int.Parse(Console.ReadLine()); // Читаем длину массива
            var array = GenerateArray(length); // Вызываем метод генерации массива и записываем его в переменную
            PrintArray(array); // Вызываем метод печати массива

            Console.WriteLine($"Индекс минимального элемента массива равен: {GetMinItemIndex(array)}"); // Вывод результата

            Console.ReadKey(); // Что бы консоль сама не закрылась читаем anykey
        }

        private static int GetMinItemIndex(int[] array) // Метод поиска индекса минимального элемента
        {
            var min = array[0]; // переменная для определения минимального значения (для начала это нулевой элемент)
            var minIndex = 0; // в этой переменной храним индекс нулевого элемента

            for (int i = 1; i < array.Length; i++) // перебираем массив, начиная с элемента с индексом 1 (второй элемент)
            {
                if (array[i] < min) // если текущий элемент меньше минимального значения
                {
                    minIndex = i; // записываем индекс в переменную
                    min = array[i]; // записываем минимальное значение
                }
            }

            return minIndex; // возвращаем индекс минимального значения
        }
        
        private static int[] GenerateArray(int length) // метод генерации массива со случайными числами
        {
            var random = new Random(); // инициализируем объект генератора псевдослучайных чисел
            var array = new int[length]; // инициализируем массив указанной длины
            for (int i = 0; i < length; i++) // перебираем массив
            {
                array[i] = random.Next(10); // присваиваем текущему элементу массива случайное число до 10
            }

            return array; // возвращаем массив
        }

        private static void PrintArray(int[] array) // метод печати массива
        {
            Console.WriteLine("Массив:"); // вывод сообщения
            foreach (var item in array) // перебор массива
            {
                Console.Write($"{item} "); // выводим все элементы в строчки через пробел
            }
            Console.WriteLine(); // переводим курсор на новую строку
        }
    }
}