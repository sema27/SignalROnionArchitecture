﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalROnionArchitecture.Presentation.WebUI.Dtos.CategoryDtos;

namespace SignalROnionArchitecture.Presentation.WebUI.ViewComponents.MenuComponents
{
    public class _MenuCategoryFilterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuCategoryFilterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7068/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}