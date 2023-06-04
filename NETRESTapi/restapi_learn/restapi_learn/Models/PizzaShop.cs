using System.ComponentModel.DataAnnotations;

namespace restapi_learn.Models
{
    public class PizzaShop
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:100,ErrorMessage ="피자명은 필수 입력입니다")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Size { get; set; }

        [Display(Name = "GlutenFree ")]
        public bool IsGlutenFree { get; set; }
    }
}
