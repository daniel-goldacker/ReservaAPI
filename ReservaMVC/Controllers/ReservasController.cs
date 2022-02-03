using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReservaMVC.Models;

namespace ReservaMVC.Controllers
{
    public class ReservasController: Controller
    {
        private readonly string apiUrl = "https://localhost:5001/api/reservas";

        public async Task<IActionResult> Index()
        {
            List<Reserva> listaReservas = new List<Reserva>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaReservas = JsonConvert.DeserializeObject<List<Reserva>>(apiResponse);
                }
            }
            return View(listaReservas);
        }

        [HttpGet]
        public ViewResult BuscarReserva() => View();

        [HttpPost]
        public async Task<IActionResult> BuscarReserva(int id)
        {
            Reserva reserva = new Reserva();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reserva = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                }
            }
            return View(reserva);
        }

        [HttpGet]
        public ViewResult AdicionarReserva() => View();

        [HttpPost]
        public async Task<IActionResult> AdicionarReserva(Reserva reserva)
        {
            Reserva reservaRecebida = new Reserva();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reserva),
                                                  Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservaRecebida = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                }
            }
            return View(reservaRecebida);
        }

        [HttpGet]
        public async Task<IActionResult> AlterarReserva(int id)
        {
            Reserva reserva = new Reserva();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reserva = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                }
            }
            return View(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarReserva(Reserva reserva)
        {
            Reserva reservaRecebida = new Reserva();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reserva),
                                                  Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Sucesso";
                    reservaRecebida = JsonConvert.DeserializeObject<Reserva>(apiResponse);
                }
            }
            return View(reservaRecebida);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarReserva(int ReservaId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(apiUrl + "/" + ReservaId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
