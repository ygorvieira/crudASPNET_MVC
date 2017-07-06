using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaYgor3.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}