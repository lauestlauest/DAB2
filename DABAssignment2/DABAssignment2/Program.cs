using System.ComponentModel.DataAnnotations;
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
                db.Menu.Add(new Menu { MenuItemsId = 1, MealType = 0, MealName = "æg", CanteenName = "Kgl. Bibliotek", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 2, MealType = 1, MealName = "æg", CanteenName = "Kgl. Bibliotek", NrReservations = 4 });
                db.Menu.Add(new Menu { MenuItemsId = 3, MealType = 2, MealName = "æg", CanteenName = "Kgl. Bibliotek", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 4, MealType = 0, MealName = "æg", CanteenName = "Kemisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 5, MealType = 2, MealName = "æg", CanteenName = "Kemisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 6, MealType = 3, MealName = "æg", CanteenName = "Kemisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 7, MealType = 0, MealName = "æg", CanteenName = "Matematisk", NrReservations = 0 });
                db.Menu.Add(new Menu { MenuItemsId = 8, MealType = 0, MealName = "æg", CanteenName = "Matematisk", NrReservations = 0 });

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
                db.Reservations.Add(new Reservations { MealId = 4, CustomerCPR = null, MenuItemId = 1, CanteenName = "Kgl. Bibliotek" });
                
                //Ratings
                db.Ratings.Add(new Ratings {RatingsId = 0, CanteenName = "Kgl. Bibliotek" , CustomerCPR = 1400 , Rating = 3});
                db.Ratings.Add(new Ratings { RatingsId = 1, CanteenName = "Kgl. Bibliotek", CustomerCPR = 1400 , Rating = 3 });
                db.Ratings.Add(new Ratings { RatingsId = 2, CanteenName = "Kgl. Bibliotek", CustomerCPR = 1400 , Rating = 3 });
                db.Ratings.Add(new Ratings { RatingsId = 3, CanteenName = "Kgl. Bibliotek" , CustomerCPR = 1400 , Rating = 5 });
                
                
                db.SaveChanges();
                
            }

            var dbs = new AUCanteens();

            Console.WriteLine("Query 1................................................................");
            {
                var canteen = "Kgl. Bibliotek";

                var dalymeals = dbs.Menu.Where(m => m.CanteenName == canteen && m.MealType != 2);
                foreach (var Menu in dalymeals)
                {
                    if (Menu.MealType == 0)
                    {
                        Console.WriteLine("WarmMeal " + Menu.MealName);
                    }
                    else
                    {
                        Console.WriteLine("StreetMeal " + Menu.MealName);
                    }
                }
            }

            Console.WriteLine("Query 2................................................................");
            var user = 1400;

            var reservations = (from r in dbs.Reservations
                        join m in dbs.Menu 
                        on r.MenuItemId equals m.MenuItemsId
                        where r.CustomerCPR == user
                        select new
                        {
                            MealId = r.MealId,
                            MealName = m.MealName,
                            CanteenName = r.CanteenName,
                        }).ToList();

            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation.MealId +" " + reservation.MealName + " " + reservation.CanteenName);
            }

            Console.WriteLine("Query 3................................................................");

            {
                var canteen = "Kgl. Bibliotek";

                var dalymeals = dbs.Menu.Where(m => m.CanteenName == canteen && m.MealType != 2);
                foreach (var Menu in dalymeals)
                {
                    Console.WriteLine(Menu.MealName + " " + Menu.NrReservations);
                }
            }


            Console.WriteLine("Query 4................................................................");

            {
                var canteen = "Kgl. Bibliotek";

                var dalymeals = dbs.Menu.Where(m => m.CanteenName == canteen && m.MealType == 2);
                foreach (var Menu in dalymeals)
                {
                    Console.WriteLine(Menu.MealName);
                }

                var canceledReservations = (from r in dbs.Reservations
                            join m in dbs.Menu
                            on r.MenuItemId equals m.MenuItemsId
                            where r.CustomerCPR == null
                            select new { MealName = m.MealName
                            }).ToList();

                foreach (var reservation in canceledReservations)
                {
                    Console.WriteLine(reservation.MealName);
                }
            }

            Console.WriteLine("Query 5................................................................");





            Console.WriteLine("Query 6................................................................");



            var avgerages = (from r in dbs.Ratings
                    group r by r.CanteenName
                    into grouping
                    select new
                    {
                        grouping.Key,
                        avg = grouping.Average(ra => ra.Rating)
                    }).ToList();

            foreach (var canteen in avgerages)
            {
                Console.WriteLine(canteen.Key + " " + canteen.avg);
            }



            Console.WriteLine("Hello, DAB!");
        }
    }
}