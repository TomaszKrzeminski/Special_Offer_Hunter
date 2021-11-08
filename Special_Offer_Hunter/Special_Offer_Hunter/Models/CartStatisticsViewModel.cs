using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{

    public interface CartStatistics
    {
        public Dictionary<string, double> Expenses { get; set; }
    }


    public class CartStatisticWeek : CartStatistics
    {
        List<string> Week = new List<string>() { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };
        public CartStatisticWeek()
        {
            Expenses = new Dictionary<string, double>();
            foreach (var item in Week)
            {
                Expenses.Add(item, 0);
            }

        }
        public Dictionary<string, double> Expenses { get; set; }
    }


    public class CartStatisticMonth : CartStatistics
    {
        List<string> Month = new List<string>() { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };
        public CartStatisticMonth()
        {
            Expenses = new Dictionary<string, double>();
            foreach (var item in Month)
            {
                Expenses.Add(item, 0);
            }

        }
        public Dictionary<string, double> Expenses { get; set; }
    }

    public class CartStatisticYear : CartStatistics
    {
        List<string> YearList = new List<string>() { };
        public CartStatisticYear()
        {
            int Year = DateTime.Now.Year;
            int Stop = Year - 10;
            Expenses = new Dictionary<string, double>();
            for (int i = Year; i <= Stop; i--)
            {
                Expenses.Add(i.ToString(), 0);
            }


        }
        public Dictionary<string, double> Expenses { get; set; }
    }



    public class CartStatisticsViewModel
    {

        public CartStatisticWeek Week { get; set; }
        public CartStatisticMonth Month { get; set; }
        public CartStatisticYear Year { get; set; }

    }
}
