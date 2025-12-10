using System;

namespace lab6
{
    /// <summary>
    /// Класс Кот.
    /// </summary>
    public class Cat : IMeowable
    {
        /// <summary>Имя кота.</summary>
        public string Name { get; }

        /// <summary>Сколько раз кот мяукал.</summary>
        public int MeowCount { get; private set; }

        /// <summary>
        /// Создает нового кота.
        /// </summary>
        /// <param name="name">Имя кота.</param>
        /// <exception cref="ValidationException">Если имя не соответствует требованиям.</exception>
        public Cat(string name)
        {
            Validator.Validate(v => v.ValidateString(name, "Имя кота", true, 1, 30));
            Name = name;
        }

        /// <summary>
        /// Возвращает строковое представление кота.
        /// </summary>
        /// <returns>Строка в формате "кот: Имя".</returns>
        public override string ToString() => $"кот: {Name}";

        /// <summary>
        /// Кот мяукает один раз.
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу!");
            MeowCount++;
        }

        /// <summary>
        /// Кот мяукает указанное количество раз.
        /// </summary>
        /// <param name="n">Количество раз для мяуканья.</param>
        /// <exception cref="ValidationException">Если n не в допустимом диапазоне.</exception>
        public void Meow(int n)
        {
            Validator.Validate(v => v.ValidateInt(n, "Количество мяу", 1, 100));

            Console.Write($"{Name}: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(i == n - 1 ? "мяу!" : "мяу-");
                MeowCount++;
            }
            Console.WriteLine();
        }
    }
}