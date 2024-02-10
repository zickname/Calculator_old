using System;
using System.Globalization;
namespace Calculator
{
    internal class Program
    {
        enum MathOperation
        {
            Addition = '+',
            Subtraction = '-',
            Multiplication = '*',
            Division = '/'
        }
        static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture;
            while (true)
            {
                double firstNumber;
                double secondNumber;
                double result;
                char sign;

                Console.WriteLine("Введите первое число, затем знак действия(+,-,*,/), которое хотите совершить и второе число.");
                Console.Write("Введите первое число: ");

                while (!double.TryParse(Console.ReadLine(), out firstNumber))
                {
                    Console.WriteLine("Ошибка. Введите корректное число.");
                    Console.Write("Введите первое число: ");
                }

                Console.Write("Введите знак действия: ");
                
                sign = Convert.ToChar(Console.ReadLine() ?? string.Empty);

                while (!Enum.IsDefined(typeof(MathOperation), (int)sign))
                {
                    Console.WriteLine("Ошибка. Вы ввели неверный знак.");
                    Console.Write("Введите знак действия: ");

                    sign = Convert.ToChar(Console.ReadLine() ?? string.Empty);
                }

                Console.Write("Введите Второе число: ");

                while (!double.TryParse(Console.ReadLine(), out secondNumber))
                {
                    Console.WriteLine("Ошибка. Введите корректное число.");
                    Console.Write("Введите Второе число: ");
                }

                switch (sign)
                {
                    case '+':
                        result = firstNumber + secondNumber;
                        Console.WriteLine("Сумма ваших чисел равна " + result);
                        break;
                    case '-':
                        result = firstNumber - secondNumber;
                        Console.WriteLine("Разность ваших чисел равна " + result);
                        break;
                    case '*':
                        result = firstNumber * secondNumber;
                        Console.WriteLine("Произведение ваших чисел равно " + result);
                        break;
                    case '/':
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
