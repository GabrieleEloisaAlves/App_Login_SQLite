using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App_Login_SQLite.Model
{
    [Table("Cliente")]
    public class ModelCliente
    {
       
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        [MaxLength(50), Unique]
        public string Nome { get; set; }

        [MaxLength(18), NotNull]

        public string Endereco { get; set; }

        [MaxLength(18), NotNull]

        public string Email { get; set; }

        [MaxLength(50), NotNull]

        public string Cidade { get; set; }

        [MaxLength(18), NotNull]

        public string Estado { get; set; }

        [MaxLength(18), NotNull]

        public string Cep { get; set; }

        [MaxLength(18), NotNull]

        public string Telefone { get; set; }

       

        public ModelCliente()
        {
            this.Id = 0; 
            this.Nome = "";
            this.Endereco = "";
            this.Email = "";
            this.Cidade = "";
            this.Estado= "";
            this.Cep = "";
            this.Telefone = "";
        }
    }
}
