using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_de_texto_3I
{
    public partial class EX_EDITORBASE : Form
    {
        public EX_EDITORBASE()
        {
            InitializeComponent();
        }

        //Criar Função Novo()
        private void Novo()
        {
            rtb_Texto.Clear(); // Método "Clear" limpa a área de edição do Objeto
            rtb_Texto.Focus(); // Método "Focus" posiciona o cursor na área de edição do Objeto
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            Novo();
        }


        //Criar a Função Abrir 
        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\User\Documents\";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "*.TXT|*.txt|Todos Arquivos (*.*)|*.* ";
            try
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream
                    (openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(arquivo);
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.rtb_Texto.Text = "";
                    string linha = sr.ReadLine();
                    while (linha != null)
                    {
                        this.rtb_Texto.Text += linha + "\n";
                        linha = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Abrir : " + ex.Message, "Sistema Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        //Criar Função Salvar
        private void Salvar()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() ==
                DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(arquivo);
                    sw.Flush();
                    sw.BaseStream.Seek(0, SeekOrigin.Begin);
                    sw.Write(this.rtb_Texto.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar : " + ex.Message, "Sistema Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Salvar();
        }


        //Criar a Função Copiar
        private void Copiar()
        {
            if (rtb_Texto.SelectionLength > 0)
            {
                rtb_Texto.Copy();
            }

        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        //Criar a Função Colar
        private void Colar()
        {
            rtb_Texto.Paste();

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }


        private void Negrito()
        {
            string nomeFonte = rtb_Texto.SelectionFont.Name;
            float tamanhoFonte = rtb_Texto.SelectionFont.Size;
            bool resp;
            resp = rtb_Texto.SelectionFont.Bold;
            //MessageBox.Show("" + resp);
            if (resp == false)
            {
                rtb_Texto.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold);
            }
            else
            {
                rtb_Texto.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        //Criar a Função Italico
        private void Italico()
        {
            string nomeFonte = rtb_Texto.SelectionFont.Name;
            float tamanhoFonte = rtb_Texto.SelectionFont.Size;
            bool resp;
            resp = rtb_Texto.SelectionFont.Italic;
            //MessageBox.Show("" + resp);
            if (resp == false)
            {
                rtb_Texto.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Italic);
            }
            else
            {
                rtb_Texto.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);
            }

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void italicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        //Criar a Função Sublinhar
        private void Sublinhar()
        {
            string nomeFonte = rtb_Texto.SelectionFont.Name;
            float tamanhoFonte = rtb_Texto.SelectionFont.Size;
            bool resp;
            resp = rtb_Texto.SelectionFont.Underline;
            //MessageBox.Show(""+resp);
            if (resp == false)
            {
                rtb_Texto.SelectionFont = new Font(nomeFonte,
                tamanhoFonte, FontStyle.Underline);
            }
            else
            {
                rtb_Texto.SelectionFont = new Font(nomeFonte,
                tamanhoFonte, FontStyle.Regular);

            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Sublinhar();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhar();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

            FontDialog fonte = new FontDialog();
            if (fonte.ShowDialog() == DialogResult.OK)
            {
                rtb_Texto.Font = fonte.Font;

            }
        }

        //Criar a Função Esquerda
        private void Esquerda()
        {
            rtb_Texto.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Esquerda();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Esquerda();
        }

        //Criar a Função Centralizar
        private void Centralizar()
        {
            rtb_Texto.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void centroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Centralizar();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Centralizar();
        }

        private void Direita()
        {
            rtb_Texto.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Direita();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Direita();
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_Texto.Undo();
        }

        private void refazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_Texto.Redo();
        }


    }
}
