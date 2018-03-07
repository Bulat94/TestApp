using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        PersonContext db = new PersonContext();

        public ActionResult Index()
        {
            var pageInfo = new PageInfo { ClassName = "Name", Asc = true };
            return View( db.People.SortByProp(pageInfo));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

       
        public ActionResult Delete (int?  id)
        {
            if (id != null)
            { 
                Person person = db.People.Find(id);
                db.People.Remove(person);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit (int? id)
        {
            Person person;    
            if (id != null)
            {
                 person = db.People.Find(id);
                if (person != null)
                return View(person);
            }
            return HttpNotFound("Hello there");
        }

        public ActionResult Details (int? id)
        {
            Person person;
            if (id != null)
            {
                person = db.People.Find(id);
                return View(person);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteMany( int [] idArr, PageInfo pageInfo )
        {
            if (idArr!= null && idArr.Length!=0)
            {
                var delArr = db.People.Where(x => idArr.Contains(x.Id));
                db.People.RemoveRange(delArr);
                db.SaveChanges();
            }
            var list = db.People.SortByProp(pageInfo);
            return View("TablePartView", list);

        }

        [HttpPost]
        public ActionResult Sort (PageInfo pageInfo)
        {
            var list = db.People.SortByProp(pageInfo);
            return View("TablePartView", list);
        }

        public ActionResult Add ()
        {
            var list = new List<Person>();
            for (int i=0; i<10; i++)
            {
                list.Add(
                    new Person
                    {
                        Name = "Иван " + i.ToString(),
                        MiddleName = "Иванов " + i.ToString(),
                        Patronic = "Иванович " + i.ToString(),
                        Age = 20 + i,
                        Sex =0,
                        DateOfBirth = new DateTime(1998 - i, 11, 11)
                    });
            }
            db.People.AddRange(list);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }

    [Serializable]
    internal class HttpResponseException : Exception
    {
        private HttpResponseMessage resp;

        public HttpResponseException()
        {
        }

        public HttpResponseException(HttpResponseMessage resp)
        {
            this.resp = resp;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}