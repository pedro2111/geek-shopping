using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model.Base
{
    public class BaseEntity //aqui podemos colocar todas as colunas que são comuns entre todas as tabelas, ex: datetime, updated at, created at... 
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
    }
}

