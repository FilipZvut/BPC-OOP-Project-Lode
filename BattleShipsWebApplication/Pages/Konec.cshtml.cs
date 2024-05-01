using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


public class KonecModel : PageModel
{
    public string Winner { get; set; }

    public void OnGet(string Name)
    {
        Winner = Name;
        
    }
}

