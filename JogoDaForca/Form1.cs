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
    public partial class Form1 : Form
    {
        const int X = 34, Y = 207;
        string palavraDigitada = Inicio.palavra.ToUpper(), dicaDigitada = Inicio.dica;
        Label[] labels;
        Image[] forca = new Image[8];
        char[] acentos = new char[6];
        int tamanhoVetor, erros = 0;

        private void IniciarImagens()
        {
            forca[0] = Properties.Resources.forca0;
            forca[1] = Properties.Resources.forca1;
            forca[2] = Properties.Resources.forca2;
            forca[3] = Properties.Resources.forca3;
            forca[4] = Properties.Resources.forca4;
            forca[5] = Properties.Resources.forca5;
            forca[6] = Properties.Resources.forca6;
            forca[7] = Properties.Resources.forca7;
        }
        private void IniciarLabels()
        {
            tamanhoVetor = palavraDigitada.Length;
            labels = new Label[tamanhoVetor];

            for (int i = 0; i < palavraDigitada.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Font = new Font("Arial", 48F, FontStyle.Bold);
                labels[i].ForeColor = SystemColors.ActiveCaption;
                labels[i].Size = new Size(68, 73);
                labels[i].Text = palavraDigitada[i] == ' ' ? " " : "_";
                labels[i].Location = i == 0 ? new Point(X, Y) : new Point((labels[i - 1].Location.X + 56), Y);
                this.Controls.Add(labels[i]);
            }
        }

        private void btnConsoantes(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if (palavraDigitada.Contains(Convert.ToChar(btn.Text)))
            {
                for (int i = 0; i < palavraDigitada.Length; i++)
                {
                    if (palavraDigitada[i].ToString() == btn.Text)
                    {
                        labels[i].Text = btn.Text;
                    }
                }
            }
            else
            {
                erros++;
                pbForca.Image = forca[erros];
            }

            btn.Enabled = false;
            btn.BackColor = System.Drawing.Color.Red;
            ChecarFinal();
        }

        private void btnVogais(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            var caractere = ' ';

            for (int i = 0; i < palavraDigitada.Length; i++)
            {
                acentos = btn.Text.VerificaVetor();
                caractere = palavraDigitada[i].VerificarLetra(acentos);

                if (caractere == palavraDigitada[i])
                {
                    labels[i].Text = caractere.ToString();
                }
            }

            acentos = btn.Text.VerificaVetor();
            VerificarErros(acentos);
            btn.Enabled = false;
            btn.BackColor = System.Drawing.Color.Red;
            ChecarFinal();
        }

        private void VerificarErros(char[] acento)
        {
            var verificar = acento.Count(v => palavraDigitada.Contains(v));
            if (verificar == 0)
            {
                erros++;
                pbForca.Image = forca[erros];
            }
        }

        private void ChecarFinal()
        {
            if (erros == 7)
            {
                MessageBox.Show("Fim de jogo! A resposta era: " + palavraDigitada);
                JogarNovamente();
            }
            else
            {
                var acertos = labels.Count(l => l.Text != "_");
                if (acertos == palavraDigitada.Length)
                {
                    MessageBox.Show("Parabens, você descobriu a palavra!");
                    JogarNovamente();
                }
            }
        }

        private void JogarNovamente()
        {
            DialogResult msg = MessageBox.Show("Deseja jogar novamente?", "Diálogo", MessageBoxButtons.YesNo);
            if (msg == DialogResult.Yes)
            {
                Inicio i = new Inicio();
                i.Show();
                this.Enabled = this.Visible = false;
            } 
            else
            {
                Application.Exit();
            }
        }
        public Form1()
        {
            IniciarLabels();
            IniciarImagens();
            InitializeComponent();

            lblDica.Text = "Dica: " + dicaDigitada;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
