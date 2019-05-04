     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.Events;
     
     public class CriaOnclickEmObjeto : MonoBehaviour {
     
         public UnityEvent OnClick = new UnityEvent();
         
         void Update ()
        {
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit Hit;
             
             if (Input.GetMouseButtonDown(0))
             {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                  Debug.Log("Funcionou");
                  OnClick.Invoke();
               
                }
             }
        }
     }