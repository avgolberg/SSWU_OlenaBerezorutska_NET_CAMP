using System;

namespace Cafe_CoR
{
    public abstract class CookBase : ICookHandler
    {
        public string Surname { get; protected set; }
        public bool IsBusy { get; protected set; }
        public Category Category { get; protected set; }
        public ICookHandler Next { get; set; }

        public event Action<ICookHandler> CookIsFree;

        public CookBase(string surname, Category category)
        {
            Surname = surname;
            IsBusy = false;
            Category = category;
        }

        public virtual Dish CookHandle(Dish dish)
        {
            if (Next != null)
                return Next.CookHandle(dish);

            else return null;
        }

        protected virtual void OnCookIsFree()
        {
            CookIsFree?.Invoke(this);
        }
    }
}
