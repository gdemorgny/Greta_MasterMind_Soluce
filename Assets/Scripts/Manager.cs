using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
   public Line[] lines;
   public GameObject[] UI_lines;
   public Color[] answer;
   public Color[] Colors;

   private GameObject _targetMouseClic;
   private int activeLineNumber;

   private int sphereNumber = 4;
   private void Start()
   {
      CreateNewAnswer();
      ActivateLine();
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         _targetMouseClic = GetMousePosition();
         if (_targetMouseClic != null && _targetMouseClic.CompareTag("Sphere"))
         {
            _targetMouseClic.GetComponent<Sphere>().ChangeColor();
         }
      }
   }

   private void ActivateLine()
   {
      for (int i = 0; i < lines.Length; i++)
      {
         if (i == activeLineNumber)
         {
            lines[i].ActivateLine();
            UI_lines[i].SetActive(true);
         }
         else if (!lines[i].isActive)
         {
            lines[i].DesactivateLine();
         }
      }
   }
   
   
   private GameObject GetMousePosition()
   {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit))
      {
         return hit.collider.gameObject;
      }
      
      return null;
   }
   
   private void CreateNewAnswer()
   {
      for (int i = 0; i < sphereNumber; i++)
      {
         answer[i] = Colors[Random.Range(0, 3)];
      }
   }

   public void CheckAnswer()
   {
      int perfect=0;
      int good=0;
      
      for (int i=0;i<sphereNumber;i++)
      {
         if (lines[activeLineNumber].spheres[i].GetActualColor() == answer[i])
         {
            perfect++;
            
         }
         else
         {
            for (int j = 0; j < 4; j++)
            {
               if (lines[activeLineNumber].spheres[i].GetActualColor() == answer[j])
               {
                  good++;
                  
               }
            }
         }
      }
      UI_lines[activeLineNumber].GetComponent<UI_Line>().ShowResults(perfect,good);
      if (activeLineNumber < 11)
      {
         activeLineNumber++;
         ActivateLine();

      }
      else
      {
         //LOST !!!!
      }
   }
}
