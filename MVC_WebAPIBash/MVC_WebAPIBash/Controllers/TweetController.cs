using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_WebAPIBash.Models;

namespace MVC_WebAPIBash.Controllers
{
    public class TweetController : Controller
    {
        private TwittrContext db = new TwittrContext();

        //
        // GET: /Tweet/
        public ActionResult Index()
        {
            var tweets = db.Tweets.Include(t => t.User);
            return View(tweets.ToList());
        }

        //
        // GET: /Tweet/Details/5
        public ActionResult Details(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        //
        // GET: /Tweet/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        //
        // POST: /Tweet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Tweets.Add(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tweet.UserId);
            return View(tweet);
        }

        //
        // GET: /Tweet/Edit/5
        public ActionResult Edit(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tweet.UserId);
            return View(tweet);
        }

        //
        // POST: /Tweet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tweet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tweet.UserId);
            return View(tweet);
        }

        //
        // GET: /Tweet/Delete/5
        public ActionResult Delete(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        //
        // POST: /Tweet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            db.Tweets.Remove(tweet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
