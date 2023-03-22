using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateNet
{
    //Metodo Generico para o cliente implementar
    public delegate void Calculo(double altura, double largura, double profundidade);
    public class FiguraGeometrica
    {
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Profundidade { get; set; }

        public event Calculo Calcular; // evento para o delegate 

        //Metodo Generico da Classe Usando o Delegate para o cliente implementar
        public void EventHandler()
        {
            Calcular(this.Altura, this.Largura, this.Profundidade); // Execultado
        }
    }
}
