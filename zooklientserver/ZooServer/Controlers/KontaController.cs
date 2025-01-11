using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooServer.Data;
using ZooServer.Models;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace ZooServer.Controllers
{
    [Route("api/konta")]
    [ApiController]
    public class KontaController : ControllerBase
    {
        private readonly AnimalCareContext _context;
        private static ConcurrentDictionary<int, string> aktywneSesje = new ConcurrentDictionary<int, string>(); // Bezpieczna pamięć sesji

        public KontaController(AnimalCareContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Haslo))
                return BadRequest("Login i hasło nie mogą być puste.");

            var konto = await _context.Konta.FirstOrDefaultAsync(k => k.Login == request.Login && k.Haslo == request.Haslo);

            if (konto == null)
                return Unauthorized("❌ Błędne dane logowania.");

            // Aktualizacja ostatniego logowania
            konto.OstatnieLogowanie = System.DateTime.Now;
            await _context.SaveChangesAsync();

            // Dodanie sesji, jeśli użytkownik jeszcze nie jest zalogowany
            aktywneSesje[konto.IDKonta] = konto.TypKonta;

            return Ok(new { IDKonta = konto.IDKonta, TypKonta = konto.TypKonta });
        }

        [HttpGet("protected/{id}")]
        public IActionResult GetProtectedData(int id)
        {
            if (!aktywneSesje.ContainsKey(id))
                return Unauthorized("❌ Brak dostępu! Zaloguj się.");

            return Ok($"✅ Dostęp przyznany dla użytkownika {id}, rola: {aktywneSesje[id]}.");
        }
    }

    public class LoginRequest
    {
        public string Login { get; set; }
        public string Haslo { get; set; }
    }
}