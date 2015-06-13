using System.Data.Entity;

namespace iAmDressedToKill.Models
{
	public class DressModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
	}

	public class DressToImpress : DbContext
	{
		public DbSet<DressModel> Movies { get; set; }
	}
}