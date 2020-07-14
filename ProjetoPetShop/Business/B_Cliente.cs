using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Database;

namespace Business
{
    public class B_Cliente
    {
        private DB_Cliente ClientesDB = new DB_Cliente();

        public DataTable MostrarClientes()
        {
            DataTable tabela = new DataTable();
          //  tabela = ClientesDB.MostrarClientes();
            return tabela;
        }

       


        //=================================================================
        //METODO PARA INSERIR CLIENTE
        //=================================================================
        public void InserirCliente (string cpf, string nome, string telefone, string cep_cliente, string email_cliente)
        {

            ClientesDB.InserirCliente(cpf, nome, telefone, cep_cliente, email_cliente); 
        }

        //=================================================================
        //METODO PARA PESQUISAR CLIENTE
        //=================================================================
        public DataTable PesquisarCliente(string cpf)
        {
            DataTable dados = ClientesDB.PesquisarCliente(cpf);

            return dados;
        }

        //=================================================================
        //METODO PARA EDITAR CLIENTE
        //=================================================================
        public void EditarCliente(string cpf, string nome, string telefone, string cep_cliente, string email_cliente)
        {
            ClientesDB.EditarCliente(cpf, nome, telefone, cep_cliente, email_cliente);
        }



    }
}
