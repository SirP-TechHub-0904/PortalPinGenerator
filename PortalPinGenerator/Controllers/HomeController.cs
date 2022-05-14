using PortalPinGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalPinGenerator.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static Random rng = new Random(Environment.TickCount);

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private static void GetNumber(object objlength, string school)
        {
            var db = new ApplicationDbContext();

            for (int index = 1; index <= 15; index++)
            {
                for (int xindex = 1; xindex <= 200; xindex++)
                {

                    Card card = db.Cards.Create();
                    int length = Convert.ToInt32(objlength);
                    var number = rng.NextDouble().ToString("0.000000000000").Substring(2, length);

                    if (number.StartsWith("0"))
                    {
                        Random rnd = new Random();
                        int numb = rnd.Next(1, 10);
                        number = numb.ToString() + number.Substring(1);
                    }

                    card.PinNumber = (number).ToString();
                    card.SerialNumber = (rng.Next(1, 1000000) + 100000).ToString("D6").Substring(0, 6);
                    card.School = school;
                    card.BatchNumber = school + "/03" + index.ToString("D3").Substring(0, 3);

                    db.Cards.Add(card);
                    
                }
                db.SaveChanges();
                Card Icard = db.Cards.Create();
                
                Icard.PinNumber = "XXXXXXXXXXXXXXXXXXX";
                Icard.SerialNumber = "XXXXXXXXXXXXXXXXXX";
                Icard.School = "XXXXXXXXXXXXXXXXXXXXXXX";
                Icard.BatchNumber = "XXXXXXXXXXXXXXXXXXXXXXXXX";

                db.Cards.Add(Icard);
                Card Iicard = db.Cards.Create();

                Iicard.PinNumber = "XXXXXXXXXXXXXXXXXXX";
                Iicard.SerialNumber = "XXXXXXXXXXXXXXXXXX";
                Iicard.School = "XXXXXXXXXXXXXXXXXXXXXXX";
                Iicard.BatchNumber = "XXXXXXXXXXXXXXXXXXXXXXXXX";

                db.Cards.Add(Iicard);
                Card Iocard = db.Cards.Create();

                Iocard.PinNumber = "XXXXXXXXXXXXXXXXXXX";
                Iocard.SerialNumber = "XXXXXXXXXXXXXXXXXX";
                Iocard.School = "XXXXXXXXXXXXXXXXXXXXXXX";
                Iocard.BatchNumber = "XXXXXXXXXXXXXXXXXXXXXXXXX";

                db.Cards.Add(Iocard);
                db.SaveChanges();

            }

        }

        public ActionResult GenerateCards()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateCards(CardVm model)
        {
            //if (ModelState.IsValid)
            //{
                GetNumber(12, "HRSSU2021-REG");
                return RedirectToAction("CardList");
            //}
            //return View();
        }

        public ActionResult CardList(string searchString, string numbercount, string delete)
        {
            var cards = db.Cards.Distinct();

            if (!String.IsNullOrEmpty(searchString))
            {
                //cards = cards.Where(x => x.BatchNumber.ToUpper().Contains(searchString.ToUpper()));
                cards = cards.Where(x => x.BatchNumber.ToUpper() == searchString.ToUpper());
            }
            else if (!String.IsNullOrEmpty(numbercount))
            {
                cards = cards.OrderByDescending(x => x.Id).Take(Convert.ToInt32(numbercount));
            }
            else if (!String.IsNullOrEmpty(delete))
            {
                //cards = cards.Where(x => x.BatchNumber.ToUpper() == delete.ToUpper());
                //int cfs = cards.Count();
                //foreach(var i in cards)
                //{
                //    Card cd = db.Cards.Find(i.Id);
                //    db.Cards.Remove(cd);
                //}
                
                //db.SaveChanges();
            }
            else
            {
                cards = cards.OrderByDescending(x => x.Id).Take(21000);
            }
            return View(cards.OrderByDescending(x => x.Id));
        }

        public ActionResult CardListPin(string searchString, string numbercount, string delete)
        {
            var cards = db.Cards.Distinct();

            if (!String.IsNullOrEmpty(searchString))
            {
                //cards = cards.Where(x => x.BatchNumber.ToUpper().Contains(searchString.ToUpper()));
                cards = cards.Where(x => x.BatchNumber.ToUpper() == searchString.ToUpper());
            }
            else if (!String.IsNullOrEmpty(numbercount))
            {
                cards = cards.OrderByDescending(x => x.Id).Take(Convert.ToInt32(numbercount));
            }
            else if (!String.IsNullOrEmpty(delete))
            {
                //cards = cards.Where(x => x.BatchNumber.ToUpper() == delete.ToUpper());
                //int cfs = cards.Count();
                //foreach(var i in cards)
                //{
                //    Card cd = db.Cards.Find(i.Id);
                //    db.Cards.Remove(cd);
                //}

                //db.SaveChanges();
            }
            else
            {
                cards = cards.OrderByDescending(x => x.Id).Take(1000);
            }
            return View(cards.OrderByDescending(x => x.Id));
        }

        public ActionResult CardListFront(string searchString, string numbercount, string delete)
        {
            var cards = db.Cards.Distinct();

            if (!String.IsNullOrEmpty(searchString))
            {
                //cards = cards.Where(x => x.BatchNumber.ToUpper().Contains(searchString.ToUpper()));
                cards = cards.Where(x => x.BatchNumber.ToUpper() == searchString.ToUpper());
            }
            else if (!String.IsNullOrEmpty(numbercount))
            {
                cards = cards.OrderByDescending(x => x.Id).Take(Convert.ToInt32(numbercount));
            }
            else if (!String.IsNullOrEmpty(delete))
            {
                //cards = cards.Where(x => x.BatchNumber.ToUpper() == delete.ToUpper());
                //int cfs = cards.Count();
                //foreach(var i in cards)
                //{
                //    Card cd = db.Cards.Find(i.Id);
                //    db.Cards.Remove(cd);
                //}

                //db.SaveChanges();
            }
            else
            {
                cards = cards.OrderByDescending(x => x.Id).Take(1000);
            }
            return View(cards.OrderByDescending(x => x.Id));
        }

    }

    public static class StringExtensionMethods
    {
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
