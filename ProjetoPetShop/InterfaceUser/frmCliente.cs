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
    public partial class frmCliente : Form
    {
        private B_Cliente ObjetoBusinessCliente = new B_Cliente();
        private B_Agendamento ObjetoBusinessAgendamento = new B_Agendamento();

        bool editar = false;
       

        public frmCliente()
        {
            InitializeComponent();
            
           
           
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarDados() == false)
            {
                return;
            }
            //=====================================================================================
            // SE FOR PARA UM NOVO CLIENTE, EXECUTA ESSE CODIGO
            //=====================================================================================
            if (editar == false)
            {


                try
                {
                    ObjetoBusinessCliente.InserirCliente
                    (mskTxtCpf.Text, txtNome.Text, mskTelefone.Text, mskCep.Text, txtEmail.Text);
                    MessageBox.Show("REGISTRADO COM SUCESSO");
                    this.btnAgendar.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO AO TENTAR REGISTRAR CLIENTE");
                }

            }

            //=====================================================================================
            // CASO SEJA UM CLIENTE JÁ EXISTENTE, APENAS EDITA
            //=====================================================================================
            else
            {
                try
                {
                  ObjetoBusinessCliente.EditarCliente(mskTxtCpf.Text, txtNome.Text, mskTelefone.Text,
                  mskCep.Text, txtEmail.Text);
                    MessageBox.Show("ALTERADO COM SUCESSO");

                }catch(Exception ex)
                {
                    MessageBox.Show("ERRO AO TENTAR ATUALIZAR");
                }
                

            }


        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
          

            frmAgendar frm = new frmAgendar(mskTxtCpf.Text, ObjetoBusinessAgendamento.ID_Disponivel(), false);
            frm.Show();
        }



        //=====================================================================================
        // VALIDA TODOS OS CAMPOS DO FORM 
        //=====================================================================================
        private bool ValidarDados()
        {
            if (mskTxtCpf.Text.Trim().Length < 14)
            {
                MessageBox.Show("Por Favor Digitar um CPF valido", "PETSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskTxtCpf.Clear();
                mskTxtCpf.Focus();

                return false;
            }


            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Campo Nome é Obrigatorio", "PETSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Clear();
                txtNome.Focus();

                return false;
            }


            if (mskTelefone.Text.Trim().Length < 15)
            {
                MessageBox.Show("Favor Digitar Um Telefone", "PETSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskTelefone.Clear();
                mskTelefone.Focus();

                return false;
            }

            if (mskCep.Text.Trim().Length < 9) 
            {
                MessageBox.Show("Campo CEP é Obrigatorio", "PETSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskCep.Clear();
                mskCep.Focus();

                return false;
            }

       
            //CASO TODAS AS VALIDAÇÕES ACIMA FOR VERDADE
            return true;
        
    
        }

        //=====================================================================================
        // LIMPA OS CAMPOS DO FORM
        //=====================================================================================
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mskTxtCpf.Clear();
            txtNome.Clear();
            mskTelefone.Clear();
            mskCep.Clear();
            txtEmail.Clear();
            this.editar = false;
            this.mskTxtCpf.Enabled = true;
            this.btnAgendar.Enabled = false;
        }

        private void btnPesquisarCpf_Click(object sender, EventArgs e)
        {

            if (mskTxtCpf.Text.Trim().Length < 14)
            {
                MessageBox.Show("Favor Digita um CPF Valido", "PETSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskTxtCpf.Clear();
                mskTxtCpf.Focus();
                return;

            }

                DataTable dados = ObjetoBusinessCliente.PesquisarCliente(mskTxtCpf.Text);

            

            if(dados.Rows.Count == 0)
            {
                MessageBox.Show("CLIENTE NÃO CADASTRADO");
            }

            else
            {
                btnAgendar.Enabled = true;
                mskTxtCpf.Enabled = false;
                mskTxtCpf.Text = dados.Rows[0]["CPF"].ToString();
                txtNome.Text = dados.Rows[0]["NOME_CLIENTE"].ToString();
                mskTelefone.Text = dados.Rows[0]["TELEFONE_CLIENTE"].ToString();
                mskCep.Text = dados.Rows[0]["CEP_CLIENTE"].ToString();
                txtEmail.Text = dados.Rows[0]["EMAIL_CLIENTE"].ToString();
                this.editar = true;
            }


        }



    }
}
