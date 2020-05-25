using System;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: "); // выводим сообщение на экран
            var length = int.Parse(Console.ReadLine()); // читаем длину массива
            var array = InitArray(length); // вызываем метод инициализации массива
            var oddItemsSumm = GetOddItemsSumm(array); // вызываем метод суммирования нечетных элеметов
            Console.WriteLine($"Сумма нечетных элементов равна: {oddItemsSumm}"); // выводим результат на экран
            
            Console.ReadKey(); // Что бы консоль сама не закрылась читаем anykey
        }
        
        private static int[] InitArray(int length) // метод инициализации массива
        {
            var array = new int[length]; // инициализация массива указанной длины

            for (int i = 0; i < length; i++) // перебираем массив
            {
                Console.Write($"Введите значение Array[{i}]: "); // просим ввести текущий элемент
                array[i] = int.Parse(Console.ReadLine()); // присваиваем текущему элементу значение, введенное с клавиатуры
            }

            return array; // возвращаем массив
        }

        private static int GetOddItemsSumm(int[] array) // метод подсчета суммы нечетных элементов
        {
            var summ = 0; // инициализируем переменную для подсчета суммы
            for (int i = 0; i < array.Length; i++) // перебираем массив
            {
                if (array[i] % 2 != 0) // если остаток от деления текущего элемента массива на 2 не равен 0
                {
                    summ += array[i]; // прибавляем к сумме значение текущего элемента
                }
            }

            return summ; // возвращаем сумму
        }
    }
}