using ECommerce.DtoLayer.DTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
                var values = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonData);


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
                    // Eğer kategori bulunamazsa
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
                // Hata durumunu loglamak için ex değişkenini kullanabilirsiniz.
                TempData["ErrorMessage"] = "Silme işlemi sırasında bir hata oluştu.";
                return RedirectToAction("GetCategories", "AdminCategory");
            }
        }

    }
}
