namespace SweetKompasPlugin.Model
{
    /// <summary>
    /// Интерфейс габаритов конфеты
    /// </summary>
    public interface ICandy
    {
        /// <summary>
        /// Ширина конфеты
        /// </summary>
        double Width
        {
            get;
        }

        /// <summary>
        /// Высота конфеты
        /// </summary>
        double Height
        {
            get;
        }

        /// <summary>
        /// Длина конфеты
        /// </summary>
        double Length
        {
            get;
        }
    }
}
