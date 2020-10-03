using System;
using System.Text.RegularExpressions;

namespace CalcOperations.Starship.Business.Extensions
{
    public static class StringExtensions
    {
        public static double ToHour(this string description)
        {
            var amountTime = int.Parse(Regex.Match(description, @"\d+").Value);

            var descrTime = Regex.Replace(description, @"[^A-Z]+", String.Empty);    

            switch (description.ToUpperInvariant())
            {
                case "Day":
                    return 24 * amountTime;
                case "Week":
                    return 168 * amountTime;
                case "Month":
                    return 730 * amountTime;
                case "Year":
                    return 8760 * amountTime;
                default:
                    return 0;
            }
        }

    }

}