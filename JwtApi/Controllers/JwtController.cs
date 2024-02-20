using JwtApi.Context;
using JwtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace JwtApi.Controllers
{
  public class JwtController : Controller
  {
    private readonly DataContext _dataContext;
    
      public JwtController (DataContext dataContext)
      {
      _dataContext = dataContext;
      }


    [HttpGet]
    public async Task<IActionResult> JwtTokenGetir()
    {
      var request = new HttpRequestMessage
      {
        RequestUri = new Uri("https://localhost:7283"),
        Method = HttpMethod.Get,
      };

      var client = HttpClientFactory.Create();
      var response = await client.SendAsync(request);
      var responseStream = await response.Content.ReadAsStringAsync();

      if (responseStream != null)
      {
        var sonuc = JsonConvert.DeserializeObject<JwtModel>(responseStream);
        _dataContext.JwtModel.Add(sonuc);
        _dataContext.SaveChanges();

        return View(sonuc);
      }
      return View(new Kullanici());
    }

    [HttpPost]
    public async Task<IActionResult> Login()
    {

    }


    /*
 Api:
 - Kullanıcı Kontrolü: Kullanıcı kodu ve şifre db den kontrol edilir, eğer doğru ise müşteriye JwtToken bilgisi dönülür ve bu JwtToken bilgisi db de saklanır.)
 - Kullanıcı Liste Dönen Fonksiyon: (Müşteriden token bekliyoruz. Gelen token db deki tabloda kontrol edilir, eşleşiyorsa cevap verilir, eşleşmiyorsa cevap verilmez.)

 MVC (Müşteri):
 - KullanıcıKontrol: Bu fonksiyon içinden Api çağrımı yapılır. Api ye kullanıcıKodu ve Şifre gönderilir. Eğer Token dönüyorsa db de saklanır.
 -KullaniciListesiniVer: bu fonksiyon sadece JwtToken ile çağrılır. Gelen data ekrana yazılır.
 */
  }
}
