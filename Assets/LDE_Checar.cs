using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LDE_Checar : MonoBehaviour
{

        public Text TextoMostrado;
        public void Main(int a)
        {
            
           LDE<int> TudoLDE = new LDE<int>();
            
        // 7 Quartos no total apenas o numero 3 disponivel.
            TudoLDE.Inserir(1);
            TudoLDE.Inserir(2);
         // TudoLDE.Inserir(3);
            TudoLDE.Inserir(4);
            TudoLDE.Inserir(5);
            TudoLDE.Inserir(6);
            TudoLDE.Inserir(7);
  
            int quarto = TudoLDE.Busca();
  
            if(a == 23425467){
            if (quarto == 0){

            TextoMostrado.text = "Não há vagas"; 

            }
            else{
            TextoMostrado.text = "Quarto numero: " + quarto + " está disponivel."; 

            }
            }
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
     
      public int Busca()
        {
        
        No<T> Aux = new No<T>();
        Aux = Primeiro;
                
            for(int i = 1; i <= Quantidade; i++)
            {
                if(!(Aux.Valor.Equals(i)))
                {
                                   
                    return i;
                      
                    break;
                }
                
                Aux = Aux.Proximo;
            }
            return 0;
        }

        }
    }
