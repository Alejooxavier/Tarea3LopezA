using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea3LopezA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notas : ContentPage
    {
        public Notas(string usuario, string clave)
        {
            InitializeComponent();
            lblUsuario.Text = "Usuario conectado: " + usuario;
        }

        private void btnCalcularNota_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                //declaracion de variables double para ingreso de notas
                double seguimiento1 = Convert.ToDouble(txtSeguimientoUno.Text);
                double examen1 = Convert.ToDouble(txtExamenUno.Text);
                double seguimiento2 = Convert.ToDouble(txtSeguimientoDos.Text);
                double examen2 = Convert.ToDouble(txtExamenDos.Text);

                

                if (seguimiento1 > 10 || examen1 > 10  || seguimiento2 > 10  || examen2 > 10)
                {
                    DisplayAlert("Mensaje de advertencia", "Las notas deben ser sobre 10", "ok");

                } else if (seguimiento1 < 0.1 || examen1 < 0.1 || seguimiento2 < 0.1 || examen2 < 0.1)
                {
                    DisplayAlert("Mensaje de advertencia", "Las notas no deben ser menores a 0.1", "ok");
                }
                else
                {
                    //calcular nota parcial
                    double notaParcial1 = (seguimiento1 * 0.3 / 10) + (examen1 * 0.2 / 10);
                    double notaParcial2 = (seguimiento2 * 0.3 / 10) + (examen2 * 0.2 / 10);
                    //resultado
                    double notaFinal = (notaParcial1 + notaParcial2) * 10;
                    txtFinal.Text = notaFinal.ToString();

                    if (notaFinal >= 7)
                    {
                        txtEstado.Text = "Aprobado";
                    }
                    if (notaFinal >= 5 && notaFinal <= 6.9)
                    {
                        txtEstado.Text = "Complementario";
                    }
                    if (notaFinal < 5)
                    {
                        txtEstado.Text = "Reprobado";
                    }
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje de alerta", ex.Message, "OK");
            }
        }
    }
}