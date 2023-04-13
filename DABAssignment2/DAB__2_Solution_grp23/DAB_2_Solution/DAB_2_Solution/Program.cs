using System.Threading.Tasks.Dataflow;
using DAB_2_Solution.SeedDummyData;
using DABAssignment2.Data;
using DABAssignment2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

// Fix date in rating
// Fix CustomerCPR: Change to CustomerId, two attributes CPR and AuId - delete cpr with migrations
// Remember to rename CustomerCPR to CustomerId everywhere
// Add last query: Payroll. Get whole DB ez lol <3

namespace DAB_2_Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, DAB!");

            //Seed Data..
            Seed Dummy = new Seed();
            Dummy.SeedDummyData();



            var db = new AUCanteens();

            Console.WriteLine("Query 1: Get the day's menu options for a canteen given as input........");
            {
                var canteen = "Kgl. Bibliotek";

                Console.WriteLine("Canteen: " + canteen + " is serving the following meals:");

				var dalymeals = db.Menu.Where(m => m.CanteenName == canteen && m.MealType != 2);
                foreach (var Menu in dalymeals)
                {
                    if (Menu.MealType == 0)
                    {
                        Console.WriteLine("WarmMeal: " + Menu.MealName);
                    }
                    else
                    {
                        Console.WriteLine("StreetMeal: " + Menu.MealName);
                    }
                }
            }

            Console.WriteLine("Query 2: Get the reservation for a given user: .........................................................");
            var user = 1400;

			var reservations = (from r in db.Reservations
                                join m in db.Menu
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
                Console.WriteLine("User: " + user + " has reserved: " + reservation.MealId + " " + reservation.MealName + " at: " + reservation.CanteenName);
            }

            Console.WriteLine("Query 3: For a canteen given as input, show the number of reservations for each of the daily menu options");

            {
                var canteen = "Kgl. Bibliotek";
                Console.WriteLine("Canteen: " + canteen + " has the following reservations:");

                var dalymeals = db.Menu.Where(m => m.CanteenName == canteen && m.MealType != 2);
                foreach (var Menu in dalymeals)
                {
                    Console.WriteLine(Menu.MealName + ": " + Menu.NrReservations);
                }
            }


            Console.WriteLine("Query 4: For a canteen given as input, show the just-in-time meal options and the available (canceled) daily menu");

            {
                var canteen = "Kgl. Bibliotek";
                Console.WriteLine("Canteen: " + canteen + " has the following options for JIT and canceled menu items:");

                var dalymeals = db.Menu.Where(m => m.CanteenName == canteen && m.MealType == 2);
                foreach (var Menu in dalymeals)
                {
                    Console.WriteLine(Menu.MealName);
                    
                }

                var canceledReservations = (from r in db.Reservations
                                            join m in db.Menu
                                            on r.MenuItemId equals m.MenuItemsId
                                            where r.CustomerCPR == null
                                            select new
                                            {
                                                MealName = m.MealName
                                            }).ToList();

                foreach (var reservation in canceledReservations)
                {
                    Console.WriteLine(reservation.MealName);
                }
            }

            Console.WriteLine("Query 5: For a canteen given as input, show the the available (canceled) daily menu in the nearby canteens");

            {
                var canteen = "Matematisk";


                var nearByCanceledMeals = (from r in db.Canteens
                    join c in db.Reservations on r.CanteenName equals c.CanteenName into rc
                    from rct in rc
                    join m in db.Menu on rct.MenuItemId equals m.MenuItemsId
                    where rct.CanteenName != canteen
                    && rct.CustomerCPR == null
                    && r.PostCode == (from tc in db.Canteens
                        where tc.CanteenName == canteen
                        select tc.PostCode).Single()
                                           select new
                        {
                          Name = r.CanteenName,
                          AvailbleMeal = m.MealName
                        }).ToList();

                foreach (var item in nearByCanceledMeals)
                {
                    Console.WriteLine(item.Name + ": " + item.AvailbleMeal);
                }
            }

            Console.WriteLine("Query 6: Show the average ratings from all the canteens from top to bottom:");

            var avgerages = (from r in db.Ratings
                             group r by r.CanteenName
                    into grouping
                             select new
                             {
                                 grouping.Key,
                                 avg = grouping.Average(ra => ra.Rating)
                             }).ToList();

            foreach (var canteen in avgerages)
            {
                Console.WriteLine(canteen.Key + " has rating: " + canteen.avg);
            }

            Console.WriteLine("Goodbye, DAB!");
        }
    }
}