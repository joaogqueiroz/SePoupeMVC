﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Models.Conta
{
    public class RecuperarSenhaContaModel
    {
        [EmailAddress(ErrorMessage = "Inform a valid email.")]
        [Required(ErrorMessage = "Inform your email.")]
        public string Email { get; set; }
    }
}
