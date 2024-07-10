using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;
namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;


        public PizzaListModel(PizzaService service){

            _service = service;

        }
        public IList<Pizza> PizzaList { get;set; } = default!;
        
        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }
    }
}
