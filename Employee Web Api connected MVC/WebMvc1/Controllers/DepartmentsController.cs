using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMvc1.Models;

namespace WebMvc1.Controllers
{
    public class DepartmentsController : Controller
    {
        private IHttpClientFactory httpClientFactory;//create ref of web api factory

        public DepartmentsController(IHttpClientFactory client)//D.I.
        {
            httpClientFactory = client;
        }
        // GET: DepartmentsController
        public async Task<ActionResult> Index()
        {
           var client = httpClientFactory.CreateClient("api");//fetch one client from client factory
          var response = await  client.GetAsync("api/Departments");//req send to api and response recieved by mvc
            if (response.IsSuccessStatusCode)
            {
             var result =  await response.Content.ReadFromJsonAsync<List<Department>>();
                await Console.Out.WriteLineAsync("successfully read data"); 
                return View(result);
            }
            else
            return RedirectToAction();
        }

        // GET: DepartmentsController/Details/5
        public async Task<ActionResult> Details(short id)
        {
           var client = httpClientFactory.CreateClient("api");
       var response =    await client.GetAsync($"api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
             var result = await  response.Content.ReadFromJsonAsync<Department>();
                return View(result);
            }
            else
            return View();
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Department dept)
        {
           var client = httpClientFactory.CreateClient("api");
            try
            {
                string msg;
               var response = await client.PostAsJsonAsync<Department>("api/Departments",dept);
                if(response.IsSuccessStatusCode)
                {
                    msg = "successfully added!!!";
                    TempData.Add("msg",msg);
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsController/Edit/5
        public async Task<ActionResult> Edit(short id)//binding must be match all data types
        {   string msg;
            var client=httpClientFactory.CreateClient("api");
          var response=await  client.GetAsync($"api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Department>();
                return View(result);
            }
            else
            {
                msg = "deptartment not found!!!";
                TempData.Add("msg", msg);
                return RedirectToAction("Index");
            }
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(short id, Department dept)
        { String msg;
           var client = httpClientFactory.CreateClient("api");
            try
            {
               var response =await client.PutAsJsonAsync<Department>($"api/Departments/{id}", dept);
                if (response.IsSuccessStatusCode)
                {
                  //  var result =await response.Content.ReadFromJsonAsync<Department>();
                    msg = "deptartment successfully updated!!!";
                    TempData.Add("msg", msg);
                    return RedirectToAction("Index");
                }
                msg = "deptartment not updated!!!";
                TempData.Add("msg", msg);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsController/Delete/5
        public async Task<ActionResult> Delete(short id)
        {
            string msg;
            var client = httpClientFactory.CreateClient("api");
            var response = await client.GetAsync($"api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Department>();
                return View(result);
            }
            msg = "deptartment not found!!!";
            TempData.Add("msg", msg);
            return RedirectToAction("Index");
            
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(short? id)
        {
            string msg;
            var client = httpClientFactory.CreateClient("api");
            try
            {
               var response =await client.DeleteAsync($"api/Departments/{id}");
                if (response.IsSuccessStatusCode)
                {
                    msg = "successfully deleted!!!!";
                    TempData.Add("msg", msg);
                    return RedirectToAction("Index");
                }
                msg = "unsuccussfully deleted!!!";
                TempData.Add("msg", msg);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
