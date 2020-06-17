using System;
using System.Collections.Generic;
using System.Text;
using App_Login_SQLite.Model;
using SQLite;

namespace App_Login_SQLite.ViewModel
{
    public class ServicesBDUsuario
    {
        SQLiteConnection conn;

        public string StatusMessage { get; set; }

        public ServicesBDUsuario(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<ModelUsuario>();
        }
            public void Inserir(ModelUsuario user)
            {
                try
                {
                    if (string.IsNullOrEmpty(user.Nome))
                        throw new Exception("Usuario não informado");
                    if (string.IsNullOrEmpty(user.Senha))
                        throw new Exception("Senha não informada");
                    int result = conn.Insert(user);
                    if (result != 0)
                    {
                        this.StatusMessage =
                            string.Format("{0} registro(s) adicionado(s): [Nota: {1}]",
                            result, user.Nome);
                    }
                    else
                    {
                        string.Format("0 registro(s) adicionado(s)");

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        public ModelUsuario ValidarLogin(string usuario, string senha)
        {
            
                try
            {
                var p = conn.Table<ModelUsuario>();
                var result = p.Where(x => x.Nome == usuario && x.Senha == senha).FirstOrDefault();
                return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
    }
}
public void Alterar(ModelUsuario user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Nome))
                    throw new Exception("Usuario não informado");
                if (string.IsNullOrEmpty(user.Senha))
                    throw new Exception("Senha não informada");
                if (user.Id <= 0)
                    throw new Exception("Id da nota não informado");
                int result = conn.Update(user);
                StatusMessage = string.Format("{0} Registros alterados.", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }

        }
        public void Excluir(int id)
        {
            try
            {
                int result = conn.Table<ModelUsuario>().Delete(r => r.Id == id);
                StatusMessage = string.Format("{0} Registros deletados.", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public List<ModelUsuario> Localizar(string titulo)
        {
            List<ModelUsuario> lista = new List<ModelUsuario>();
            try
            {
                var resp = from p in conn.Table<ModelUsuario>()
                           where p.Nome.ToLower().Contains(titulo.ToLower())
                           select p;
                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
            return lista;
        }
        public List<ModelUsuario> Listar()
        {
            List<ModelUsuario> lista = new List<ModelUsuario>();
            try
            {
                lista = conn.Table<ModelUsuario>().ToList();
                this.StatusMessage = "Listagem dos Usuarios";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return lista;
        }

    }
}
