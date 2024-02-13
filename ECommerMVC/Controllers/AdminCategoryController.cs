using ECommerce.DtoLayer.DTOS;
using ECommerceMVC.DTO.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GetCategories()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage =  await client.GetAsync("http://localhost:53239/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                var categoryCount = values.Count;
                ViewBag.CategoryCount = categoryCount;

                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"http://localhost:53239/api/Category/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCategories", "AdminCategory");
                }
                else if (responseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    
                    TempData["ErrorMessage"] = "Silme işlemi sırasında hata oluştu: Kategori bulunamadı.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Silme işlemi sırasında bir hata oluştu.";
                }

                return RedirectToAction("GetCategories", "AdminCategory");
            }
            catch (Exception ex)
            {
                
                TempData["ErrorMessage"] = "Silme işlemi sırasında bir hata oluştu.";
                return RedirectToAction("GetCategories", "AdminCategory");
            }
        }
      
       

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
          
            UpdateCategoryDto values = new UpdateCategoryDto();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:53239/api/Category/{id}");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
            }


            return View(values);
        }
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:53239/api/Category/UpdateCategory", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetCategories", "AdminCategory");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
			if (!ModelState.IsValid)
			{
				return View();
			}
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:53239/api/Category/AddCategory", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("GetCategories", "AdminCategory");
			}
			return View();
		}

    }
}
