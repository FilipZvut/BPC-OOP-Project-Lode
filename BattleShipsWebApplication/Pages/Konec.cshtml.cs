using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Battleships.Pages;
public class KonecModel : PageModel
{
    public string Winner { get; set; }
    public void OnGet(string Name)
    {
        Winner = Name;
    }
}

