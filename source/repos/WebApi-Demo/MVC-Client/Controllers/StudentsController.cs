using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApi_Demo.Models;

namespace MVC_Client.Controllers
{
    public class StudentsController : Controller
    {
        HttpClient client;
        void SetWebApiBasePath()
        {
            client.BaseAddress = new Uri("https://localhost:44383/");

        }
        // GET: Students
        public async Task<ActionResult> Index()
        {
            List<Student> studentList = new List<Student>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44383/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Student");
                if (response.IsSuccessStatusCode)
                {

                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    studentList = JsonConvert.DeserializeObject<List<Student>>(jsonString.Result);


                }
                else
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    ViewBag.msg = JsonConvert.DeserializeObject<string>(jsonString.Result);
                }

            }

            return   View(studentList);
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Student student = new Student();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44383/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Student/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    student = JsonConvert.DeserializeObject<Student>(jsonString.Result);

                //    student = await response.Content.ReadAsAsync<Student>();
                     }
                else
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    ViewBag.msg = JsonConvert.DeserializeObject<string>(jsonString.Result);

                }


            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
