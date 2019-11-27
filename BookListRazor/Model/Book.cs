using System.ComponentModel.DataAnnotations;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]   //Assciate Id as a Identity column. Create an autoincrement Id, we do not need to pass the value
        public int Id { get; set; }

        [Required]  //Required will force this string not accept null values
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
