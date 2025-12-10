namespace lab6
{
    /// <summary>
    /// Дробь с кэшированием double-значения.
    /// </summary>
    public class CachedFraction : Fraction, IFractionAdvanced
    {
        private double? _cached;

        /// <summary>
        /// Создает новый экземпляр CachedFraction.
        /// </summary>
        /// <param name="n">Числитель.</param>
        /// <param name="d">Знаменатель.</param>
        public CachedFraction(int n, int d) : base(n, d) { }

        /// <summary>
        /// Возвращает десятичное представление дроби с кэшированием.
        /// </summary>
        /// <returns>Значение дроби как double.</returns>
        public double ToDouble()
        {
            if (_cached == null)
                _cached = (double)Numerator / Denominator;

            return _cached.Value;
        }

        /// <summary>
        /// Устанавливает новое значение числителя.
        /// </summary>
        /// <param name="n">Новый числитель.</param>
        public void SetNumerator(int n)
        {
            Numerator = n;
            _cached = null;
        }

        /// <summary>
        /// Устанавливает новое значение знаменателя.
        /// </summary>
        /// <param name="d">Новый знаменатель.</param>
        /// <exception cref="ValidationException">Если знаменатель равен 0.</exception>
        public void SetDenominator(int d)
        {
            Validator.Validate(v => v.ValidateIntNotZero(d, "Знаменатель"));
            Denominator = d;
            _cached = null;
        }
    }
}
