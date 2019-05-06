using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetAndSetText : MonoBehaviour
{
    public InputField nome;
    public InputField endereco;
    public InputField email;
    public InputField busca;

    public Text TudoText;

    public void setget()
    {
        TudoText.text = nome.text + "\n" + endereco.text + "\n" + email.text; 
    }

}
