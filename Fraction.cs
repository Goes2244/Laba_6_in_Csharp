using System;

namespace lab6
{
    /// <summary>
    /// Дробь с операциями.
    /// </summary>
    public class Fraction : ICloneable
    {
        /// <summary>
        /// Числитель дроби.
        /// </summary>
        public int Numerator { get; protected set; }
        
        /// <summary>
        /// Знаменатель дроби.
        /// </summary>
        public int Denominator { get; protected set; }

        /// <summary>
        /// Создает новый экземпляр дроби.
        /// </summary>
        /// <param name="num">Числитель.</param>
        /// <param name="den">Знаменатель.</param>
        /// <exception cref="ValidationException">Если знаменатель равен 0.</exception>
        public Fraction(int num, int den)
        {
            Validator.Validate(v =>
            {
                v.ValidateIntNotZero(den, "Знаменатель");
            });

            Numerator = num;
            Denominator = den;
        }

        /// <summary>
        /// Возвращает строковое представление дроби.
        /// </summary>
        /// <returns>Строка в формате "числитель/знаменатель".</returns>
        public override string ToString() => $"{Numerator}/{Denominator}";

        /// <summary>
        /// Сложение двух дробей.
        /// </summary>
        public static Fraction operator +(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                         a.Denominator * b.Denominator);

        /// <summary>
        /// Вычитание двух дробей.
        /// </summary>
        public static Fraction operator -(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                         a.Denominator * b.Denominator);

        /// <summary>
        /// Умножение двух дробей.
        /// </summary>
        public static Fraction operator *(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Numerator,
                         a.Denominator * b.Denominator);

        /// <summary>
        /// Деление двух дробей.
        /// </summary>
        /// <exception cref="ValidationException">Если числитель делителя равен 0.</exception>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Validator.Validate(v => v.ValidateIntNotZero(b.Numerator, "Числитель делителя"));
            return new Fraction(a.Numerator * b.Denominator,
                                a.Denominator * b.Numerator);
        }

        /// <summary>
        /// Сложение дроби с целым числом.
        /// </summary>
        public static Fraction operator +(Fraction a, int n) => new(a.Numerator + n * a.Denominator, a.Denominator);
        
        /// <summary>
        /// Вычитание целого числа из дроби.
        /// </summary>
        public static Fraction operator -(Fraction a, int n) => new(a.Numerator - n * a.Denominator, a.Denominator);
        
        /// <summary>
        /// Умножение дроби на целое число.
        /// </summary>
        public static Fraction operator *(Fraction a, int n) => new(a.Numerator * n, a.Denominator);
        
        /// <summary>
        /// Деление дроби на целое число.
        /// </summary>
        public static Fraction operator /(Fraction a, int n)
        {
            Validator.Validate(v => v.ValidateIntNotZero(n, "Делитель"));
            return new Fraction(a.Numerator, a.Denominator * n);
        }
        
        /// <summary>
        /// Сложение целого числа с дробью.
        /// </summary>
        public static Fraction operator +(int n, Fraction a) => a + n;
        
        /// <summary>
        /// Вычитание дроби из целого числа.
        /// </summary>
        public static Fraction operator -(int n, Fraction a) => new(n * a.Denominator - a.Numerator, a.Denominator);
        
        /// <summary>
        /// Умножение целого числа на дробь.
        /// </summary>
        public static Fraction operator *(int n, Fraction a) => a * n;
        
        /// <summary>
        /// Деление целого числа на дробь.
        /// </summary>
        public static Fraction operator /(int n, Fraction a)
        {
            Validator.Validate(v => v.ValidateIntNotZero(a.Numerator, "Числитель делителя"));
            return new Fraction(n * a.Denominator, a.Numerator);
        }

        /// <summary>
        /// Сумма текущей дроби с другой дробью.
        /// </summary>
        /// <param name="f">Другая дробь.</param>
        /// <returns>Новая дробь - результат сложения.</returns>
        public Fraction Sum(Fraction f) => this + f;
        
        /// <summary>
        /// Вычитание целого числа из текущей дроби.
        /// </summary>
        /// <param name="n">Целое число.</param>
        /// <returns>Новая дробь - результат вычитания.</returns>
        public Fraction Minus(int n) => this - n;
        
        /// <summary>
        /// Деление текущей дроби на другую дробь.
        /// </summary>
        /// <param name="f">Делитель-дробь.</param>
        /// <returns>Новая дробь - результат деления.</returns>
        public Fraction Div(Fraction f) => this / f;

        /// <summary>
        /// Сравнивает текущий объект с другим объектом.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если дроби равны (числитель и знаменатель одинаковые).</returns>
        public override bool Equals(object obj)
        {
            if (obj is not Fraction f) return false;
            return f.Numerator == Numerator && f.Denominator == Denominator;
        }

        /// <summary>
        /// Возвращает хэш-код дроби.
        /// </summary>
        /// <returns>Хэш-код.</returns>
        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        /// <summary>
        /// Создает копию текущей дроби.
        /// </summary>
        /// <returns>Новая дробь с такими же значениями числителя и знаменателя.</returns>
        public object Clone() => new Fraction(Numerator, Denominator);
    }
}