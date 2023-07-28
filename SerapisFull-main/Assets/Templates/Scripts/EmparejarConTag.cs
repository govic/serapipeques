using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EmparejarConTag : MonoBehaviour
{
    public string tagPareja;
    Transform pareja;
    public UnityEvent onMatch, onTry;
    public bool moveToMatchPosition;
   
    Vector3 startPosition;

    bool emparejado;
    bool onRange;
    //variable para diferenciar
    bool onRangev2;
    //contadores
    public Contador cont;
    public bool sirveCont;
    public string enviarString;

    private void Awake()
    {
        startPosition = transform.position;
    }



    public void BuscarPareja()
    {
        if (emparejado) return;

        //chequear si el objeto se movio o si solo fue un click
        

        if (onRangev2 == true)
        {
            if (sirveCont==false)
            {
                cont.errores();
            }
           
        }

        if (onRange)
        {

            
            if (moveToMatchPosition) StartCoroutine(Interpolar(pareja.position));
            if (sirveCont == false)
            {
                cont.correcto();
            }
                
            emparejado = true;
            if (disableOnMatch)
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
            onMatch.Invoke();

            if (pareja.GetComponent<EventOnOther>())
            {
                pareja.GetComponent<EventOnOther>().evento.Invoke();
            }
           
        }
        else
        {
            StartCoroutine(Interpolar(startPosition));
        }
        
        

    }

    IEnumerator Interpolar(Vector3 target)
    {       
        if (Vector3.Distance(startPosition, transform.position)> 0.5f)
        {
            if (!onRange) {
                onTry.Invoke();

            }

        }


        Vector3 from = transform.position;
        float t = 0;
        float duracion = 0.3f;
        while(t < duracion)
        {
            t += Time.deltaTime;
            float perc = t / duracion;
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
            transform.position = Vector3.Lerp(from, target, perc);
            yield return null;
        }

 
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag(tagPareja))
        {
            pareja = collision.transform;
            onRange = true;
            enviarString = collision.name ;

            
        }
        else
        {
            onRangev2 = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onRange = false;
        onRangev2 = false;
    }

    public bool disableOnMatch;

}
