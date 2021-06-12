using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web_Application26034863.Data;
using Web_Application26034863.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace Web_Application26034863.Controllers
{
    public class PeopleController : Controller
    {
        //private Web_Application26034863Context db = new Web_Application26034863Context();
        private static readonly HttpClient client = new HttpClient();
        

        // GET: People
        public ActionResult Index()
        {
            var responseString = client.GetStringAsync("https://localhost:44364/api/people");
            string str = responseString.Result;
            var peopleList = JsonConvert.DeserializeObject<List<Person>>(str);
            
            return View(peopleList);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var responseString = client.GetStringAsync("https://localhost:44364/api/people/" + id);
            string str = responseString.Result;
            Person person = JsonConvert.DeserializeObject<Person>(str);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstName,lastName")] Person person)
        {
            if (ModelState.IsValid)
            {
                var content = JsonConvert.SerializeObject(person);

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44364/api/people");
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();

                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var responseString = client.GetStringAsync("https://localhost:44364/api/people/" + id);
            string str = responseString.Result;
            Person person = JsonConvert.DeserializeObject<Person>(str);
         
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstName,lastName")] Person person)
        {
            if (ModelState.IsValid)
            {
                var content = JsonConvert.SerializeObject(person);

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, "https://localhost:44364/api/people/"+person.id);
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();

                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var responseString = client.GetStringAsync("https://localhost:44364/api/people/" + id);
            string str = responseString.Result;
            var person = JsonConvert.DeserializeObject<Person>(str);

            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:44364/api/people/"+id);
            HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();

            return RedirectToAction("Index");
        }
    }
}
