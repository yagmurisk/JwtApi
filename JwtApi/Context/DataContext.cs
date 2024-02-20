using JwtApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Context
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<JwtModel> JwtModel { get; set; }
    public DbSet<Kullanici> Kullanici { get; set; }

  }
}
