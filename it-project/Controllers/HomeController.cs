using it_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace it_project.Controllers
{
    [Authorize]
    public class HomeController : Controller 
    {
        private BurgerDBContext db = new BurgerDBContext();


        internal static void send_email(MailAddress fromAddress, MailAddress toAddress, string subject, string body)
        {
            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };
            var client = new SmtpClient("smtpServerName");
            client.Send(message);
        }

        public ActionResult SendMail()
        {
            string recipient = "velkovski.jovan1@gmail.com";
            string subject = "joco";
            string body = Request["body"];

            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = true;
            WebMail.UserName = "Email address";
            WebMail.Password = "Password";

            WebMail.Send(recipient, subject, body, isBodyHtml: true);
            return View();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Burgers);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Menu()
        {
            ViewBag.Message = "Your contact page.";


            /* List<Burger> Burgeri = new List<Burger>();
             Burgeri.Add(new Burger("Burger 1", 100, "mnogu ubav burger", "~/Img/burger1.jpg", null));
             Burgeri.Add(new Burger("Burger 2", 120, "poubav od prviot", "~/Img/burger2.jpg", null));
             Burgeri.Add(new Burger("Burger 3", 130, "najubav burger", "~/Img/burger3.jpg",  null));
             Burgeri.Add(new Burger("Burger4", 150, "poubav burger amin", "~/Img/burger4.jpg", null));
             */
         //   db.Burgers.Add(new Burger("Burger 1", 100, "mnogu ubav burger", "~/Img/burger1.jpg", null));
           // db.Burgers.Add(new Burger("Burger 2", 120, "poubav od prviot", "~/Img/burger2.jpg", null));
/*
            foreach(Burger ab in db.Burgers)
            {
                db.Burgers.Remove(ab);
            }
            Burger b = new Burger(1, "Burger 1", 100, "za merak", "~/Img/burger1.jpg");
            db.Burgers.Add(b);
            b = new Burger(2, "Burger 2", 110, "za merak 2", "~/Img/burger2.jpg");
            db.Burgers.Add(b);
            b = new Burger(3, "Burger 3", 120, "najdobar", "~/Img/burger3.jpg");
            db.Burgers.Add(b);

            db.SaveChanges();*/
            return View(db.Burgers);
        }



        [AllowAnonymous]
        public ActionResult Catering()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

        public ActionResult AddToCart(int productID)
        {
            if (Session["cart"] == null)
            {

                var cart = new List<Koshnichka>();
                var product = db.Burgers.Find(productID);


                cart.Add(new Koshnichka()
                {
                    burger = product,
                    Kolicina = 1

                });
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<Koshnichka>)Session["cart"];
                var product = db.Burgers.Find(productID);
                var ima = false;

                foreach (Koshnichka k in cart)
                {
                    if (k.burger.Id == productID)
                    {
                        ima = true;
                        k.Kolicina++;
                        break;
                    }
                }


                if (!ima)
                {
                    cart.Add(new Koshnichka()
                    {
                        burger = product,
                        Kolicina = 1
                    });
                }
                Session["cart"] = cart;


            }

            return Redirect("Cart");
        }

        public ActionResult AddToCartCustom(string opis)
        {
            if (Session["cart"] == null)
            {

                var cart = new List<Koshnichka>();
                var product = new Burger();
                product.Cena = 200;
                product.Pateka = "~/Img/customburger.png";
                product.Ime = "Сам свој мајстор";
                product.Opis = opis;
                


                cart.Add(new Koshnichka()
                {
                    burger = product,
                    Kolicina = 1

                });
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<Koshnichka>)Session["cart"];
                var product = new Burger();
                product.Cena = 200;
                product.Pateka = "~/Img/customburger.png";
                product.Ime = "Сам свој мајстор";
                product.Opis = opis;

                var ima = false;

                foreach (Koshnichka k in cart)
                {
                    if (k.burger.Ime == "Сам свој мајстор")
                    {
                        ima = true;
                        k.Kolicina++;
                        break;
                    }
                }


                if (!ima)
                {
                    cart.Add(new Koshnichka()
                    {
                        burger = product,
                        Kolicina = 1
                    });
                }
                Session["cart"] = cart;


            }

            return Redirect("Cart");
        }

        public ActionResult DeleteFromCart(int productID)
        {
            if (Session["cart"] == null)
            {
                Redirect("Index");
            }
            else
            {
                var cart = (List<Koshnichka>)Session["cart"];
                var product = db.Burgers.Find(productID);

                //cart.RemoveAt(productID-49);
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].burger.Id == productID)
                    {
                        cart.Remove(cart[i]);
                        break;
                    }
                    Session["cart"] = cart;
                }

            }

            return Redirect("Cart");
        }

        public ActionResult EmptyCart()
        {
            var cart = (List<Koshnichka>)Session["cart"];

            if (cart != null)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    cart.Remove(cart[i]);
                }
            }
            Session["cart"] = null;

            return Redirect("Index");
        }

        [Authorize]
        public ActionResult Cart()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CustomBurger()
        {
            return View();
        }

        public ActionResult CateringSuccess()
        {
            return View();
        }

        [Authorize]
        public ActionResult ThankYou(int total,string email)
        {
            ViewBag.Message = "Your contact page.";
            ThankYou fala = new ThankYou(
                total,email,null);
            Session["kraj"] = fala;

            return View();
        }
    }
}