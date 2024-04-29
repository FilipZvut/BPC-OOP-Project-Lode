using Microsoft.AspNetCore.Mvc;

public class NumberController : Controller
{
    private int _currentNumber = 0;

    // Akce pro získání aktuálního čísla
    [HttpGet]
    [Route("Number/GetCurrentNumber")]
    public IActionResult GetCurrentNumber()
    {
        // Zde můžete provést jakýkoliv kód pro získání aktuálního čísla
        _currentNumber++;

        return Ok(_currentNumber); // Vrátíme aktuální číslo jako odpověď na AJAX požadavek
    }
}
