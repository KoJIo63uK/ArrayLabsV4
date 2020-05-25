using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение (операнды и знаки операции отделите пробелом!)"); // вывод сообщения на экран
            Console.WriteLine("Допускаются операции сложения и вычитания"); // вывод сообщения на экран

            var str = Console.ReadLine(); // читаем выражение
            
            var operands = ParseOperands(str); // вызываем метод парсинга операндов
            var operations = ParseOperations(str); // вызываем метод парсинга операций

            if (IsValidExpression(str)) // если валидация выражения прошла успешно
            {
                int result;
                result = DoOperation(operands[0], operands[1], operations[0]); // вызываем метод выполнения операции с первыми двумя операндами
                result = DoOperation(result, operands[2], operations[1]); // вызываем метод выполнения операции с результатом вычисления и третьим операндом

                Console.WriteLine($"Результат выражения равен: {result}"); // выводим результат на экран
            }
            
            Console.ReadKey(); // Что бы консоль сама не закрылась читаем anykey
        }
        

        private static int DoOperation(int operand1, int operand2, string operation) // метод выполнения операции
        {
            var result = operation == "+" ? operand1 + operand2 : operand1 - operand2; // если знак операции + складываем иначе вычитаем

            return result; // возвращаем результат операции
        }
        
        private static int[] ParseOperands(string str) // метод парсинга операторов
        {
            var operands = new int[3]; // инициализация массива длиной 3
            var parseString = str.Split(' '); // разбираем строку на массив по разделителю пробел
            operands[0] = int.Parse(parseString[0]); //
            operands[1] = int.Parse(parseString[2]); // присваиваем соответствующие значения
            operands[2] = int.Parse(parseString[4]); //

            return operands; // возвращаем массив с операторами
        }

        private static string[] ParseOperations(string str) // массив парсинга операций
        {
            var operations = new string[2]; // инициализация массива длиной 2 строки
            var parseString = str.Split(' '); // разбираем строку на массив по разделителю пробел
            operations[0] = parseString[1]; //
            operations[1] = parseString[3]; // заполнили массив операций

            return operations; // вернули полученный массив
        }

        private static bool IsValidExpression(string str) // метод валидации выражения
        {
            var strArr = str.Split(' '); // разбираем строку на массив по разделителю пробел

            if (strArr.Length != 5) // если длина выражения не равна 5
            {
                Console.WriteLine("Ошибка в выражении!!!"); // выводим на экран
                return false; // возвращаем лож
            }

            return IsValidOperands(strArr) && IsValidOperations(strArr); // возвращаем результат двух валидаций
        }

        private static bool IsValidOperands(string[] strArr) // метод валидации операндов
        {
            for (int i = 0; i < strArr.Length; i+=2) // перебираем элементы начиная с 0 через 1
            {
                if (strArr[i].Length > 2) // если длина операнда больше 2
                {
                    Console.WriteLine("Длина одного из операндов больше 2 цифр!!!"); // выводим сообщение
                    return false; // валидация не пройдена
                }

                int operand; // переменная нужна для следующего метода
                if (!int.TryParse(strArr[i], out operand)) // если операнд не число
                {
                    Console.WriteLine("Один из операндов не число!!!"); // выводим ошибку
                    return false; // валидация не пройдена
                }
            }

            return true; // валидация пройдена
        }

        private static bool IsValidOperations(string[] strArr) // метод валидации знаков операций
        {
            for (int i = 1; i < strArr.Length; i+=2) // попребираем массив начиная со второго элемента через 1
            {
                if (strArr[i] != "+" && strArr[i] != "-") // если это не + и не - 
                {
                    Console.WriteLine("Введена недопустимая операция!!!"); // ругаемся
                    return false; // валидация не пройдена
                }
            }

            return true; // валидация пройдена
        }
    }
}