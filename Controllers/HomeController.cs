using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExams.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace FinalExams.Controllers
{
    public class HomeController : Controller
    {
         private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

         [HttpGet("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }


        [HttpPost("register")]
        public IActionResult registerPost(User user)
        {
            if(ModelState.IsValid){

                if(dbContext.users.Any(u => u.Email == user.Email))
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Register");
            
                // You may consider returning to the View at this point
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbContext.Add(user);
                dbContext.SaveChanges();

                HttpContext.Session.SetString("email", user.Email);
                string LocalVariable = HttpContext.Session.GetString("email");
                return RedirectToAction("Dashboard");

            }

            return View("Register");
        }

        [HttpPost("loginPost")]
        public IActionResult loginPost(LoginUser userSubmission)
        {
            if(ModelState.IsValid){
                User userInDb = dbContext.users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if(userInDb == null)
                {
                // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

                if(result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("login");
                }

                HttpContext.Session.SetString("email", userSubmission.Email);
                string LocalVariable = HttpContext.Session.GetString("email");
                return RedirectToAction("Dashboard");


            }
            return View("login");
        }

        

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            
            if(HttpContext.Session.GetString("email")==null){
                return RedirectToAction("login");
            }

            string LocalVariable = HttpContext.Session.GetString("email");
            User userConnected = dbContext.users.FirstOrDefault(a=> a.Email == LocalVariable);
            ViewBag.connected = userConnected.UserId;
            ViewBag.connectedName = userConnected.FirstName;

            List<Idea> idea = dbContext.ideas.Include(c=>c.people).Include(c=>c.creator).OrderByDescending(c=>c.people.Count).ToList();

            ViewBag.AllIdeas = idea;



            return View();
        }

        [HttpPost("createIdea")]
        public IActionResult createIdea(Idea idea){


             if(HttpContext.Session.GetString("email")==null){
                return RedirectToAction("login");
            }



            if(ModelState.IsValid){

                User userCreator = dbContext.users.FirstOrDefault(a=> a.UserId == idea.UserId);
                idea.creator = userCreator;

                dbContext.Add(idea);
                dbContext.SaveChanges();

                return Redirect("dashboard");
            }
            string LocalVariable = HttpContext.Session.GetString("email");
            User userConnected = dbContext.users.FirstOrDefault(a=> a.Email == LocalVariable);
            ViewBag.connected = userConnected.UserId;
            ViewBag.connectedName = userConnected.FirstName;   

            List<Idea> idea_1 = dbContext.ideas.Include(c=>c.people).Include(c=>c.creator).ToList();

            ViewBag.AllIdeas = idea_1;
       

            return View("dashboard");
        }

        [HttpGet("reservation/{UserId}/{IdeaId}")]
        public IActionResult reservation(int UserId , int IdeaId){

            Association find = dbContext.associations.FirstOrDefault(c=>c.UserId==UserId && c.IdeaId==IdeaId);

            // if(find.Equals(1)){
            //     return RedirectToAction("dashboard");
            // }

            User u = dbContext.users.FirstOrDefault(c=>c.UserId == UserId);
            Idea i = dbContext.ideas.FirstOrDefault(c=>c.IdeaId == IdeaId);
            Console.WriteLine(u.LastName);
            Console.WriteLine(i.Description);

            

            Association ass =new Association();
            ass.User = u;
            ass.Idea = i;
            ass.inside = 1;

            string LocalVariable = HttpContext.Session.GetString("email");
            User userConnected = dbContext.users.FirstOrDefault(a=> a.Email == LocalVariable);
            ViewBag.connected = userConnected.UserId;
            ViewBag.connectedName = userConnected.FirstName;

            dbContext.Add(ass);
            dbContext.SaveChanges();
            return RedirectToAction("dashboard");
        }

         [HttpGet("delete/{IdeaId}")]
        public IActionResult deleteActivity(int IdeaId){
            
            Idea TheIdea = dbContext.ideas.FirstOrDefault(c=>c.IdeaId == IdeaId);

            string LocalVariable = HttpContext.Session.GetString("email");
            User userConnected = dbContext.users.FirstOrDefault(a=> a.Email == LocalVariable);
            ViewBag.connected = userConnected.UserId;
            ViewBag.connectedName = userConnected.FirstName;

            // if(userConnected.UserId!= TheActivity.creator.UserId){
            //     return RedirectToAction("dashboard");
            // }


            dbContext.Remove(TheIdea);
            dbContext.SaveChanges();

            return RedirectToAction("dashboard");
        }

        [HttpGet("{IdeaId}")]
        public IActionResult see(int IdeaId){

            if(HttpContext.Session.GetString("email")==null){
                return RedirectToAction("login");
            }

            string LocalVariable = HttpContext.Session.GetString("email");
            User userConnected = dbContext.users.FirstOrDefault(a=> a.Email == LocalVariable);
            ViewBag.connected = userConnected.UserId;
            ViewBag.connectedName = userConnected.FirstName;


            Idea act = dbContext.ideas.Include(c=>c.people).ThenInclude(c=>c.User).Include(c=>c.creator).FirstOrDefault(c=>c.IdeaId == IdeaId);
            
            
            return View(act);
        }

        [HttpGet("users/{UserId}")]
        public IActionResult watch(int UserId){

            if(HttpContext.Session.GetString("email")==null){
                return RedirectToAction("login");
            }

            string LocalVariable = HttpContext.Session.GetString("email");
            User userConnected = dbContext.users.FirstOrDefault(a=> a.Email == LocalVariable);
            ViewBag.connected = userConnected.UserId;
            ViewBag.connectedName = userConnected.FirstName;


            User u  = dbContext.users.Include(c=>c.peopleWhoLiked).Include(c=>c.createdIdeas).ThenInclude(c=>c.people).FirstOrDefault(c=>c.UserId == UserId);

            int sum = 0;
            foreach(var i in u.createdIdeas){
                sum+= i.people.Count;
            }

            ViewBag.mySum = sum;


            return View(u);
            
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
