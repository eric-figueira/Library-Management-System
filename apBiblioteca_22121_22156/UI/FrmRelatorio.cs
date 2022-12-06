using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL; 
using DTO;

namespace apBiblioteca_22121_22156.UI
{
    public partial class FrmRelatorio : Form
    {
        public string banco, usuario, senha;

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            int y_starting_point = 55;
            // Emprestimos atrasados
            // Percorreremos uma lista de emprestimos e compararemos se a data atual é maior que a data prevista do empréstimo
            EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
            List<Emprestimo> aux = bll.SelecionarListEmprestimos();  
            for (int i = 0; i < aux.Count; i++)
            {
                // Data atual:
                DateTime hoje = new DateTime();
                int dias_atraso = hoje.Subtract(aux[i].DataDevolucaoPrevista).Days;
                if (dias_atraso > 0)
                {
                    Label label = new Label();
                    label.Location = new Point(50,y_starting_point);
                    label.Font = new Font("Microsoft Sans Serif", 15.75F);
                    label.Text = aux[i].IdLeitor + " está com um atraso de " + dias_atraso + " dias";
                    this.Controls.Add(label);
                }

                y_starting_point += y_starting_point;
            }
        }

        public FrmRelatorio()
        {
            InitializeComponent();
        }
    }
}
