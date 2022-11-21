using Microsoft.AspNetCore.Mvc;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

[Route("/api/v1/Manager/[controller]")]
public class OrderController : ControllerBase
{
    public async Task<IActionResult> Index()
    {
        return StatusCode(500);
    }
}
