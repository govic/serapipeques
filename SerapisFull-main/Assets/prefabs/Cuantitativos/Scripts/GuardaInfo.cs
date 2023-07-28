using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GuardaInfo : MonoBehaviour
{
    public string identificador_actividad="";
    public Contador contador;
    [System.Serializable]
    public struct estructuraDatosWeb
    {
        public string nombre;
        public int CCorrectas;
        public int CIncorrectas;
        public int CTotales;
        public string descripcion;
    }
    public estructuraDatosWeb datos;
    
    //segunda forma
    public void GuardarInfo2()
    {
        StartCoroutine(corrutinaGuardar2());
    }

    private IEnumerator corrutinaGuardar2()
    {
        Descripcion();
        datos.CCorrectas = contador.CCorrecto;
        datos.CIncorrectas = contador.CErrores;
        datos.CTotales = contador.CTotal;
        WWWForm form = new WWWForm();
        form.AddField("actividad", datos.nombre);
        form.AddField("correctas", datos.CCorrectas);
        form.AddField("incorrectas", datos.CIncorrectas);
        form.AddField("intentos", datos.CTotales);
        form.AddField("actividad_terminada", "Si");
        form.AddField("descripcion", datos.descripcion);
        form.AddField("usuario", PlayerPrefs.GetString("username"));
       
        UnityWebRequest www = UnityWebRequest.Post("http://govic.cl/serapis/recibir2.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }

    }
    public void Descripcion()
    {
        if (identificador_actividad != "")
        {
            //Cerebro
            if (identificador_actividad == "cerebro")
            {
                GameObject respuesta = GameObject.Find("boton");
                print("que tiene: "+respuesta.GetComponent<EmparejarConTag>().enviarString);
                datos.descripcion= respuesta.GetComponent<EmparejarConTag>().enviarString;
            }
            if (identificador_actividad == "rutinas" || identificador_actividad == "rutinas2" || identificador_actividad == "estado_de_animo" || identificador_actividad == "VAK")
            {

            }
        }
        else
        {
            datos.descripcion = "";
        }
    }
}
