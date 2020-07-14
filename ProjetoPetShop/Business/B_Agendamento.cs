using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Database;

namespace Business
{
     
    public class B_Agendamento
    {
        private DB_Agendamento ObjetoAgendamentoDB = new DB_Agendamento();


        //PEGANDO ID DISPONIVEL NA CAMADA DB PASSANDO PARA UI
        public int ID_Disponivel()
        {
           int id =  ObjetoAgendamentoDB.ID_Disponivel();


            return id;
        } 

        //METODO QUE MOSTRA AGENDAMENTOS PARA A CAMADA UI 
        public DataTable MostrarAgendamentos()
        {

          DataTable tabela = new DataTable();
          tabela = ObjetoAgendamentoDB.MostrarAgendamentos();

          return tabela;
        }


        //===========================================================
        // INSERIR NOVO AGENDAMENTO
        //============================================================
        public void InserirAgendamento (string cpf, string nome_animal, string tipo_animal,
        string servico,string date, string time, string descricao)
        {
            ObjetoAgendamentoDB.InserirAngendamento(cpf, nome_animal, tipo_animal,
            servico,Convert.ToDateTime(date),Convert.ToDateTime(time), descricao);
        }

        //===========================================================
        // CARREGAR DADOS DE UM AGENDAMENTO JÁ FEITO
        //============================================================
        public DataTable MostrarDados(int id_agendamento)
        {
           DataTable dados = ObjetoAgendamentoDB.MostrarDados(id_agendamento);
            return dados;
        }

        //===========================================================
        // EDITAR AGENDAMENTO
        //============================================================
        public void EditarAgendamento(string id, string nome_animal, string tipo_animal,
        string servico, string descricao, string diaAgendamento, string horario)
        {
           ObjetoAgendamentoDB.EditarAgendamento(Convert.ToInt16(id), nome_animal, tipo_animal, servico, descricao,
           Convert.ToDateTime(diaAgendamento), Convert.ToDateTime(horario));
        }



        //===========================================================
        // EXCLUIR AGENDAMENTO
        //============================================================
        public void ExcluirAgendamento(int id_agendamento)
        {
            ObjetoAgendamentoDB.ExcluirAgendamento(id_agendamento);
        }




    }
}
