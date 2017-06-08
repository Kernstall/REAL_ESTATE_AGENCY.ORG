using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Real_Estate_Agency.Models
{
    public class SearchModels
    {
        [Display(Name = "Введите поисковый запрос...")]
        public string SearchLine { get; set; }

        [StringLength(8, ErrorMessage = "Поле {0} не должно содержать больше {1} символов")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Поле {0} должно содержать только цифры")]
        [Display(Name = "От")]
        public string SizeFrom { get; set; }

        [StringLength(8, ErrorMessage = "Поле {0} не должно содержать больше {1} символов")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Поле {0} должно содержать только цифры")]
        [Display(Name = "До")]
        public string SizeTo { get; set; }

        [StringLength(8, ErrorMessage = "Поле {0} не должно содержать больше {1} символов")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Поле {0} должно содержать только цифры")]
        [Display(Name = "От")]
        public string PriceFrom { get; set; }

        [StringLength(8, ErrorMessage = "Поле {0} не должно содержать больше {1} символов")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Поле {0} должно содержать только цифры")]
        [Display(Name = "До")]
        public string PriceTo { get; set; }
    }
 
    public class UnionModels
    {
        public SearchModels SearchModel { get; set; }
        public IEnumerable<Advertisement> AdsList { get; set; }
    }
}