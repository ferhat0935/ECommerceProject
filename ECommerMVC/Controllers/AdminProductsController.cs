﻿using ECommerce.DtoLayer.DTOS;
using ECommerce.DtoLayer.DTOS.ProductDtos;
using ECommerce.EntityLayer.Concrete;
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

                var colorResponse = await client.GetAsync("http://localhost:53239/api/Default/ListColor");
                List<ParamaterDefinitionDto> colorList = new List<ParamaterDefinitionDto>();
                var jsonData = await colorResponse.Content.ReadAsStringAsync();
                colorList = JsonConvert.DeserializeObject<List<ParamaterDefinitionDto>>(jsonData);

                var sizeResponse = await client.GetAsync("http://localhost:53239/api/Default/ListSize");
                List<ParamaterDefinitionDto> sizeList = new List<ParamaterDefinitionDto>();
                var sizeData = await sizeResponse.Content.ReadAsStringAsync();
                sizeList = JsonConvert.DeserializeObject<List<ParamaterDefinitionDto>>(sizeData);

                var responseProductFilter = await client.GetAsync($"http://localhost:53239/api/Product/{id}");
                responseProductFilter.EnsureSuccessStatusCode();
                var productFilterData = await responseProductFilter.Content.ReadAsStringAsync();
                var productFilterDto = JsonConvert.DeserializeObject<UpdateProductDto>(productFilterData);

                var responseCategory = await client.GetAsync("http://localhost:53239/api/Category");
                responseCategory.EnsureSuccessStatusCode();
                var categoryData = await responseCategory.Content.ReadAsStringAsync();
                var categoryDtos = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);

                // ViewModel oluştur
                var viewModel = new UpdateProductViewModel
                {
                    UpdateProductDto = productFilterDto,
                    Categories = categoryDtos,
                    ColorList = colorList,
                    SizeList = sizeList,

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

        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductViewModel model)
            {
            Product product = new Product()
            {
                ProductId = model.UpdateProductDto.ProductId,
                CategoryId = model.UpdateProductDto.CategoryId,
                ProductName = model.UpdateProductDto.ProductName,
                Description = model.UpdateProductDto.Description,
                Genders = model.UpdateProductDto.Genders,   
                Price = model.UpdateProductDto.Price,
                StockQuantity = model.UpdateProductDto.StockQuantity,
                ColorId = model.UpdateProductDto.ColorId,
                SizeId = model.UpdateProductDto.SizeId,
                IsActive = model.UpdateProductDto.IsActive,
                CreatedDate = DateTime.Now,
            

            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(product);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:53239/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetProducts", "AdminProducts");
            }

            return RedirectToAction("GetProducts", "AdminProducts");
        }



    }
}
