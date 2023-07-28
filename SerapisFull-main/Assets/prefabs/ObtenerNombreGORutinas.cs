using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerNombreGORutinas : MonoBehaviour
{
    public GameObject obj;
    public GuardaInfo GI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObtenerNombreParaDescripcion()
    {
        GI.datos.descripcion = "La emoción de hoy es: "+ obj.name;


    }
}
