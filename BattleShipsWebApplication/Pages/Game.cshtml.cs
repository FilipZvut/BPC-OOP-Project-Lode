using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using projekt_lodě.Pages;

public class GameModel : PageModel
{
    public string Nazev1 { get; set; }
    public string Nazev2 { get; set; }

    public GameManager gameManager;

    
    private readonly ILogger<GameModel> _logger;

    public GameModel(ILogger<GameModel> logger)
    {
        _logger = logger;
    }
    public void OnGet(string name1, string name2)
    {
        Nazev1 = name1;
        Nazev2 = name2;
    }

    public IActionResult OnGetPlay(string msg)
    {
        
        GameManager gm = new GameManager();
        gm.GameCreated(Nazev1, Nazev2);
        gm.RandomPlace(1);
        gm.RandomPlace(2);
        _logger.LogInformation(msg);

        return Page();
    }

    public async Task OnPostPlay()
    {
        CalcDTO calcDTO = new CalcDTO();
        calcDTO.Operand1 = CalcModel.;
        calcDTO.Operand2 = CalcModel.Operand2;
        calcDTO.Operation = CalcModel.Operation;
        HttpResponseMessage response = await
        _client.PostAsJsonAsync($"api/calc", calcDTO);
        response.EnsureSuccessStatusCode();
        ViewData["ResultValue"] = await response.Content.ReadAsStringAsync();
    }


}
