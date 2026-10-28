using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    /// <summary>
    /// Класс для расчёта скидок в системе заказов компании «Ювелир-Люкс»
    /// (продажа ювелирных изделий).
    /// </summary>
    public class DiscountCalculator
    {
        /// <summary>
        /// Процент скидки для товаров, по которым не было заказов
        /// в прошлом месяце (для компании «Ювелир-Люкс» — 30%).
        /// </summary>
        public const decimal DiscountPercent = 0.30m;

        /// <summary>
        /// Рассчитывает цену со скидкой 30%, если по товару
        /// не было заказов в прошлом месяце.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара (в рублях).</param>
        /// <param name="hasOrdersLastMonth">
        /// Были ли заказы по товару в прошлом месяце.
        /// </param>
        /// <returns>
        /// Цена со скидкой, если заказов не было,
        /// иначе — базовая цена.
        /// </returns>
        public decimal GetDiscountedPrice(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (hasOrdersLastMonth)
                return basePrice;

            return basePrice * (1m - DiscountPercent);
        }

        /// <summary>
        /// Формирует текстовое описание правила скидки
        /// для вывода в консоль.
        /// </summary>
        /// <returns>Строка с описанием правила скидки.</returns>
        public string GetDiscountDescription()
        {
            return "Скидка 30% предоставляется, если по товару не было заказов в прошлом месяце.";
        }
    }

    /// <summary>
    /// Главный класс программы — точка входа.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу. Демонстрирует работу
        /// <see cref="DiscountCalculator.GetDiscountedPrice"/>.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var calculator = new DiscountCalculator();

            decimal price = 10000m;
            decimal discounted = calculator.GetDiscountedPrice(price, false);
            decimal withoutDiscount = calculator.GetDiscountedPrice(price, true);

            Console.WriteLine(calculator.GetDiscountDescription());
            Console.WriteLine();
            Console.WriteLine($"Базовая цена: {price}");
            Console.WriteLine($"Цена с скидкой (заказов не было): {discounted}");
            Console.WriteLine($"Цена без скидки (заказы были): {withoutDiscount}");
            Console.WriteLine();
            Console.WriteLine("Автор: Читаев И.С., группа И-43");
            Console.ReadKey();
        }
    }
}
