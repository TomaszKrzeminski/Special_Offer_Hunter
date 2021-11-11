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
        List<string> Week = new List<string>() { "poniedziałek", "wtorek", "środa", "czwartek", "piątek", "sobota", "niedziela" };
        public CartStatisticWeek()
        {
            Expenses = new Dictionary<string, double>();
            foreach (var item in Week)
            {
                Expenses.Add(item, 0);
            }

        }

        public string KeysToString()
        {
            Dictionary<string, double> d = Expenses;
            string text = "";

            foreach (var item in d.Keys)
            {
                text += item;
                text += ",";
            }

            text = text.Remove(text.Length - 1, 1);
            return text;

        }
        public string ValuesToString()
        {
            Dictionary<string, double> d = Expenses;
            string text = "";

            foreach (var item in d.Values)
            {
                text += item;
                text += ",";
            }

            text = text.Remove(text.Length - 1, 1);
            return text;
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
            for (int i = Stop; i <= Year; i++)
            {
                Expenses.Add(i.ToString(), 0);
            }


        }


        public Dictionary<string, double> Expenses { get; set; }
    }



    public class CartStatisticsViewModel
    {

        public CartStatisticsViewModel()
        {
            Week = new CartStatisticWeek();
            Month = new CartStatisticMonth();
            Year = new CartStatisticYear();
        }

        public CartStatisticWeek Week { get; set; }
        public CartStatisticMonth Month { get; set; }
        public CartStatisticYear Year { get; set; }

    }
}
