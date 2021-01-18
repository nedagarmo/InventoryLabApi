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
    public class MovementTest
    {

        private readonly MovementController _testee;
        private readonly MovementDTO _movementDTO;
        private readonly Guid _id = Guid.Parse("35296ce1-e20f-4dc6-83c8-25b9152995e0");
        private readonly IMediator _mediator;

        public MovementTest()
        {
            _mediator = A.Fake<IMediator>();
            _testee = new MovementController(_mediator);

            _movementDTO = new MovementDTO
            {
                Date = DateTime.UtcNow,
                Price = 2000,
                Product = Guid.Parse("f0b9b6a9-24d4-47b4-bfc4-2224b50c05fd"),
                Quantity = 10,
                Type = Guid.Parse("41841961-B61C-42B4-A88D-5C617409BF79"),
                WarehouseOrigin = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6")
            };
            var movements = new List<Movement>();
        }

        [Theory]
        [InlineData("CreateMovementAsync: movement is null")]
        public async void Movement_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<CreateMovementCommand>._, default)).Throws(new ArgumentException(exceptionMessage));

            var result = await _testee.CreateMovement(_movementDTO);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Movement_ShouldReturnMovement()
        {
            var result = await _testee.CreateMovement(_movementDTO);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<MovementDTO>();
        }

        [Fact]
        public async void Movements_ShouldReturnListOfMovements()
        {
            var result = await _testee.GetMovements(null, null);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<List<MovementDTO>>();
            result.Value.Count().Should().Be(1);
        }
    }
}
