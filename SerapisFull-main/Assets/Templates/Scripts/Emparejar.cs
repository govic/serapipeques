using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Emparejar : MonoBehaviour
{
    public Transform pareja;
    public UnityEvent onMatch, onTry, onUnmatch;
    public bool moveToMatchPosition;
   
    Vector3 startPosition;

    public Transform go; // por si queremos mover otro objeto en vez de el objeto que tenga el scritp
    public bool objetos3D = false;

    bool emparejado;
    bool onRange;
    //variable para diferenciar
    bool onRangev2;
    public Contador cont;
    public bool sirveCont;


    private void Awake()
    {
        if (go == null)
        {
            go = this.transform;
        }
        startPosition = go.position;
       
    }

    public void SetStartPosition()
    {
        startPosition = go.position;
    }

    public void BuscarPareja()
    {
        if (emparejado)
        {
            if (onRange) return;
            else
            {
                StartCoroutine(Interpolar(startPosition));
                onUnmatch.Invoke();
                emparejado = false;
            }
        }
        if (onRangev2)
        {

            cont.errores();
        }
        if(onRange)
        {
            print("entro2");
            if (moveToMatchPosition) StartCoroutine(Interpolar(pareja.position));
            emparejado = true;
            if (sirveCont == false)
            {
                cont.correcto();
            }
            
            onMatch.Invoke();
            if(disableOnMatch)
            {
                print("entro3");
                Destroy(gameObject.GetComponent<Collider2D>());
                Destroy(go.GetComponent<Collider2D>());

                //para 3ds

                Destroy(go.GetComponent<Collider>());
                Destroy(gameObject.GetComponent<Collider>());
                //gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
        else
        {
            StartCoroutine(Interpolar(startPosition));
           
        }

    }

    IEnumerator Interpolar(Vector3 target)
    {
        Vector3 from = go.position;
        float t = 0;
        float duracion = 0.3f;
        while(t < duracion)
        {
            t += Time.deltaTime;
            float perc = t / duracion;
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
            go.position = Vector3.Lerp(from, target, perc);
            yield return null;
        }

        if (!onRange)
            onTry.Invoke();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == pareja.gameObject)
        {
            print("col1");
            onRange = true;
        }
        else
        {
            print("col2");
           onRangev2=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onRange = false;
        onRangev2 = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == pareja.gameObject)
        {
            print("col2");
            onRange = true;         
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pareja.gameObject)
        {
            onRange = false;
        }
    }
    public bool disableOnMatch;
}
