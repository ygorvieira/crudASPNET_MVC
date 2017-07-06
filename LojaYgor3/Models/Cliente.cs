using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaYgor3.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CPF { get; set; }
    }
}