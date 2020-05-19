using System;

namespace ExploreCalifornia.Models
{
    public class FormattingServices
    {
        public string AsReadableDate(DateTime date)
        {
            return date.ToString("d");
        }
    }
}