using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace InterfaceUser
{
    public partial class frmAgendamentos : Form
    {
        B_Agendamento ObjetoBusiness = new B_Agendamento();

        int id_agendamento; 

        

        public frmAgendamentos()
        {
            InitializeComponent();
            
        }

        private void frmAgendamentoscs_Load(object sender, EventArgs e)
        {
            MostrarAgendamentos();
            lblResultados.Text = "Quantidade de Agendamentos = " + MostrarQuantidadeAgendamentos();
        }


        //==========================================================================================
        // METODO QUE MOSTRA QUANTIDADE PARA O LBLQUANTIDADE 
        //==========================================================================================
        private string MostrarQuantidadeAgendamentos()
        {

          string quantidade =  Convert.ToString(dataGridAgendamentos.Rows.Count);

          return quantidade;
            
        }


        //==========================================================================================
        // METODO QUE MOSTRA TODOS OS AGENDAMENTOS
        //==========================================================================================
        private void MostrarAgendamentos()
        {
            //REFRESH NO OBJETO BUSINESS, PARA QUE NÃO REPITA O MOSTRARAgendamentos 
            B_Agendamento Objeto = new B_Agendamento();
            //Configurando as dimensões das colunas na DataGrid//

            dataGridAgendamentos.DataSource = Objeto.MostrarAgendamentos();
            dataGridAgendamentos.Columns["ID_AGENDAMENTO"].Width = 25;
            dataGridAgendamentos.Columns["CPF"].Width = 90;
            dataGridAgendamentos.Columns["DIA_AGENDAMENTO"].Width = 70;
            dataGridAgendamentos.Columns["HORARIO_AGENDAMENTO"].Width = 60;
            dataGridAgendamentos.Columns["DESCRICAO"].Width = 277;


            //Desabilitando o botão de excluir e editar ao construir o DataGrid
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;

        }



        private void btnAgendar_Click(object sender, EventArgs e)
        {
           
            frmAgendar form = new frmAgendar(id_agendamento, true);
            form.Show();
           


        }


        //==========================================================================================
        // SELECIONANDO O ID_AGENDAMENTO PARA EXCLUIR OU EDITAR 
        //==========================================================================================
        private void dataGridAgendamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_agendamento = Convert.ToInt16(dataGridAgendamentos.Rows[e.RowIndex].Cells["ID_AGENDAMENTO"].Value);
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }




        //====================================================================================
        // EXCLUIR AGENDAMENTO
        //====================================================================================
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Excluir o Agendamento " + id_agendamento.ToString() + " ? ",
                "Excluir",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            
            else
            {
                try
                {


                    ObjetoBusiness.ExcluirAgendamento(id_agendamento);
                    MessageBox.Show("Excluido com Sucesso");
                    MostrarAgendamentos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao tentar Excluir");
                }
            }
        }
    }
}
