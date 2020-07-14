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
using System.Runtime.InteropServices;


namespace InterfaceUser
{
    public partial class FrmHome : Form

    {
        //===============================================================//
        //Instanciando objeto classe Business
        //===============================================================//
        B_Cliente objetoBusinessCliente = new B_Cliente();



        public FrmHome()
        {
            InitializeComponent();

        }

        //===============================================================//
        // FUNÇÃO DA LIBRAY SYSTEM.RUNTIME.INTEROPServices 
        // Precisamos colocar o esse codigo no  Title_Bar_MouseDown IN THE PANEL 
        // ReleaseCapture();
        // SendMessage(this.Handle, 0x112, 0xf012, 0);
        // Essa função permite que movemos o Panel para esquerda e direita
        //===============================================================//
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);






        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Sair ?", "Sair",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            else
                Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximize.Visible = false;
            btnReturn.Visible = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnReturn.Visible = false;
            btnMaximize.Visible = true;
        }

        
        //===================================================================//
        // Quando seguramos o mouse na BarraTitulo podemos mover a Screen, 
        //=====================================================================//
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmNoPanel(new frmCliente());
        }


        private void AbrirFrmNoPanel(object FrmFilho)
        {
            if (this.PanelContainer.Controls.Count > 0)
                this.PanelContainer.Controls.RemoveAt(0);
            Form frm = FrmFilho as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.PanelContainer.Controls.Add(frm);
            this.PanelContainer.Tag = frm;
            frm.Show();

        }

        private void btnAgendamento_Click(object sender, EventArgs e)
        {
            AbrirFrmNoPanel(new frmAgendamentos());

        }

        
    }

}

