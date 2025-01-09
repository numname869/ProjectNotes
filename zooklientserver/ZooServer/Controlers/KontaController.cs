using Microsoft.AspNetCore.Mvc;
using ZooServer.Data;
using ZooServer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooServer.Controllers
{
    [Route("api/konta")]
    [ApiController]
    public class KontaController : ControllerBase
    {
        private readonly AnimalCareContext _context;
        private static Dictionary<int, string> aktywneSesje = new Dictionary<int, string>(); // Pamięć sesji

        public KontaController(AnimalCareContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var konto = _context.Konta.FirstOrDefault(k => k.Login == request.Login && k.Hasło == request.Hasło);

            if (konto == null)
                return Unauthorized("Błędne dane logowania.");

            if (!aktywneSesje.ContainsKey(konto.IDKonta))
            {
                aktywneSesje[konto.IDKonta] = konto.TypKonta;
            }

            return Ok(new { IDKonta = konto.IDKonta, TypKonta = konto.TypKonta });
        }

        [HttpGet("protected/{id}")]
        public IActionResult GetProtectedData(int id)
        {
            if (!aktywneSesje.ContainsKey(id))
                return Unauthorized("Brak dostępu! Zaloguj się.");

            return Ok($"Dostęp przyznany dla użytkownika {id}, rola: {aktywneSesje[id]}.");
        }
    }

    public class LoginRequest
    {
        public string Login { get; set; }
        public string Hasło { get; set; }
    }
}