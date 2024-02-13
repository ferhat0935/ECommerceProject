using ECommerce.DtoLayer.DTOS.ProductDtos;
using ECommerceMVC.DTO.CategoryDto;
using ECommerceMVC.DTO.ProductDto;
using ECommerceMVC.Models.ProductModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class AdminProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> GetProducts()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:53239/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                
         
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> DeleteProduct(int id)
        {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"http://localhost:53239/api/Product/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetProducts", "AdminProducts");
                }
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                // Ürünü çek
                var responseProductFilter = await client.GetAsync($"http://localhost:53239/api/Product/{id}");
                responseProductFilter.EnsureSuccessStatusCode(); // Hata kontrolü ekledim
                var productFilterData = await responseProductFilter.Content.ReadAsStringAsync();
                var productFilterDto = JsonConvert.DeserializeObject<UpdateProductDto>(productFilterData);

                // Kategorileri çek
                var responseCategory = await client.GetAsync("http://localhost:53239/api/Category");
                responseCategory.EnsureSuccessStatusCode(); // Hata kontrolü ekledim
                var categoryData = await responseCategory.Content.ReadAsStringAsync();
                var categoryDtos = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);

                // ViewModel oluştur
                var viewModel = new UpdateProductViewModel
                {
                    UpdateProductDto = productFilterDto,
                    Categories = categoryDtos
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                // Hata durumunu ele al
                // Loglama veya uygun bir hata mesajı döndürme işlemleri yapılabilir
                return RedirectToAction("Error", "Home"); // Örnek bir hata yönlendirmesi
            }
        }

        public async Task<IActionResult> UpdateCategory(UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:53239/api/Product/UpdateProduct", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetProducts", "AdminProducts");
            }
            return View();
        }


    }
}
