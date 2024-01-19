using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspClientApp.Models;
using System.Text.Json;

namespace aspClientApp.Controllers;

public class HomeController : Controller
{ 
    public async Task<IActionResult> Index()
    {
        //servis üzerinden bilgileri alıcam
        var products = new List<ProductDTO>();

        using(var httpClient = new HttpClient())//usinng ile çevreleyerek işimiz bittikten sonra bu bellekten silinir
        {
            using(var response = await httpClient.GetAsync("http://localhost:5177/api/products"))//ProductApi projemin Asp.Net Core ile api testi yapıcam,http://localhost:5177/swagger/index.html adresinden api almak için adresi yazdım
            {
                //gelen datayı alıcam
                string apiResponse = await response.Content.ReadAsStringAsync();//datayı string veri olarak aldık ve okudum

                //“Deserialize” işlemi, verinin orijinal hali veya nesne yapısına dönüştürülmesi anlamına gelir. Bu işlem genellikle, verinin bir format veya ortamdan diğerine taşındıktan sonra gerçekleştirilir. Örneğin, bir nesnenin serileştirilmiş (serialized) bir hali ağ üzerinden gönderilir ve alıcı tarafında deserialize edilerek orijinal nesne haline getirilir.
                //Deserialize burda json türünde olan bir string datanın uygulama tarafında olan bir objeye çevirmek,tam terside serialized işlemidir.
                products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse);
            }
        }
        return View(products);
    }

    
}
