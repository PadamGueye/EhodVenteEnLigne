    using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(EhodVenteEnLigne.Resources.Models.Product), ErrorMessageResourceName = "MissingName")]

        public string Name { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }
        [Required(ErrorMessageResourceType = typeof(EhodVenteEnLigne.Resources.Models.Product), ErrorMessageResourceName = "MissingQuantity")]

        public string Stock { get; set; }

        public string Price { get; set; }
        [Required(ErrorMessageResourceType = typeof(EhodVenteEnLigne.Resources.Models.Product), ErrorMessageResourceName = "MissingPrice")]
    }
}
