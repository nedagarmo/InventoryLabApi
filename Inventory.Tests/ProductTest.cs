using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Inventory.Application.Commands;
using Inventory.Controllers;
using Inventory.Entities.DTOs;
using Inventory.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Xunit;

namespace Inventory.Tests
{
    public class ProductTest
    {

        private readonly ProductController _testee;
        private readonly ProductDTO _productDTO;
        private readonly Guid _id = Guid.Parse("35296ce1-e20f-4dc6-83c8-25b9152995e0");
        private readonly IMediator _mediator;

        public ProductTest()
        {
            _mediator = A.Fake<IMediator>();
            _testee = new ProductController(_mediator);

            _productDTO = new ProductDTO
            {
                Name = "Producto Test 1",
                Description = "Descripción Producto Test 1",
                Sku = "00001"
            };
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Producto Test 2",
                    Id = _id,
                    Description = "Descripción Producto Test 2",
                    Sku = "00002"
                },
                new Product
                {
                    Name = "Producto Test 2",
                    Id = Guid.Parse("270b0d0f-cfde-4846-a67d-098166c333a1"),
                    Description = "Descripción Producto Test 2",
                    Sku = "00002"
                }
            };
        }

        [Theory]
        [InlineData("CreateProductAsync: product is null")]
        public async void Product_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<CreateProductCommand>._, default)).Throws(new ArgumentException(exceptionMessage));

            var result = await _testee.CreateProduct(_productDTO);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Product_ShouldReturnProduct()
        {
            var result = await _testee.CreateProduct(_productDTO);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<ProductDTO>();
            result.Value.Id.Should().Be(_id);
        }

        [Fact]
        public async void Products_ShouldReturnListOfProducts()
        {
            var result = await _testee.GetProducts(null, null);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<List<ProductDTO>>();
            result.Value.Count().Should().Be(1);
        }
    }
}
