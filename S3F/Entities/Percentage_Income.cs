using System;

namespace SPS.Entities
{
    public class Percentage_Income
    {
        public int IncomeId { get; set; }
        public byte PercentageOfIncome { get; set; }
        public DateTime Register { get; set; }
        public bool Enabled { get; set; }

    }
}