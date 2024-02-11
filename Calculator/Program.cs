using System;
using System.Globalization;
using static System.Globalization.CultureInfo;

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
                double firstNumber;
                double secondNumber;
                double result;
                char sign;
                string mathOperators = "+-*/";
                MathOperation operation;

                Console.WriteLine("Введите первое число, затем знак действия(+,-,*,/), которое хотите совершить и второе число.");
                Console.Write("Введите первое число: ");

                while (!double.TryParse(Console.ReadLine(),NumberStyles.Float,CurrentCulture, out firstNumber))
                {
                    Console.WriteLine("Ошибка. Введите корректное число.");
                    Console.Write("Введите первое число: ");
                }

                Console.Write("Введите знак действия ( +, -, *, / ): ");
                
                sign = Convert.ToChar(Console.ReadKey().KeyChar);

                while (!mathOperators.Contains(sign.ToString()))
                {
                    Console.WriteLine("\nОшибка. Вы ввели неверный знак.");
                    Console.Write("Введите знак действия ( +, -, *, / ): ");

                    sign = Convert.ToChar(Console.ReadKey().KeyChar);
                }

                operation = (MathOperation)mathOperators.IndexOf(sign);
                
                Console.Write("\nВведите Второе число: ");

                while (!double.TryParse(Console.ReadLine(),NumberStyles.Float, CurrentCulture, out secondNumber))
                {
                    Console.WriteLine("Ошибка. Введите корректное число.");
                    Console.Write("Введите Второе число: ");
                }

                switch (operation)
                {
                    case MathOperation.Addition:
                        result = firstNumber + secondNumber;
                        Console.WriteLine("Сумма ваших чисел равна " + result);
                        break;
                    case MathOperation.Subtraction:
                        result = firstNumber - secondNumber;
                        Console.WriteLine("Разность ваших чисел равна " + result);
                        break;
                    case MathOperation.Multiplication:
                        result = firstNumber * secondNumber;
                        Console.WriteLine("Произведение ваших чисел равно " + result);
                        break;
                    case MathOperation.Division:
                        if (secondNumber == 0)
                        {
                            Console.WriteLine("Ошибка. Делитель не может быть равным нулю.");
                            break;
                        }
                        else
                        {
                            result = firstNumber / secondNumber;
                            Console.WriteLine("Частное ваших чисел равна " + result);
                            break;
                        }
                    default:
                        Console.WriteLine("Ошибка. Вы ввели неверный знак.");
                        break;
                }
            }
        }
    }
}
