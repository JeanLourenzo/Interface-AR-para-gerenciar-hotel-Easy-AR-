     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.Events;
     
     public class WebsiteButton : MonoBehaviour {
     
         public GameObject definedButton;
         public UnityEvent OnClick = new UnityEvent();
     
         void Start () {
             definedButton = this.gameObject;
         }
         
         void Update () {
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit Hit;
             
             if (Input.GetMouseButtonDown(0))
             {
                 if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                 {
                     Debug.Log("Button Clicked");
                     OnClick.Invoke();
                 }
             }    
         }
     }