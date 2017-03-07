using System.Collections.Generic;

namespace Shukratar.Domain.Category.Intelligence
{
    public class IntelligentCategory : Category
    {
        //public ICollection<GramStatistics> Grams { get; set; }

        public double Score { get; set; }

        public int TotalGramsCount { get; set; }
    }
}