using System;
using System.Globalization;

namespace Calculator
{
    internal class Program
    {
        enum MathOperation
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        static void Main()
        {
            while (true)
            {
                try
                {
                    double firstNumber = GetValidNumber("Введите первое число: ");
                    char sign = GetValidOperator();
                    double secondNumber = GetValidNumber("Введите второе число: ");

                    MathOperation operation = GetMathOperation(sign);

                    double result = PerformOperation(firstNumber, secondNumber, operation);

                    Console.WriteLine($"Результат: {result}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Попробуйте еще раз.");
                }
            }
        }

        static double GetValidNumber(string message)
        {
            double number;
            Console.Write(message);

            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out number))
            {
                Console.WriteLine("Ошибка. Введите корректное число.");
                Console.Write(message);
            }

            return number;
        }

        static char GetValidOperator()
        {
            string validOperators = "+-*/";
            Console.Write("Введите знак действия ( +, -, *, / ): ");
            char sign = Console.ReadKey().KeyChar;

            while (validOperators.IndexOf(sign) == -1)
            {
                Console.WriteLine("\nОшибка. Вы ввели неверный знак.");
                Console.Write("Введите знак действия ( +, -, *, / ): ");
                sign = Console.ReadKey().KeyChar;
            }

            Console.Write("\n");
            return sign;
        }

        static MathOperation GetMathOperation(char sign)
        {
            switch (sign)
            {
                case '+': return MathOperation.Addition;
                case '-': return MathOperation.Subtraction;
                case '*': return MathOperation.Multiplication;
                case '/': return MathOperation.Division;
                default: throw new ArgumentException("Неверный знак действия");
            }
        }

        static double PerformOperation(double firstNumber, double secondNumber, MathOperation operation)
        {
            switch (operation)
            {
                case MathOperation.Addition:
                    return firstNumber + secondNumber;
                case MathOperation.Subtraction:
                    return firstNumber - secondNumber;
                case MathOperation.Multiplication:
                    return firstNumber * secondNumber;
                case MathOperation.Division:
                    if (secondNumber == 0)
                    {
                        throw new DivideByZeroException("Ошибка. Делитель не может быть равным нулю.");
                    }
                    return firstNumber / secondNumber;
                default:
                    throw new ArgumentException("Неверный знак действия");
            }
        }
    }
}
