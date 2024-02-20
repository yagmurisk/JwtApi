namespace JwtApi.Models
{
  public class JwtModel
  {

    public string AccessToken { get; set; }
    public DateTime Expr { get; set; }
    public string RefreshToken { get; set; }


  }
}
