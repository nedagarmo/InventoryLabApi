using Inventory.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Inventory.Entities.DTOs;
using Inventory.Application.Commands;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Método encargado de obtener los movimientos registrados en la base de datos.
        /// </summary>
        /// <param name="page">Número de página que se quiere obtener, por defecto es la primera página (0)</param>
        /// <param name="size">Tamaño de página, el límite establecido es de 100 registros por página</param>
        /// <returns>Retorna una lista de movimientos.</returns>
        /// <response code="200">Se retorna la lista de movimientos</response>
        /// <response code="400">Se retorna este código si se tiene algún problema en la ejecución de la consulta</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovementDTO>>> GetMovements(int? page, int? size)
        {
            try
            {
                return await _mediator.Send(new ListMovementCommand
                {
                    Page = page,
                    Size = size
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método encargado de obtener un movimiento filtrado por el identificador.
        /// </summary>
        /// <param name="id">Identificador del movimiento que se desea consultar</param>
        /// <returns>Retorna un objeto del movimiento encontrado.</returns>
        /// <response code="200">Se retorna el objeto del movimiento</response>
        /// <response code="400">Se retorna este código si se tiene algún problema en la ejecución de la consulta</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult<MovementDTO>> GetMovementById(Guid id)
        {
            try
            {
                var entity = await _mediator.Send(new GetMovementByIdCommand
                {
                    Id = id
                });

                return entity != null ? Ok(entity) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método encargado de registrar un nuevo movimiento según los datos proporcionados como parámetros.
        /// </summary>
        /// <param name="movement">Objeto con la estructura de datos que se guardará en la base de datos</param>
        /// <returns>Retorna un objeto con los datos registrados.</returns>
        /// <response code="200">Se retorna el objeto del movimiento registrado</response>
        /// <response code="400">Se retorna este código si se tiene algún problema en la ejecución del registro</response>
        /// <response code="422">Se retorna este código si otorgarons datos con formato equivocado según las validaciones de la entidad</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<MovementDTO>> CreateMovement(MovementDTO movement)
        {
            try
            {
                return await _mediator.Send(new CreateMovementCommand
                {
                    Movement = movement
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
