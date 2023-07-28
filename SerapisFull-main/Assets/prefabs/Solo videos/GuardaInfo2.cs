using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GuardaInfo2 : MonoBehaviour
{
    public string identificador_actividad = "";
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
    public void GuardarInfo()
    {
        StartCoroutine(corrutinaGuardar2());
        print("Se está enviando");
    }

    private IEnumerator corrutinaGuardar2()
    {
        Descripcion();
        datos.CCorrectas = 0;
        datos.CIncorrectas = 0;
        datos.CTotales = 0;
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

        }
        else
        {
            datos.descripcion = "";
        }
    }
}
