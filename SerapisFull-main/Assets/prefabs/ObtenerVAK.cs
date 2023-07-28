using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerVAK : MonoBehaviour
{
    public CalcularRespuesta calc;
    public GuardaInfo GI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ObtenerDescripcion()
    {
        GI.datos.descripcion =calc.tipoVAK;
    }
}
