using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe_CoR
{
    public class Cook : CookBase
    {
        public Cook(string surname, Category category) : base(surname, category)
        {

        }

        public override Dish CookHandle(Dish dish)
        {
            if (Category == dish.Category && !IsBusy)
            {
                IsBusy = true;
                Task.Run(() => CookSome(dish));
                return dish;
            }
            else return base.CookHandle(dish);
        }
        private void CookSome(Dish dish)
        {
            Console.WriteLine($"{this} COOKS {dish} {DateTime.Now:T}\n");
            Thread.Sleep(dish.CookingTime * 1000);
            IsBusy = false;
            Console.WriteLine($"- {this} ENDS to cook {dish} {DateTime.Now:T}\n");
            OnCookIsFree();
        }

        public override string ToString()
        {
            return $"{Surname} ({Category}, {IsBusy})";
        }
    }
}
