using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCEventosExamen.Models;
using MVCEventosExamen.Services;

namespace MVCEventosExamen.Controllers
{
    public class EventosController : Controller
    {
        private ServiceEventos service;

        public EventosController(ServiceEventos service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await service.GetCategoriasAsync();

            ViewData["CATEGORIAS"] = categorias
                .Select(x => new SelectListItem
                {
                    Value = x.IdCategoria.ToString(),
                    Text = x.Nombre
                });

            List<Evento> eventos =
                await service.GetEventosAsync();

            return View(eventos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int? idcategoria)
        {
            var categorias = await service.GetCategoriasAsync();

            ViewData["CATEGORIAS"] = categorias
                .Select(x => new SelectListItem
                {
                    Value = x.IdCategoria.ToString(),
                    Text = x.Nombre
                });

            ViewData["IDCATEGORIA"] = idcategoria;

            List<Evento> eventos;

            if (idcategoria.HasValue)
            {
                eventos = await service
                    .GetEventosCategoriaAsync(idcategoria.Value);
            }
            else
            {
                eventos = await service.GetEventosAsync();
            }

            return View(eventos);
        }
    }
}
