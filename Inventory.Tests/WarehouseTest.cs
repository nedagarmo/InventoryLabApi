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
    public class WarehouseTest
    {

        private readonly WarehouseController _testee;
        private readonly WarehouseDTO _warehouseDTO;
        private readonly Guid _id = Guid.Parse("35296ce1-e20f-4dc6-83c8-25b9152995e0");
        private readonly IMediator _mediator;

        public WarehouseTest()
        {
            _mediator = A.Fake<IMediator>();
            _testee = new WarehouseController(_mediator);

            _warehouseDTO = new WarehouseDTO
            {
                Name = "Bodega Test 1",
                Description = "Descripción Bodega Test 1",
                Location = "Dir Test 1",
                Quantity = 10
            };
            var warehouses = new List<Warehouse>
            {
                new Warehouse
                {
                    Name = "Bodega Test 2",
                    Id = _id,
                    Description = "Descripción Bodega Test 2",
                    Location = "Dir 3 Test 3",
                    MaximumQuantity = 100
                },
                new Warehouse
                {
                    Name = "Bodega Test 2",
                    Id = Guid.Parse("270b0d0f-cfde-4846-a67d-098166c333a1"),
                    Description = "Descripción Bodega Test 2",
                    Location = "Dir 2 Test 2",
                    MaximumQuantity = 100
                }
            };
        }

        [Theory]
        [InlineData("CreateWarehouseAsync: warehouse is null")]
        public async void Warehouse_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<CreateWarehouseCommand>._, default)).Throws(new ArgumentException(exceptionMessage));

            var result = await _testee.CreateWarehouse(_warehouseDTO);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Warehouse_ShouldReturnWarehouse()
        {
            var result = await _testee.CreateWarehouse(_warehouseDTO);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<WarehouseDTO>();
            result.Value.Id.Should().Be(_id);
        }

        [Fact]
        public async void Warehouses_ShouldReturnListOfWarehouses()
        {
            var result = await _testee.GetWarehouses(null, null);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<List<WarehouseDTO>>();
            result.Value.Count().Should().Be(1);
        }
    }
}
