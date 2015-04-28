﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Produto
    {
        //Oculta o ID na redenrizacao do  @Html.EditorForModel()
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a descrição do produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o preço do produto")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a categoria do produto")]
        public string Categoria { get; set; }
        
    }
}
