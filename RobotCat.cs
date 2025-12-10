using System;

namespace lab6
{
    /// <summary>
    /// Робот-кот, тоже умеет мяукать.
    /// </summary>
    public class RobotCat : IMeowable
    {
        /// <summary>Модель робота-кота.</summary>
        public string Model { get; }

        /// <summary>
        /// Создает нового робота-кота.
        /// </summary>
        /// <param name="model">Модель робота.</param>
        /// <exception cref="ValidationException">Если модель не соответствует требованиям.</exception>
        public RobotCat(string model)
        {
            Validator.Validate(v => v.ValidateString(model, "Модель робота", true, 2, 30));
            Model = model;
        }

        /// <summary>
        /// Робот-кот издает электронное мяуканье.
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{Model}: электронное мяу!");
        }

        /// <summary>
        /// Возвращает строковое представление робота-кота.
        /// </summary>
        /// <returns>Строка в формате "робот-кот: Модель".</returns>
        public override string ToString() => $"робот-кот: {Model}";
    }
}