using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Linq;

public class CalcularRespuesta : MonoBehaviour
{
    public string[] url;
    public VideoClip[] videos;
    public VideoPlayer videoPlayer;
    int[] respuestas = new int[3];
    public string tipoVAK;

    //0 = auditivo  , 1 = visual , 2 = kinestesico;

    
    public void AgregarRespuesta(int index)
    {
        respuestas[index]++;
    }

    public void Calcular()
    {
        int maxValue = respuestas.Max();
        int index = respuestas.ToList().IndexOf(maxValue);

        //videoPlayer.url = url[index];
        videoPlayer.clip = videos[index];
        videoPlayer.gameObject.SetActive(true);
        if (index == 0)
        {
            tipoVAK = "El estilo de aprendizaje es auditivo";
        }
        if (index == 1)
        {
            tipoVAK = "El estilo de aprendizaje es visual";
        }
        if (index == 2)
        {
            tipoVAK = "El estilo de aprendizaje es kinestésico";
        }
    }
}
