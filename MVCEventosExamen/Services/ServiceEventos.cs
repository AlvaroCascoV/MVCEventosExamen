using MVCEventosExamen.Models;

namespace MVCEventosExamen.Services
{
    public class ServiceEventos
    {
        private HttpClient client;

        public ServiceEventos(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            List<Categoria> categorias = await this.client.GetFromJsonAsync<List<Categoria>>("api/eventos/categorias") ?? [];
            return categorias;
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            List<Evento> eventos = await this.client.GetFromJsonAsync<List<Evento>>("api/eventos/eventos") ?? [];
            return eventos;
        }

        public async Task<List<Evento>> GetEventosCategoriaAsync(int idCategoria)
        {
            List<Evento> eventos = await this.client.GetFromJsonAsync<List<Evento>>($"api/eventos/eventoscategoria/{idCategoria}") ?? [];
            return eventos;
        }
    }
}
