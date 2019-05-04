using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudarTexto : MonoBehaviour
{
    public Text TextoMostrado = null;
    
    public void MudaTexto(string novotexto)
    {
    novotexto = "BBB";
    TextoMostrado.text = novotexto;

        
    }
}
