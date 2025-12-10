namespace lab6
{
    /// <summary>
    /// Интерфейс для получения double-значения и установки полей дроби.
    /// </summary>
    public interface IFractionAdvanced
    {
        /// <summary>
        /// Возвращает десятичное представление дроби.
        /// </summary>
        /// <returns>Значение дроби как double.</returns>
        double ToDouble();
        
        /// <summary>
        /// Устанавливает новое значение числителя.
        /// </summary>
        /// <param name="n">Новый числитель.</param>
        void SetNumerator(int n);
        
        /// <summary>
        /// Устанавливает новое значение знаменателя.
        /// </summary>
        /// <param name="d">Новый знаменатель.</param>
        /// <exception cref="ValidationException">Если знаменатель равен 0.</exception>
        void SetDenominator(int d);
    }
}