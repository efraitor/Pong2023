using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Velocidad de la pelota
    public float speed = 25;

    // Start is called before the first frame update
    void Start()
    {
        //La bola se mueve a la izquierda
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;// Vector2.left = new Vector2(-1, 0)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    * El objeto collision del par�ntesis contiene la informaci�n del choque (es el objeto que ha chocado con el que lleva el c�digo)
    * En particular, nos interesa saber cuando choca con una pala.
    * - collision.gameObject: tiene informaci�n del objeto contra el cu�l he colisionado
    * - collision.transform.position: tiene informaci�n de la posici�n de ese objeto
    * - collision.collider: tiene informaci�n del collider del objeto
    */
    /*Este m�todo es de Unity y detecta la colisi�n entre dos GO.
    * Al chocar el objeto contra el que choca, le pasa su colisi�n por par�metro */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si la pelota ha colisionado con la pala izquierda
        if (collision.gameObject.name == "RacketLeft")
        {
            //Obtenemos el factor de golpeo, pas�ndole la posici�n de la pelota, la posici�n de la pala, y lo que mide de alto el collider de la pala(es decir, lo que mide la pala)
            float yF = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            /* Le damos una nueva direcci�n a la pala
            * En este caso con una X a la derecha
            * Y nuestro factor de golpeo calculado
            * Normalizado todo el vector a 1, para que la bola no acelere */
            Vector2 direction = new Vector2(1, yF).normalized;
            //Le decimos a la bola que salga con esa velocidad previamente calculada
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    /*
    * 1 - La bola choca contra la parte superior de la raqueta
    * 0 - La bola choca contra el centro de la raqueta
    * -1 - La bola choca contra la parte inferior de la raqueta
    */
    /* Es un m�todo de tipo 3. En este caso le pasamos 3 par�metros:
    * - posici�n actual de la pelota
    * - posici�n actual de la pala
    * - altura de la pala
    * Y el m�todo tal y como le indicamos nos devuelve una variable de tipo float */
    private float HitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}
