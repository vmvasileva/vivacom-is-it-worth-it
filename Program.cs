using System;
using System.Text;

namespace Is_It_Worth_It
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //TODO:
            // - You could use DateTime.Parse to read the contract's start date and end date
            // - You could use TimeSpan to make calculations about the dates
            Console.WriteLine("Как се казвате?");
            string nameOfUser = Console.ReadLine();

            Console.WriteLine("Моля въведете сумата, която плащате по договор, за Вашия абонаментен план: ");
            double currentPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Каква е месечната такса към услугите, които ползвате, на непромоционални условия? ");
            double priceWithoutPromotion = double.Parse(Console.ReadLine());

            Console.WriteLine("приблизителните месеци, за които се плащали услугата.");
            double paidMonths = Math.Ceiling(double.Parse(Console.ReadLine()));

            Console.WriteLine("Договорът за колко месеца е подписан?");
            int monthsOfContract = int.Parse(Console.ReadLine());

            Console.WriteLine("Закупили ли сте устройство на промоционална цена при подписването на договора?");
            string phone = Console.ReadLine();

            //изчисления за закупено устройство
            double neustoikaPhone = 0;
            if (phone == "yes")
            {
                Console.WriteLine("На каква цена сте закупили стройството?");
                double phonePrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Каква е непромоционалната цена на устройството?");
                double phoneWithoutDiscount = double.Parse(Console.ReadLine());
                neustoikaPhone = phoneWithoutDiscount - phonePrice;
            }

            double neustoikaNaMesec = 0;

            //изчисления за размер на месечната неустойка
            if (currentPrice == priceWithoutPromotion)
            {
                neustoikaNaMesec = 0;
            }
            else if (priceWithoutPromotion > currentPrice)
            {
                neustoikaNaMesec = priceWithoutPromotion - currentPrice;
            }

            //изчисления при прекъсване на договора
            double taxes3Months = 3 * priceWithoutPromotion;
            double neustoikiUsedMonths = neustoikaNaMesec * paidMonths;
            double totalTaxesForBreakingContract = taxes3Months + neustoikiUsedMonths + neustoikaPhone;

            //изчисления при продължаване на договора
            double taxesUntillEndOfContract = currentPrice * (monthsOfContract - paidMonths);
            bool shouldWait = totalTaxesForBreakingContract > taxesUntillEndOfContract;
            bool shouldBreak = taxesUntillEndOfContract > totalTaxesForBreakingContract;
            if (shouldWait)
            {
                Console.WriteLine($"{nameOfUser}, таксите, които би следвало да заплатите до края на Вашия договор са на стойност {taxesUntillEndOfContract} лева." +
                    $" Таксите при прекъсване на договора с месечно предизвестие са на стойност {totalTaxesForBreakingContract}.\n" +
                    $"Във Вашия случай е по-евтино," +
                    $"ако изчакате изтичането на договора си. В този случай трябва да подадете месечно предизвестие (30 дена преди приключване" +
                    $"на договора, но може и няколко дена преди това.)");
            }
            else if (shouldBreak)
            {
                Console.WriteLine($"{nameOfUser}, таксите, които би следвало да заплатите до края на Вашия договор са на стойност {taxesUntillEndOfContract} лева." +
                   $" Таксите при прекъсване на договора с месечно предизвестие са на стойност {totalTaxesForBreakingContract}. Стойностите се изчисляват " +
                   $" като 3 месечна вноска на плана Ви на непролоционална цена, неустойка (сумата от разликата между редовната и промоционалната цена на услугите), " +
                   $"както и разлицата в цената на устройство (ако сте закупили такова от нас при подписване на договора).\n" +
                   $"Във Вашия случай е по-евтино" +
                   $"да прекъснете договора си. За целта можете да го направите онлайн през сайта на Виваком, чрез изпращане на писмо до централен офис" +
                   $"или чрез упълномощяване на трето лице. Ако предпочетете последния вариант трябва пълномощното да бъде нотариално заверено и в него да " +
                   $"бъде упоменато, че може да се използва за отказване от договор към Виваком.");
            }
            else
            {
                Console.WriteLine($"{nameOfUser}, таксите, които би следвало да заплатите до края на Вашия договор са на стойност {taxesUntillEndOfContract} " +
                    $"лева. Таксите при прекъсване на договора с месечно предизвестие са на стойност {totalTaxesForBreakingContract}. Във вашия случай няма " +
                    $"значение дали решите да прекъснете договора си, или да продължите да изплащате сумите до изтичане на условията");
            }
        }
    }
}
