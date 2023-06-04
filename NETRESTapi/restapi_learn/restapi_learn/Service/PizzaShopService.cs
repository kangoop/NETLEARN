using Microsoft.AspNetCore.SignalR;
using restapi_learn.Models;

namespace restapi_learn.Service
{
    public class PizzaShopService
    {

        private List<PizzaShop> pizzaShops;

        public PizzaShopService()
        {
            pizzaShops = new List<PizzaShop>(){

                new PizzaShop(){Id=1,Name="Classic Pizza",Price=20F,Size="Small",IsGlutenFree=false},
                new PizzaShop(){Id=1,Name="Cheese Pizza",Price=15F,Size="Medium",IsGlutenFree=false},
                new PizzaShop(){Id=1,Name="Vegglie Pizza",Price=12F,Size="Large",IsGlutenFree=true}
            };
        }


        public List<PizzaShop> GetAll()
        {
            return pizzaShops;
        }

        public PizzaShop Add(PizzaShop p)
        {
            pizzaShops.Add(p);

            return p;
        }
    }
}
