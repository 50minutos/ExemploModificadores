using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExemploModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Base b; //declaração -> determina que membros a var tem acesso
            b = new Base(); //atribuição (atribuímos uma instância de Base à var b) -> determina a VERSÃO do membro que estamos acessando
            b.M1(); //Base.M1()

            Derivada d = new Derivada();
            d.M1(); //Derivada.M1()

            OutraDerivada od = new OutraDerivada();
            od.M1(); //OutraDerivada.M1()

            Console.WriteLine();

            b.M2(); //Base.M2()
            d.M2(); //Derivada.M2()
            od.M2(); //OutraDerivada.M2()

            Console.WriteLine();

            Base x;

            x = new Derivada(); //polimorfismo

            x.M1(); //Derivada.M1()
            x.M2(); //Base.M2()
            x.M3(); //Base.M3()

            Console.WriteLine();

            x = new OutraDerivada();

            x.M1(); //OutraDerivada.M1()
            x.M2(); //Base.M2()
            x.M3(); //Base.M3()

            Console.WriteLine();

            Derivada y;

            y = new OutraDerivada();

            y.M1(); //OutraDerivada.M1()
            y.M2(); //Derivada.M2()
            y.M3(); //OutraDerivada.M3()

            Console.ReadKey();
        }
    }

    class Base
    {
        //virtual -> pode ser sobreposto
        public virtual void M1() { Console.WriteLine("Base.M1()"); }
   
        public void M2() { Console.WriteLine("Base.M2()"); }
        
        public virtual void M3() { Console.WriteLine("Base.M3()"); }
    }

    class Derivada : Base
    {
        //override -> indica a sobreposição (substituição) do método equivalente da classe base
        public override void M1() { Console.WriteLine("Derivada.M1()"); }

        //new -> indica ocultação do método equivalente da classe base (NÃO É SOBREPOSIÇÃO - ENTÃO NÃO FUNCIONA EM POLIMORFISMO)
        public new void M2() { Console.WriteLine("Derivada.M2()"); }

        public new virtual void M3() { Console.WriteLine("Derivada.M3()"); }
    }
    
    class OutraDerivada : Derivada
    {
        public override void M1() { Console.WriteLine("OutraDerivada.M1()"); }
        
        public new void M2() { Console.WriteLine("OutraDerivada.M2()"); }
        
        public override void M3() { Console.WriteLine("OutraDerivada.M3()"); }
    }
}
