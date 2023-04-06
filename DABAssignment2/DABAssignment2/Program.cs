using DABAssignment2.Data;
using DABAssignment2.Model;

namespace DABAssignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello, DAB!");

            Console.WriteLine("Inserting Dummy data...");

            using (var db = new AUCanteens())
            {
                //Canteens
                
                db.Canteens.Add(new Canteens { CanteenName = "Kgl. Bibliotek", PostCode = 8000 });
                db.Canteens.Add(new Canteens { CanteenName = "Kemisk", PostCode = 8300 });
                db.Canteens.Add(new Canteens { CanteenName = "Matematisk", PostCode = 8000 });

                //Menu
                db.Menu.Add(new Menu { MenuItemsId = 1, MealType = 0, MealName = "æg", CanteenName = "Kgl. Bibliotek" });
                db.Menu.Add(new Menu { MenuItemsId = 2, MealType = 0, MealName = "æg", CanteenName = "Kgl. Bibliotek" });
                db.Menu.Add(new Menu { MenuItemsId = 3, MealType = 0, MealName = "æg", CanteenName = "Kgl. Bibliotek" });
                db.Menu.Add(new Menu { MenuItemsId = 4, MealType = 0, MealName = "æg", CanteenName = "Kemisk" });
                db.Menu.Add(new Menu { MenuItemsId = 5, MealType = 0, MealName = "æg", CanteenName = "Kemisk" });
                db.Menu.Add(new Menu { MenuItemsId = 6, MealType = 0, MealName = "æg", CanteenName = "Kemisk" });
                db.Menu.Add(new Menu { MenuItemsId = 7, MealType = 0, MealName = "æg", CanteenName = "Matematisk" });
                db.Menu.Add(new Menu { MenuItemsId = 8, MealType = 0, MealName = "æg", CanteenName = "Matematisk" });

                //Customer 
                db.Customer.Add( new Customer { CustomerCPR = 1400 });
                db.Customer.Add(new Customer { CustomerCPR = 1500 });
                db.Customer.Add(new Customer { CustomerCPR = 1600 });
                db.Customer.Add(new Customer { CustomerCPR = 1700 });
                
                
                //Reservations 
                db.Reservations.Add(new Reservations { MealId = 0, CustomerCPR = 1400, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                db.Reservations.Add(new Reservations { MealId = 1, CustomerCPR = 1500, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                db.Reservations.Add(new Reservations { MealId = 2, CustomerCPR = 1600, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                db.Reservations.Add(new Reservations { MealId = 3, CustomerCPR = 1700, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                
                //Ratings
                
                db.Ratings.Add(new Ratings {RatingsId = 0, CanteenName = "Kgl. Bibliotek" , CustomerCPR = 1400 });
                db.Ratings.Add(new Ratings { RatingsId = 1, CanteenName = "Kgl. Bibliotek", CustomerCPR = 1400 });
                db.Ratings.Add(new Ratings { RatingsId = 2, CanteenName = "Kgl. Bibliotek", CustomerCPR = 1400 });
                db.Ratings.Add(new Ratings { RatingsId = 3, CanteenName = "Kgl. Bibliotek" , CustomerCPR = 1400 });
                
                db.SaveChanges();
                
            }


            Console.WriteLine("Query 1");
            Console.WriteLine("Query 2");
            Console.WriteLine("Query 3");
            Console.WriteLine("Query 4");
            Console.WriteLine("Query 5");
            Console.WriteLine("Query 6");

            Console.WriteLine("Hello, DAB!");
        }
    }
}