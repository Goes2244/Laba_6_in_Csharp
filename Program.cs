using System;
using System.Collections.Generic;

namespace lab6
{
    internal class Program
    {
        /// <summary>
        /// Главная точка входа в программу.
        /// </summary>
        static void Main(string[] args)
        {
            RunCatsTask();      // Задание 1
            RunFractions();     // Задание 2
        }
        
        static void RunCatsTask()
        {
            while (true)
            {
                Console.WriteLine("\nЗадание 1. Кот");
                Console.WriteLine("1 — Подзадание 1: Кот мяукает");
                Console.WriteLine("2 — Подзадание 2: Интерфейс Мяуканье");
                Console.WriteLine("3 — Подзадание 3: Количество мяуканий");
                Console.WriteLine("0 — Далее к дробям");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1_Subtask1();
                        break;
                    case "2":
                        Task1_Subtask2();
                        break;
                    case "3":
                        Task1_Subtask3();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }

        /// <summary>
        /// Подзадание 1: Кот мяукает.
        /// </summary>
        static void Task1_Subtask1()
        {
            Console.WriteLine("\nПодзадание 1: Кот мяукает");

            string name = Validator.GetValidatedString("имя кота", 1, 30);
            Cat cat = new Cat(name);

            while (true)
            {
                Console.WriteLine($"\nКот: {cat.Name}");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 — Мяукнуть ОДИН раз");
                Console.WriteLine("2 — Мяукнуть N раз");
                Console.WriteLine("0 — Вернуться в меню подзаданий");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        cat.Meow();
                        break;
                    case "2":
                        Console.WriteLine("Введите N:");
                        int n = Validator.GetValidatedInt("количество", 1, 30);
                        cat.Meow(n);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }

        /// <summary>
        /// Подзадание 2: Интерфейс Мяуканье.
        /// </summary>
        static void Task1_Subtask2()
        {
            Console.WriteLine("\nПодзадание 2: Интерфейс Мяуканье");

            List<IMeowable> meowers = new List<IMeowable>();

            Console.WriteLine("\nСколько обычных котов создать?");
            int catsCount = Validator.GetValidatedInt("количество", 1, 20);

            for (int i = 0; i < catsCount; i++)
            {
                Console.WriteLine($"Введите имя кота #{i+1}:");
                meowers.Add(new Cat(Validator.GetValidatedString("имя", 1, 30)));
            }

            Console.WriteLine("\nСколько робокотов создать?");
            int robotsCount = Validator.GetValidatedInt("количество", 0, 20);

            for (int i = 0; i < robotsCount; i++)
            {
                Console.WriteLine($"Введите модель робокота #{i+1}:");
                meowers.Add(new RobotCat(Validator.GetValidatedString("модель", 2, 30)));
            }

            Console.WriteLine("\nВызов MeowAll() для всех мяукающих объектов:");
            MeowUtils.MeowAll(meowers.ToArray());
        }

        /// <summary>
        /// Подзадание 3: Количество мяуканий.
        /// </summary>
        static void Task1_Subtask3()
        {
            Console.WriteLine("\nПодзадание 3: Количество мяуканий");
            
            Cat cat = new Cat(Validator.GetValidatedString("имя кота"));

            int before = cat.MeowCount;

            Console.WriteLine("Сколько раз вызвать общий метод MeowAll() для этого кота?");
            int times = Validator.GetValidatedInt("количество", 1, 20);

            for (int i = 0; i < times; i++)
                MeowUtils.MeowAll(cat);

            int after = cat.MeowCount;

            Console.WriteLine($"Кот {cat.Name} мяукал {after - before} раз во время работы метода.");
        }

        /// <summary>
        /// Задание 2: Дроби.
        /// </summary>
        static void RunFractions()
        {
            Console.WriteLine("\nЗадание 2. Дроби");

            Console.WriteLine("\nВведите первую дробь:");
            int num1 = Validator.GetValidatedInt("числитель");
            int den1 = Validator.GetValidatedIntNotZero("знаменатель");
            Fraction f1 = new Fraction(num1, den1);

            Console.WriteLine("\nВведите вторую дробь:");
            int num2 = Validator.GetValidatedInt("числитель");
            int den2 = Validator.GetValidatedIntNotZero("знаменатель");
            Fraction f2 = new Fraction(num2, den2);

            Console.WriteLine("\nВведите третью дробь:");
            int num3 = Validator.GetValidatedInt("числитель");
            int den3 = Validator.GetValidatedIntNotZero("знаменатель");
            Fraction f3 = new Fraction(num3, den3);

            Console.WriteLine("\nВведите целое число для операций:");
            int n = Validator.GetValidatedInt("целое число");

            Console.WriteLine("\nПримеры операций с дробями:");
            Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
            Console.WriteLine($"{f2} - {f3} = {f2 - f3}");
            Console.WriteLine($"{f2} * {f3} = {f2 * f3}");
            
            try
            {
                Console.WriteLine($"{f3} / {f2} = {f3 / f2}");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"{f3} / {f2} = Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nПримеры операций с целыми числами:");
            Console.WriteLine($"{f1} + {n} = {f1 + n}");
            Console.WriteLine($"{f2} - {n} = {f2 - n}");
            Console.WriteLine($"{f2} * {n} = {f2 * n}");
            
            try
            {
                Console.WriteLine($"{f3} / {n} = {f3 / n}");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"{f3} / {n} = Ошибка: {ex.Message}");
            }
            
            Console.WriteLine($"{n} + {f1} = {n + f1}");
            Console.WriteLine($"{n} - {f2} = {n - f2}");
            Console.WriteLine($"{n} * {f2} = {n * f2}");
            
            try
            {
                Console.WriteLine($"{n} / {f3} = {n / f3}");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"{n} / {f3} = Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nСравнение дробей:");
            Console.WriteLine($"{f1} == {f2}: {f1.Equals(f2)}");
            Fraction f1Copy = new Fraction(num1, den1);
            Console.WriteLine($"{f1} == {f1Copy} (копия): {f1.Equals(f1Copy)}");

            Console.WriteLine("\nЦепочка:");
            try
            {
                Console.WriteLine($"f1.sum(f2).div(f3).minus(5) = {f1.Sum(f2).Div(f3).Minus(5)}");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"f1.sum(f2).div(f3).minus(5) = Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nКлонирование:");
            var clone = (Fraction)f1.Clone();
            Console.WriteLine($"Оригинал: {f1}, Клон: {clone}");
            Console.WriteLine($"Оригинал == Клон: {f1.Equals(clone)}");

            Console.WriteLine("\nКэширование:");
            var cached = new CachedFraction(num1, den1);
            Console.WriteLine($"Первый вызов ToDouble(): {cached.ToDouble()}");
            Console.WriteLine($"Второй вызов ToDouble(): {cached.ToDouble()}");
            Console.WriteLine("Изменяем числитель(умножаем на 2)");
            cached.SetNumerator(num1 * 2);
            Console.WriteLine($"Третий вызов ToDouble() (после изменения): {cached.ToDouble()}");
            Console.WriteLine($"Четвертый вызов ToDouble(): {cached.ToDouble()}");
        }
    }
}