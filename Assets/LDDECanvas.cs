
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class LDDECanvas : MonoBehaviour

    {
        public Text TextoMostrado;
        public GameObject Painel2;
        public GameObject Painel3;
        public InputField nome;
        public InputField endereco;
        public InputField email;
        public InputField busca;

            
        public void Main(int qual)
        {
            
                       
            LDDE<String> Tudo = new LDDE<String>();
            
            
            // Mostrar no Painel do Canvas Principal
            
            if(qual == 1){
                Tudo.Inserir(nome.text);
                TextoMostrado.text = nome.text; 

                if(Painel2 != null)
                {
                    bool isActive = Painel2.activeSelf;
                    Painel2.SetActive(!isActive);
                }

            }
            if(qual == 2){

                TextoMostrado.text = Tudo.Busca(busca.text);

                if(Painel3 != null)
                {
                    bool isActive = Painel3.activeSelf;
                    Painel3.SetActive(!isActive);
                }
            }
            if(qual == 3){
                Tudo.Remover("May");
                TextoMostrado.text = "Cancelado";
            }

            if(qual == 4){
               
                bool isActive = Painel2.activeSelf;
                    Painel2.SetActive(!isActive);
            }

            
   
         /*  
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
         */
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
        Gravar();
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
     
        // Busca pelo TxT
        public String Busca(T nome)
        {
            
        String fail = "fail";
        String sucess = "sucess";

        //string local = @"/sdcard/LDDE.txt";
         string local = @"c:\temp\LDDE.txt";
        using (StreamReader sr = File.OpenText(local))
        {
            string conteudo;
            while ((conteudo = sr.ReadLine()) != null)
            {
                    if(conteudo.Equals(nome))
                {
                    return sucess;
                    //Console.Write("Nome Encontrado!\n");    
                    break;
                }
            }
        }
        return fail;
        }               

     
     //Busca normal
     /*   public String Busca(T nome)
        {
        
        No<T> Aux = new No<T>();
        Aux = Primeiro;
        String fail = "fail";
        String sucess = "sucess";
                
            for(int i = 0; i < Quantidade; i++)
            {
                if(Aux.Valor.Equals(nome))
                {
                    return sucess;
                    //Console.Write("Nome Encontrado!\n");    
                    break;
                }
                
                Aux = Aux.Proximo;
            }
            return fail;   
        }

        */

        public void Remover(String nome)
        {

        No<T> Aux = new No<T>();
        Aux = Primeiro;

       // string local = @"/sdcard/LDDE.txt";
               
         string local = @"c:\temp\LDDE.txt";
     
            using (StreamWriter sw = File.CreateText(local))
            {
                for(int i = 0; i < Quantidade; i++){
   
                if(Aux.Valor.Equals(nome)){}
                else{
                    sw.WriteLine(Aux.Valor);
                }
               
                Aux = Aux.Proximo;

                }
            }
        }

    // Remover normal
      /*  public void Remover(T nome)
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
             */
        }
    
    }