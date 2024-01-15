namespace Lesson_1.ADONETIntro.Repositories
{
	internal class Good
	{
		public int Id { get; set; }
		public string GoodName { get; set; }
		public int CategoryId { get; set; }
		public int ManufacturerId { get; set; }
		public decimal Price { get; set; }
		public decimal GoodCount { get; set; }
	}
}