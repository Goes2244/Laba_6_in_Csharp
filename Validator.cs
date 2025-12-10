using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6
{
    /// <summary>
    /// Валидатор для проверки входных данных.
    /// </summary>
    public class Validator
    {
        private readonly List<string> _errors = new();

        /// <summary>
        /// Проверяет, прошла ли валидация успешно.
        /// </summary>
        public bool IsValid => !_errors.Any();
        
        /// <summary>
        /// Список ошибок валидации.
        /// </summary>
        public List<string> Errors => _errors;

        /// <summary>
        /// Добавляет ошибку в список.
        /// </summary>
        /// <param name="msg">Текст ошибки.</param>
        public void AddError(string msg) => _errors.Add(msg);

        /// <summary>
        /// Валидирует строку.
        /// </summary>
        /// <param name="value">Значение для проверки.</param>
        /// <param name="fieldName">Название поля.</param>
        /// <param name="required">Обязательное ли поле.</param>
        /// <param name="min">Минимальная длина.</param>
        /// <param name="max">Максимальная длина.</param>
        /// <returns>Текущий экземпляр Validator для цепочки вызовов.</returns>
        public Validator ValidateString(string value, string fieldName,
            bool required = false, int? min = null, int? max = null)
        {
            if (required && string.IsNullOrWhiteSpace(value))
                _errors.Add($"{fieldName} обязательно");

            if (min.HasValue && value.Length < min)
                _errors.Add($"{fieldName} минимум {min} символов");

            if (max.HasValue && value.Length > max)
                _errors.Add($"{fieldName} максимум {max} символов");

            return this;
        }

        /// <summary>
        /// Валидирует целое число.
        /// </summary>
        /// <param name="value">Значение для проверки.</param>
        /// <param name="fieldName">Название поля.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <returns>Текущий экземпляр Validator для цепочки вызовов.</returns>
        public Validator ValidateInt(int value, string fieldName,
            int? min = null, int? max = null)
        {
            if (min.HasValue && value < min)
                _errors.Add($"{fieldName} ≥ {min}");

            if (max.HasValue && value > max)
                _errors.Add($"{fieldName} ≤ {max}");

            return this;
        }

        /// <summary>
        /// Проверяет, что целое число не равно нулю.
        /// </summary>
        /// <param name="value">Значение для проверки.</param>
        /// <param name="fieldName">Название поля.</param>
        /// <returns>Текущий экземпляр Validator для цепочки вызовов.</returns>
        public Validator ValidateIntNotZero(int value, string fieldName)
        {
            if (value <= 0)
                _errors.Add($"{fieldName} не может быть меньше либо равен нулю");

            return this;
        }

        /// <summary>
        /// Выбрасывает исключение, если валидация не прошла.
        /// </summary>
        /// <exception cref="ValidationException">Если есть ошибки валидации.</exception>
        public void ThrowIfInvalid()
        {
            if (!IsValid)
                throw new ValidationException(string.Join("; ", _errors));
        }

        /// <summary>
        /// Статический метод для быстрой валидации.
        /// </summary>
        /// <param name="action">Действие с валидатором.</param>
        /// <exception cref="ValidationException">Если есть ошибки валидации.</exception>
        public static void Validate(Action<Validator> action)
        {
            var v = new Validator();
            action(v);
            v.ThrowIfInvalid();
        }

        /// <summary>
        /// Получает валидированное целое число от пользователя.
        /// </summary>
        /// <param name="fieldName">Название поля.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <returns>Валидное целое число.</returns>
        public static int GetValidatedInt(string fieldName, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите {fieldName}: ");
                    int val = int.Parse(Console.ReadLine());

                    Validate(v => v.ValidateInt(val, fieldName, min, max));
                    return val;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Получает валидированное целое число, не равное нулю.
        /// </summary>
        /// <param name="fieldName">Название поля.</param>
        /// <returns>Валидное целое число, не равное нулю.</returns>
        public static int GetValidatedIntNotZero(string fieldName)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите {fieldName} (n>0): ");
                    int val = int.Parse(Console.ReadLine());

                    Validate(v => v.ValidateIntNotZero(val, fieldName));
                    return val;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Получает валидированную строку от пользователя.
        /// </summary>
        /// <param name="fieldName">Название поля.</param>
        /// <param name="min">Минимальная длина.</param>
        /// <param name="max">Максимальная длина.</param>
        /// <returns>Валидная строка.</returns>
        public static string GetValidatedString(string fieldName, int min = 1, int max = 100)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите {fieldName}: ");
                    string val = Console.ReadLine();

                    Validate(v => v.ValidateString(val, fieldName, true, min, max));
                    return val;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
        }
    }

    /// <summary>
    /// Исключение, возникающее при ошибке валидации.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Создает новый экземпляр ValidationException.
        /// </summary>
        /// <param name="m">Сообщение об ошибке.</param>
        public ValidationException(string m) : base(m) { }
    }
}