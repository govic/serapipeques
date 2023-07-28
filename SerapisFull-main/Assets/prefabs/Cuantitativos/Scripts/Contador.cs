using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    //variables contables
    public int CErrores = 0;
    public int CCorrecto = 0;
    public int CTotal = 0;
    public TextMeshProUGUI Incorrectas;
    public TextMeshProUGUI Correctas;
    public TextMeshProUGUI Total;
    public ManagerActividad managerAct;
    public GameObject tabla;
    //Resultados

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void errores()
    {
        CErrores = CErrores + 1;
        total();
    }
    public void correcto()
    {
        CCorrecto = CCorrecto + 1;
        total();
    }
    public void total()
    {
        CTotal = CTotal + 1;
    }

    public void final()
    {
        print("entró al final");
        if (CCorrecto == managerAct.cantidadDeRespuestas)
        {
            //aquí debo dar la orden para que se muestre en pantalla y para que se guarde en la BD
            Incorrectas.text = CErrores.ToString();
            Correctas.text = CCorrecto.ToString();
            Total.text = CTotal.ToString();
            tabla.SetActive(true);
        }
    }

}
