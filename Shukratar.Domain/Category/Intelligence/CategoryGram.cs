namespace Shukratar.Domain.Category.Intelligence
{
    public class CategoryGram
    {
        public CategoryGram(string category, string gram, double count)
        {
            Category = category.Trim();
            Gram = gram;
            Count = count;
        }

        public int Id { get; set; }

        public string Category { get; private set; }

        public string Gram { get; private set; }

        public double Count { get; private set; }
    }
}
