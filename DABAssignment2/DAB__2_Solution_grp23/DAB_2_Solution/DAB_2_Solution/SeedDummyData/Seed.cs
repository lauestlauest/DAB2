using DABAssignment2.Data;
using DABAssignment2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_2_Solution.SeedDummyData
{
    public class Seed
    {
        public void SeedDummyData()
        {
            Console.WriteLine("Seeding Dummy data...");

            using (var db = new AUCanteens())
            {
                //Canteens

                db.Canteens.Add(new Canteens { CanteenName = "Kgl. Bibliotek", PostCode = 8000 });
                db.Canteens.Add(new Canteens { CanteenName = "Kemisk", PostCode = 8300 });
                db.Canteens.Add(new Canteens { CanteenName = "Matematisk", PostCode = 8000 });

                //Menu
                db.Menu.Add(new Menu { MenuItemsId = 1, MealType = 0, MealName = "æg", CanteenName = "Kgl. Bibliotek", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 2, MealType = 1, MealName = "banan", CanteenName = "Kgl. Bibliotek", NrReservations = 4 });
                db.Menu.Add(new Menu { MenuItemsId = 3, MealType = 2, MealName = "pizza", CanteenName = "Kgl. Bibliotek", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 4, MealType = 0, MealName = "kaffe", CanteenName = "Kemisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 5, MealType = 1, MealName = "æggekage", CanteenName = "Kemisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 6, MealType = 2, MealName = "pølser", CanteenName = "Kemisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 7, MealType = 0, MealName = "burger", CanteenName = "Matematisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 8, MealType = 1, MealName = "is", CanteenName = "Matematisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 9, MealType = 2, MealName = "pommes", CanteenName = "Matematisk", NrReservations = 0 });


                //Customer 
                db.Customer.Add(new Customer { CustomerCPR = 1400 });
                db.Customer.Add(new Customer { CustomerCPR = 1500 });
                db.Customer.Add(new Customer { CustomerCPR = 1600 });
                db.Customer.Add(new Customer { CustomerCPR = 1700 });


                //Reservations 
                db.Reservations.Add(new Reservations { MealId = 0, CustomerCPR = 1400, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                db.Reservations.Add(new Reservations { MealId = 1, CustomerCPR = 1500, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                db.Reservations.Add(new Reservations { MealId = 2, CustomerCPR = 1600, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                db.Reservations.Add(new Reservations { MealId = 3, CustomerCPR = 1700, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                db.Reservations.Add(new Reservations { MealId = 4, CustomerCPR = null, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });

                //Ratings
                db.Ratings.Add(new Ratings { RatingsId = 0, CanteenName = "Kgl. Bibliotek", CustomerCPR = 1400, Rating = 3 , RatingDate = DateTime.UtcNow });
                db.Ratings.Add(new Ratings { RatingsId = 1, CanteenName = "Kgl. Bibliotek", CustomerCPR = 1400, Rating = 3 , RatingDate = DateTime.UtcNow });
                db.Ratings.Add(new Ratings { RatingsId = 2, CanteenName = "Kgl. Bibliotek", CustomerCPR = 1400, Rating = 3 , RatingDate = DateTime.UtcNow });
                db.Ratings.Add(new Ratings { RatingsId = 3, CanteenName = "Kgl. Bibliotek", CustomerCPR = 1400, Rating = 5 , RatingDate = DateTime.UtcNow });


                db.SaveChanges();
            }
        }
    }
}
