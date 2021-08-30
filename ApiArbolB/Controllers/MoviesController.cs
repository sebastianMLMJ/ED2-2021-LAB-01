using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria_ED2;
using ApiArbolB.Models;
using System.Text.Json;
using System.IO;
using System.Text;
namespace ApiArbolB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        static ArbolB<Movie> arbolPeliculas;
        static bool ArbolInicializado = false;

        [HttpGet]
        [Route("{traversal}")]
        public List<Movie> Recorridos(string traversal)
        {
            if (ArbolInicializado == true && (traversal == "inorden" || traversal == "InOrden" || traversal == "inOrden"))
            {
                arbolPeliculas.RecolectorRecorridos.Clear();
                arbolPeliculas.InOrden();
                return arbolPeliculas.RecolectorRecorridos;
            }

            if (ArbolInicializado == true && (traversal == "postorden" || traversal == "PostOrden" || traversal == "postOrden"))
            {
                arbolPeliculas.RecolectorRecorridos.Clear();
                arbolPeliculas.PostOrden();
                return arbolPeliculas.RecolectorRecorridos;
            }

            if (ArbolInicializado == true && (traversal == "preorden" || traversal == "PreOrden" || traversal == "preOrden"))
            {
                arbolPeliculas.RecolectorRecorridos.Clear();
                arbolPeliculas.PreOrden();
                return arbolPeliculas.RecolectorRecorridos;
            }
            return null;

            //throw new NotImplementedException("No inicializo el arbol o No ingreso el nombre del recorrido según los parametros definidos");
        }

        [HttpPost]
        public IActionResult CrearArbol(Grado order)
        {
            arbolPeliculas = new ArbolB<Movie>(order.order);
            ArbolInicializado = true;
            return Ok("Arbol de peliculas inicializado");
        }

        [HttpDelete]
        public IActionResult EliminarTodoArbol()
        {
            arbolPeliculas.EliminarArbol();
            ArbolInicializado = false;
            return Ok();
        }

        [HttpPost]
        [Route("populate")]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            if (ArbolInicializado == true)
            {
                using var contenidoEnMemoria = new MemoryStream();
                await file.CopyToAsync(contenidoEnMemoria); 
                var contenido = Encoding.ASCII.GetString(contenidoEnMemoria.ToArray());
                var dato = JsonSerializer.Deserialize<List<Movie>>(contenido, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                foreach (var item in dato)
                {
                    arbolPeliculas.insertar(item);

                }
                return Ok("Valores Insertados");
            }
            
            return NotFound("Arbol no inicializado");
        }

        
    }
}
