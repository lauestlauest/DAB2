using System.Threading.Tasks.Dataflow;
using DAB_2_Solution.SeedDummyData;
using DABAssignment2.Data;
using DABAssignment2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DAB_2_Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, DAB!");

            //Seed Data..
            //Seed Dummy = new Seed();
            //Dummy.SeedDummyData();



            var db = new AUCanteens();

            Console.WriteLine("Query 1................................................................");
            {
                var canteen = "Kgl. Bibliotek";

                var dalymeals = db.Menu.Where(m => m.CanteenName == canteen && m.MealType != 2);
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
                Console.WriteLine(reservation.MealId + " " + reservation.MealName + " " + reservation.CanteenName);
            }

            Console.WriteLine("Query 3................................................................");

            {
                var canteen = "Kgl. Bibliotek";

                var dalymeals = db.Menu.Where(m => m.CanteenName == canteen && m.MealType != 2);
                foreach (var Menu in dalymeals)
                {
                    Console.WriteLine(Menu.MealName + " " + Menu.NrReservations);
                }
            }


            Console.WriteLine("Query 4................................................................");

            {
                var canteen = "Kgl. Bibliotek";

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

            Console.WriteLine("Query 5................................................................");

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
                    Console.WriteLine(item.Name + " " + item.AvailbleMeal);
                }




            }

            Console.WriteLine("Query 6................................................................");



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
                Console.WriteLine(canteen.Key + " " + canteen.avg);
            }


            Console.WriteLine("Goodbye, DAB!");
        }
    }
}