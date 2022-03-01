using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    public int monedas;

    void Start()
    {
        Instancia = this;
    }

    void Update()
    {
        
    }
    public void AgregarMoneda(){
        monedas ++;
        Debug.Log("Monedas:" + monedas);
    }
}
