namespace lab6
{
    /// <summary>
    /// Утилиты для объектов, которые умеют мяукать.
    /// </summary>
    public static class UtilitMeow
    {
        /// <summary>
        /// Вызывает Meow() у всех переданных объектов.
        /// </summary>
        /// <param name="arr">Массив объектов, реализующих IMeowable.</param>
        public static void MeowAll(params InterfaceMeow[] arr)
        {
            foreach (var m in arr)
                m.Meow();
        }
    }
}