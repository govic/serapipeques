using UnityEngine;
using UnityEngine.Events;
public class ManagerActividad : MonoBehaviour
{
    public UnityEvent onCompletarActividad;

    public int cantidadDeRespuestas;
    public int respuestasAsignadas = 0;
    public bool agregarEstrella = true;
    public void AgregarRespuestaCorrecta()
    {
        respuestasAsignadas++;
        print("respuesta correcta agregada");

        if (respuestasAsignadas == cantidadDeRespuestas)
        {
            print("Completo Actividad");
            //Tendré que comentar la siguiente linea, porque quiero que el video salga luego del puntaje y que se presione un botón
            onCompletarActividad.Invoke();
            if (agregarEstrella)
            {
                ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] = true;
                ManagerEscenas.Instance.AddStar();
            }   
        }

    }


    public void QuitarRespuesta()
    {
        respuestasAsignadas--;
    }

}
