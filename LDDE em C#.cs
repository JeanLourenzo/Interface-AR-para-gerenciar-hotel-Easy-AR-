using System;
using System.IO;

namespace Estruturas
{
    class Program
    {
        static void Main(string[] args)
        {
 
            LDDE<String> Tudo = new LDDE<String>();
           
            Console.Write("Digite seu nome: ");
            String nome = Console.ReadLine();
           
            Tudo.Inserir(nome);
            Tudo.Gravar();
            Tudo.Imprimir();
        }
    }

    public class No<T>
    {
            public No<T> Proximo;
            public No<T> Anterior;
            public T Valor;
        
    }

    public class LDDE<T>
    {
        private No<T> Primeiro;
        private No<T> Link;
        private int Quantidade;
        public LDDE() => Primeiro = null;

        public void Inserir(T t)
        {
            No<T> Novo = new No<T>();
                      
            if (Primeiro == null){
            Novo.Proximo = null;
            Novo.Anterior = null;
            Novo.Valor = t;
            Primeiro = Novo;
            Link = Novo;
            Quantidade = 1;
                                     
            }
            else{
            Link.Proximo = Novo;
            Novo.Proximo = null;
            Novo.Anterior = Link;
            Novo.Valor = t;
            Link = Novo;
            Quantidade++;
            }        
        
        }

        public void Gravar(){

        No<T> Aux = new No<T>();
        Aux = Primeiro;

            string local = @"c:\temp\LDDE.txt";
     
            using (StreamWriter sw = File.CreateText(local))
            {
                for(int i = 0; i < Quantidade; i++){
   
                sw.WriteLine(Aux.Valor);
               
                Aux = Aux.Proximo;

                }
            }
        }

        public void Imprimir()
        {
        string local = @"c:\temp\LDDE.txt";
        using (StreamReader sr = File.OpenText(local))
        {
            string conteudo;
            while ((conteudo = sr.ReadLine()) != null)
            {
                Console.WriteLine(conteudo);
            }
        }
        }
    }
}