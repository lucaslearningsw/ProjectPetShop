using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class DB_Agendamento
    {
        private DB_Conexao conn = new DB_Conexao();

        SqlDataReader ler;
        
        DataTable tabela = new DataTable();
        SqlCommand cmd = new SqlCommand();

        //================================================================
        //Buscando valor ID disponivel na tabela Agendamento 
        //================================================================
        public int ID_Disponivel()
        {
            int id = -1;

           SqlDataAdapter adpatador = new SqlDataAdapter
           ("SELECT MAX(ID_AGENDAMENTO) AS MaxID FROM AGENDAMENTO", conn.OpenConnection());
           adpatador.Fill(tabela);

            //verifica se é null
            if
                (DBNull.Value.Equals(tabela.Rows[0][0]))
                id = 1;

            else
           
            id = Convert.ToInt16(tabela.Rows[0][0]) + 1;

            conn.ClosedConnection();
            return id;

        }

        //=================================================================
        //CARREGAR DADOS DE UM AGENDAMENTO JÁ EXISTENTE
        //=================================================================
        public DataTable MostrarDados(int id_agendamento)
        {

            DataTable dados = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter
            ("SELECT * FROM AGENDAMENTO WHERE ID_AGENDAMENTO = " + id_agendamento, conn.OpenConnection());
            adapter.Fill(dados);
            conn.ClosedConnection();
            return dados;

        }

        //=================================================================
        //Criando um novo agendamento
        //=================================================================
        public void InserirAngendamento(string cpf, string nome_animal, string tipo_animal,
        string servico, DateTime date, DateTime time, string descricao)
        {
            cmd.Connection = conn.OpenConnection();
            cmd.CommandText =
            "INSERT INTO AGENDAMENTO VALUES" +
            "('" + cpf + "', '" + nome_animal + "' , '" + tipo_animal + "', '" + servico + "', '" + date + "'" +
            ",'"+time+"', '"+descricao+"')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.ClosedConnection();
        }

        //=================================================================
        //EDITANDO UM AGENDAMENTO
        //=================================================================

        public void EditarAgendamento(int id, string nome_animal, string tipo_animal,
        string servico,  string descricao, DateTime horario, DateTime diaAgendamento)
        {
            cmd.Connection = conn.OpenConnection();

            cmd.Parameters.AddWithValue("@ID_AGENDAMENTO",id);
            cmd.Parameters.AddWithValue("@NOME_ANIMAL",nome_animal);
            cmd.Parameters.AddWithValue("@TIPO_ANIMAL",tipo_animal);
            cmd.Parameters.AddWithValue("@SERVICO",servico);
            cmd.Parameters.AddWithValue("@DESCRICAO",descricao);
            cmd.Parameters.AddWithValue("@DATA", diaAgendamento);
            cmd.Parameters.AddWithValue("@HORARIO", horario);

            cmd.CommandText = "UPDATE AGENDAMENTO SET " +
                "NOME_ANIMAL = @NOME_ANIMAL, " +
                "TIPO_ANIMAL = @TIPO_ANIMAL, " +
                "SERVICO = @SERVICO, " +
                "DESCRICAO = @DESCRICAO, " +
                "DIA_AGENDAMENTO = @DATA, "+
                "HORARIO_AGENDAMENTO = @HORARIO "+
                "WHERE ID_AGENDAMENTO = @ID_AGENDAMENTO";

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.ClosedConnection();


        }

        




        //=================================================================
        //DELETAR UM AGENDAMENTO
        //=================================================================
        public void ExcluirAgendamento(int id_agendamento)
        {
            cmd.Connection = conn.OpenConnection();
            cmd.CommandText = ("DELETE FROM AGENDAMENTO WHERE ID_AGENDAMENTO = " + id_agendamento);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.ClosedConnection();

        }


        //====================================================================
        //MOSTRANDO TODOS OS AGENDAMENTOS 
        //====================================================================
        public DataTable MostrarAgendamentos()
        {
            cmd.Connection = conn.OpenConnection();
            cmd.CommandText = "SELECT * FROM AGENDAMENTO";
            ler = cmd.ExecuteReader();
            tabela.Load(ler);
            conn.ClosedConnection();

            return tabela;
        }

         


    }
}
