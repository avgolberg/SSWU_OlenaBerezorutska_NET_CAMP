using System;

namespace Cafe_CoR
{
    public interface ICookHandler
    {
        string Surname { get; }
        bool IsBusy { get; }
        Category Category { get; }
        ICookHandler Next { get; set; }
        Dish CookHandle(Dish dish);

        event Action<ICookHandler> CookIsFree;
    }
}
