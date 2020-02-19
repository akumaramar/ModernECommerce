using CatelogService.API;
using CatelogService.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CatelogServiceTest
{
    public class CatelogServiceIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CatelogServiceIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();            
        }

        [Fact]
        public async Task CanCRUDCatelogs()
        {
            String baseURL = "/api/catalog";
            String productName = "TestProduct";
            String productDescription = "TestProductDescription";

            // try to add something to API
            ProductDto dto = new ProductDto();
            dto.Name = productName;
            dto.Description = productDescription;
            //TODO: Need to check this again
            //var httpResponseAdd = await _client.PostAsync( <ProductDto>(baseURL, dto);

            // Make sure it was successfull
            //TODO: Fix the issue
            //httpResponseAdd.EnsureSuccessStatusCode();

            // Get the added value to understand if it was added correctly
            dto = null;
            //TODO: Fix this issue
            //dto = await DeserialiseToDto(httpResponseAdd);

            // We got a response
            Assert.NotNull(dto);
            Assert.Equal(dto.Name, productName);
            Assert.Equal(dto.Description, productDescription);
            Assert.NotEqual(dto.ID, Guid.Empty);


            //var httpResponse = await _client.GetAsync("/api/catalog");



            //// Must be successful.
            //httpResponse.EnsureSuccessStatusCode();

            //// Deserialize and examine results.
            //IEnumerable<ProductDto> catelogItems = await DeserialiseToDtoList(httpResponse);

            //Assert.Contains(catelogItems, p => p.Name == "Fridge");
            //Assert.Contains(catelogItems, p => p.Name == "Mouse");
        }

        private static async Task<IEnumerable<ProductDto>> DeserialiseToDtoList(HttpResponseMessage httpResponse)
        {
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var catelogItems = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(stringResponse);
            return catelogItems;
        }

        private static async Task<ProductDto> DeserialiseToDto(HttpResponseMessage httpResponse)
        {
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var catelogItems = JsonConvert.DeserializeObject<ProductDto>(stringResponse);
            return catelogItems;
        }
    }
}
