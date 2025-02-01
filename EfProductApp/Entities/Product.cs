using System.ComponentModel.DataAnnotations;

namespace EfProductApp.Entities
{
	public class Product
	{
        public int Id { get; set; }
		[Required(ErrorMessage = "Name is required.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Description is required.")]
		public string Description { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
    }
}
