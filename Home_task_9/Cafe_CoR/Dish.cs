namespace Cafe_CoR
{
    public class Dish
    {
        public string Title { get; private set; }
        public int CookingTime { get; private set; }
        public Category Category { get; private set; }

        public Dish(string title, Category category, int cookingTime)
        {
            Title = title;
            Category = category;
            CookingTime = cookingTime;
        }
        public override string ToString()
        {
            return $"{Title} ({CookingTime} хв)";
        }
    }
}
