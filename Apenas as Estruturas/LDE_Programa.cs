using System;
using System.IO;

    class LDE_Programa
    {
        static void Main(string[] args)
        {
 
           LDE<String> TudoLDE = new LDE<String>();
            

            Console.Write("Digite seu nome: ");
            String nome = Console.ReadLine();

            TudoLDE.Inserir(nome);
            TudoLDE.Inserir("May");
            TudoLDE.Inserir("Lin");
  
        }
    

    public class No<T>
    {
            public No<T> Proximo;
            public T Valor;
        
    }

    public class LDE<T>
    {
        private No<T> Primeiro;
        private No<T> Link;
        private int Quantidade; // Quantidade de cadastros;
        public LDE() => Primeiro = null;

        public void Inserir(T t)
        {
            No<T> Novo = new No<T>();
                      
            if (Primeiro == null){
            Novo.Proximo = null;
            Novo.Valor = t;
            Primeiro = Novo;
            Link = Novo;
            Quantidade = 1;
                                     
            }
            else{
            Link.Proximo = Novo;
            Novo.Proximo = null;
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
            string local = @"c:\temp\LDE.txt";
     
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
        string local = @"c:\temp\LDE.txt";

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

        }
    }
