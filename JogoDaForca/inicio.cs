using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaForca
{
    public partial class Inicio : Form
    {
        public static string palavra, dica;
        public Inicio()
        {
            InitializeComponent();
        }

        private void txtPalavra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsControl(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) &&  (e.KeyChar != '-'))
                e.Handled = true;
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            palavra = txtPalavra.Text;
            dica = txtDica.Text;

            if (txtPalavra.Text != "")
            {
                Form1 f = new Form1();
                f.Show();
                this.Visible = this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Informe uma palavra válida!");
            }
        }
    }
}
