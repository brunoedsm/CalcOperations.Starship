using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalcOperations.Starship.Business.Extensions
{
    public static class StringExtensions
    {
        public static double ToHours(this string description)
        {
            if(!description.Any(char.IsDigit))
                return 0;
            var amountTime = int.Parse(Regex.Match(description, @"\d+").Value);

            var descrTime = Regex.Replace(description, @"[^a-zA-Z]+", String.Empty);    

            switch (descrTime.ToUpper())
            {
                case string a when a.Contains("DAY"):
                    return 24 * amountTime;
                case string a when a.Contains("WEEK"):
                    return 168 * amountTime;
                case string a when a.Contains("MONTH"):
                    return 730 * amountTime;
                case string a when a.Contains("YEAR"):
                    return 8760 * amountTime;
                default:
                    return 0;
            }
        }

    }

}