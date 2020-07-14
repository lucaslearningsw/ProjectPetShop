using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class DB_Cliente
    {
        private DB_Conexao conn = new DB_Conexao();

        SqlDataReader ler;
        DataTable tabela = new DataTable();
        SqlCommand cmd = new SqlCommand();



        //=================================================================
        //METODO PARA INSERIR CLIENTE NO DB
        //=================================================================
        public void InserirCliente 
        (string cpf, string nome, string telefone, string cep_cliente, string email_cliente)
        {
            cmd.Connection = conn.OpenConnection();
            cmd.CommandText = 
            "INSERT INTO CLIENTE  VALUES" +
            "('"+cpf+"', '"+nome+"' , '"+telefone+"', '"+cep_cliente+"', '"+email_cliente+"')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conn.ClosedConnection();
        }


        //=================================================================
        //METODO PARA CARREGAR OS DADOS DO CLIENTE NO FORM
        //=================================================================
        public DataTable PesquisarCliente(string cpf)
        {
            DataTable dados = new DataTable();
            cmd.Connection = conn.OpenConnection();
            cmd.Parameters.AddWithValue("@CPF", cpf);
            cmd.CommandText = ("SELECT * FROM CLIENTE WHERE CPF = @CPF");
            ler =  cmd.ExecuteReader();
            dados.Load(ler);
            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.ClosedConnection();
            return dados;
        }


        //=================================================================
        //METODO PARA EDITAR O CLIENTE
        //=================================================================
        public void EditarCliente(string cpf ,string nome, string telefone, string cep_cliente, string email_cliente)
        {
            cmd.Connection = conn.OpenConnection();

            cmd.Parameters.AddWithValue("@CPF", cpf);
            cmd.Parameters.AddWithValue("@NOME", nome);
            cmd.Parameters.AddWithValue("@TELEFONE", telefone);
            cmd.Parameters.AddWithValue("@CEP", cep_cliente);
            cmd.Parameters.AddWithValue("@EMAIL", email_cliente);

            cmd.CommandText = "UPDATE CLIENTE SET " +
            "NOME_CLIENTE = @NOME, " +
            "TELEFONE_CLIENTE = @TELEFONE, " +
            "CEP_CLIENTE = @CEP, " +
            "EMAIL_CLIENTE = @EMAIL " +
            "WHERE CPF  = @CPF";

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.ClosedConnection();
            

        }




    }
}
