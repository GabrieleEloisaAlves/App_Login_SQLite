using System;
using System.Collections.Generic;
using System.Text;
using App_Login_SQLite.Model;
using SQLite;

namespace App_Login_SQLite.ViewModel
{
    public class ServicesBDCliente
    {
        SQLiteConnection conn;

        public string StatusMessage { get; set; }

        public ServicesBDCliente(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<ModelCliente>();
        }
        public void Incluir(ModelCliente user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Nome))
                    throw new Exception("Usuario não informado");
                if (string.IsNullOrEmpty(user.Endereco))
                    throw new Exception("Endereço não informado");
                if (string.IsNullOrEmpty(user.Email))
                    throw new Exception("Email não informado");
                if (string.IsNullOrEmpty(user.Cidade))
                    throw new Exception("Cidade não informada");
                if (string.IsNullOrEmpty(user.Estado))
                    throw new Exception("Estado não informado");
                if (string.IsNullOrEmpty(user.Cep))
                    throw new Exception("Cep não informado");
                if (string.IsNullOrEmpty(user.Telefone))
                    throw new Exception("Telefone não informado");
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

            public List<ModelCliente> ListarCliente()
            {
                List<ModelCliente> lista = new List<ModelCliente>();
                try
                {
                    lista = conn.Table<ModelCliente>().ToList();
                    this.StatusMessage = "Listagem de Clientes";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                return lista;
            }

        }
    }


    
