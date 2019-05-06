using System;
using System.IO;

namespace Estruturas
{
    class LDDE_Programa
    {
        static void Main(string[] args)
        {
 
           LDDE<String> Tudo = new LDDE<String>();
            

            Console.Write("Digite seu nome: ");
            String nome = Console.ReadLine();
           
            Tudo.Inserir(nome);
            
            Tudo.Inserir("Lilian");
            Tudo.Inserir("Patricia");
            Tudo.Inserir("Karin");
            
            Tudo.Imprimir();
            Tudo.Busca("Lilian");
            Tudo.Remover("Patricia");

            Tudo.Gravar();
            Tudo.Imprimir();
        
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
        private int Quantidade; // Quantidade de cadastros;
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


        //Gravar no Arquivo;
        public void Gravar(){

        No<T> Aux = new No<T>();
        Aux = Primeiro;
        
           
            //string local = @"/sdcard/LDDE.txt";
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

        No<T> Aux = new No<T>();
        Aux = Primeiro;

            for(int i = 0; i < Quantidade; i++)
            {
                Console.Write(Aux.Valor+"\n");
                Aux = Aux.Proximo;
            }
        }

        //Imprimindo depois de ler o Arquivo;
        public void ImprimirGravado()
        {
        //string local = @"/sdcard/LDDE.txt";
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
     
      public void Busca(T nome)
        {
        
        No<T> Aux = new No<T>();
        Aux = Primeiro;
                
            for(int i = 0; i < Quantidade; i++)
            {
                if(Aux.Valor.Equals(nome))
                {
                    Console.Write("Nome Encontrado!\n");    
                    break;
                }
                
                Aux = Aux.Proximo;
            }
        }

     public void Remover(T nome)
        {
        
        No<T> Aux = new No<T>();
        Aux = Primeiro;
                
            for(int i = 0; i < Quantidade; i++)
            {
                if(Aux.Valor.Equals(nome))
                {
                    // Removendo o primeiro nome;
                    if(Aux.Valor.Equals(Primeiro.Valor))
                    {
                        Primeiro = Primeiro.Proximo;
                        Quantidade--;
                        break;
                    }
                    // Removendo o ultimo nome;
                    if(Aux.Proximo == null)
                    {                  
                        Aux.Anterior.Proximo = null;
                        Quantidade--;
                        break;                   
                    }
                    // Removendo os outros nomes;
                        Aux.Anterior.Proximo = Aux.Proximo;
                        Aux.Proximo.Anterior = Aux.Anterior;
                        Quantidade--;
                        break;
                }
                Aux = Aux.Proximo;
                }
            }
        }
    }
}







