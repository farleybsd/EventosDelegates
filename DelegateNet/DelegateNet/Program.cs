namespace DelegateNet
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var figura = new FiguraGeometrica
            {
                Altura = 10,
                Largura = 10,
                Profundidade = 10,
            };

            figura.Calcular += new Calculo(CalcularAreaQuadrado);
            figura.Calcular += new Calculo(CalcularVolumeCubo);

            figura.EventHandler(); // Disparado


            // Assinatura tem que ser igual do delegate 
            // implementacao do metodo
            static void CalcularAreaQuadrado(double altura, double largura, double profundidade)
            {
                var area = altura* largura;
                Console.WriteLine("Evento Disparado da Classe Cliente, calculo de area do quadrado");
                Console.WriteLine(area);
            }

            static void CalcularVolumeCubo(double altura, double largura, double profundidade)
            {
                var volume = altura * largura * profundidade;
                Console.WriteLine("Evento Disparado da Classe Cliente,calculo volume de um cubo");
                Console.WriteLine(volume);
            }

            return;

            // delegates ponteito para um metodo em memoria
            // Os delegates conhecem o retorno do metodo conheve as assinaturas mais nao conhece sua implementacao

            /*
             *  Eventos E Notificacoes 
             *  Delegate Anonimo
             *  Deletegate Function 
             *  Deletegate Action 
             *  Delegate Predicate 
             */

            // Quando fazer a instacia do objeto tem que realizar a chamada do delegate
            // Cliente que faz implementacao do Delegate

            //Eventos E Notificacoes 
            var lista = new Lista();
            lista.Notificar += Notificar;
            lista.Notificar += NotificarNovamente;
            lista.Add("A");
            lista.Add("B");
            lista.Add("C");


            //Deletegate Anonimo  
            // lista.PrintAllItems();

            //Deletegate Action faz um apotamento para um metodo e nao tem retorno
            Action<Lista> action = new Action<Lista>(i => Console.WriteLine(i));
            //lista.PrintAllItems(action);


            // Deletegate Function Pode Receber Diversos parametros

            Func<Lista, bool> func = new Func<Lista, bool>(i => i.Id == 1);
            //var item = lista.GetItemById(func);
            //Console.WriteLine(item);


            //Delegate Predicate igual Fuc mais sempre  vai retornar Boleano
            Predicate<Lista> pred = new Predicate<Lista>(i => i.Id == 2);

            var exists = lista.ExistItem(pred);
            Console.WriteLine(exists);

            static void Notificar()
            {
                Console.WriteLine("Fui notificado");
            }

            static void NotificarNovamente()
            {
                Console.WriteLine("Fui notificado novamente");
            }
        }
    }
}