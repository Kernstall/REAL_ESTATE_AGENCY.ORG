﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Real_Estate_Agency.Models
{
    public class AdvertisementModels
    {
        [Required]
        [StringLength(100, ErrorMessage = "Поле {0} не может быть пустым.", MinimumLength = 1)]
        [Display(Name = "Заголовок")]
        public string Header { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Поле {0} не может быть пустым.", MinimumLength = 1)]
        [Display(Name = "Местонахождение")]
        public string Adress { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Подробное описание ваших апартаментов поможет найти вам съемщика.", MinimumLength = 1)]
        [Display(Name = "Подробно опишите ваши апартаменты")]
        public string Content { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Поле {0} не может быть пустым.", MinimumLength = 1)]
        [RegularExpression("[^0-9]", ErrorMessage = "Поле {0} должно содержать только цифры")]
        [Display(Name = "Метраж в квадратных метрах")]
        public string Size { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Поле {0} не может быть пустым.", MinimumLength = 1)]
        [RegularExpression("[^0-9]", ErrorMessage = "Поле {0} должно содержать только цифры")]
        [Display(Name = "Стоимость в шекелях")]
        public string Price { get; set; }
    }
}