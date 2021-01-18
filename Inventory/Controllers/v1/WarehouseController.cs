using Inventory.Application.Commands;
using Inventory.Entities.DTOs;
using Inventory.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Método encargado de obtener las bodegas registradas en la base de datos.
        /// </summary>
        /// <param name="page">Número de página que se quiere obtener, por defecto es la primera página (0)</param>
        /// <param name="size">Tamaño de página, el límite establecido es de 100 registros por página</param>
        /// <returns>Retorna una lista de bodegas.</returns>
        /// <response code="200">Se retorna la lista de bodegas</response>
        /// <response code="400">Se retorna este código si se tiene algún problema en la ejecución de la consulta</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseListDTO>>> GetWarehouses(int? page, int? size)
        {
            try
            {
                return await _mediator.Send(new ListWarehouseCommand
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
        /// Método encargado de obtener una bodega filtrada por el identificador.
        /// </summary>
        /// <param name="id">Identificador de la bodega que se desea consultar</param>
        /// <returns>Retorna un objeto de la bodega encontrada.</returns>
        /// <response code="200">Se retorna el objeto de la bodega</response>
        /// <response code="400">Se retorna este código si se tiene algún problema en la ejecución de la consulta</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDTO>> GetWarehouseById(Guid id)
        {
            try
            {
                var entity = await _mediator.Send(new GetWarehouseByIdCommand
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
        /// Método encargado de registrar una nueva bodega según los datos proporcionados como parámetros.
        /// </summary>
        /// <param name="warehouse">Objeto con la estructura de datos que se guardará en la base de datos</param>
        /// <returns>Retorna un objeto con los datos registrados.</returns>
        /// <response code="200">Se retorna el objeto de la bodega registrada</response>
        /// <response code="400">Se retorna este código si se tiene algún problema en la ejecución del registro</response>
        /// <response code="422">Se retorna este código si otorgarons datos con formato equivocado según las validaciones de la entidad</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<WarehouseDTO>> CreateWarehouse(WarehouseDTO warehouse)
        {
            try
            {
                return await _mediator.Send(new CreateWarehouseCommand
                {
                    Warehouse = warehouse
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
