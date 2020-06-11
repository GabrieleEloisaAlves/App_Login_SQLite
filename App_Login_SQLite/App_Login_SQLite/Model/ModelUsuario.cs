using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App_Login_SQLite.Model
{
    [Table("Usuario")]
   public class ModelUsuario
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        [MaxLength(25), Unique]
        public string Nome { get; set; }

        [MaxLength(8), NotNull]

        public string Senha { get; set; }

        public ModelUsuario()
        {
            this.Id = 0; ;
            this.Nome = "";
            this.Senha = "";
        }
    }
}
