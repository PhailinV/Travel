namespace Countries.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BestSeason { get; set; } // Най-подходящият сезон
        public decimal Budget { get; set; } // Приблизителен бюджет
        public string Continent { get; set; } // Континент
    }
}
