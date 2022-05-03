using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //для препядствий триггер на столкновение и у него рестарт
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           // other.gameObject.GetComponent<MapGenerator>().ResetMaps();
        }
    }
}
