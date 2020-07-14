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
    public partial class frmAgendar : Form
    {
        bool editar = false;
        int id_agendamento;
        

        B_Agendamento ObjetoAgendamento = new B_Agendamento();

        public frmAgendar()
        {
            InitializeComponent();
            MaskeTxtCpf.Enabled = false;
            txtId.Enabled = false;

        }

        private void frmAgendar_Load(object sender, EventArgs e)
        {
            
        }

      

        //Construindo um construtor para editar contato //
        public frmAgendar(int id, bool editar)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            MaskeTxtCpf.Enabled = false;
            txtId.Enabled = false;
            this.editar = editar;
            this.id_agendamento = id;
            DataTable dados =  ObjetoAgendamento.MostrarDados(id);
            MaskeTxtCpf.Text = dados.Rows[0]["CPF"].ToString();
            cmbServico.Text = dados.Rows[0]["SERVICO"].ToString();
            dateAgendamento.Text = dados.Rows[0]["DIA_AGENDAMENTO"].ToString();
            maskHorario.Text = dados.Rows[0]["HORARIO_AGENDAMENTO"].ToString();
            txtNomeAnimal.Text = dados.Rows[0]["NOME_ANIMAL"].ToString();
            txtTipoAnimal.Text = dados.Rows[0]["TIPO_ANIMAL"].ToString();
            txtDescricao.Text = dados.Rows[0]["DESCRICAO"].ToString();




        }


        //Construindo um construtor para passar o CPF e o ID do FRM CLIENTE para esse frm//
        public frmAgendar(string cpf ,int id, bool editar)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            MaskeTxtCpf.Text = cpf;
            MaskeTxtCpf.Enabled = false;
            txtId.Enabled = false;
            this.editar = editar;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            //=================================================================
            //CRIANDO UM NOVO AGENDAMENTO
            //=================================================================
            if (editar == false)

               try
                {
                    {
                        ObjetoAgendamento.InserirAgendamento(MaskeTxtCpf.Text, txtNomeAnimal.Text, txtTipoAnimal.Text,
                        cmbServico.Text, dateAgendamento.Text, maskHorario.Text, txtDescricao.Text);
                        MessageBox.Show("AGENDAMENTO COM SUCESSO");

                    }

                }catch (Exception ex)
                    {
                        MessageBox.Show("ERRO AO TENTAR AGENDAR");
                    }


            //=================================================================
            //EDITANDO UM AGENDAMENTO
            //=================================================================
            else
            {

                ObjetoAgendamento.EditarAgendamento
                (txtId.Text,txtNomeAnimal.Text, txtTipoAnimal.Text, cmbServico.Text, txtDescricao.Text, maskHorario.Text, maskHorario.Text);
                MessageBox.Show("ALTERADO COM SUCESSO");
                
                this.Close();


            }


        }

        
    }
}
