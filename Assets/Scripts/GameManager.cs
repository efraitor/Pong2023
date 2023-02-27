using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Librer�a para poder acceder a los TextMeshPro
using UnityEngine.UI; //Librer�a para acceder a los componentes de la UI

public class GameManager : MonoBehaviour
{
    //Referencias a los objetos que queremos que se activen o desactiven
    /*public GameObject ball,;
    public GameObject rackectLeft;*/
    public GameObject ball, racketLeft, racketRight, dottedLine;
    public TextMeshProUGUI leftScore, rightScore, title;
    public Button startButton;

    //Referencia para guardar la direcci�n de la pelota
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo para que el juego empiece al pulsar el bot�n
    public void StartButton()
    {
        //Al inicio del juego activamos y desactivamos los objetos que queremos
        title.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        dottedLine.gameObject.SetActive(true);
        racketLeft.gameObject.SetActive(true);
        racketRight.gameObject.SetActive(true);
        ball.gameObject.SetActive(true);
        leftScore.gameObject.SetActive(true);
        rightScore.gameObject.SetActive(true);
    }

    //M�todo para hacer lo que ocurre al marcar un punto
    public void GoalScored()
    {
        //Ponemos la pelota al marcar un gol en la posici�n de origen
        ball.transform.position = Vector2.zero; //Vector2.zero <-> new Vector2(0,0)

        //Aqu� guardamos la velocidad en X que llevaba la pelota e invertimos su signo
        direction = new Vector2(-ball.GetComponent<Rigidbody2D>().velocity.x, 0);

        //Paramos la pelota
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    
        //Usando Invoke esperamos X segundos antes de llamar a un M�todo
        Invoke("LaunchBall", 2.0f);
    }

    //M�todo para hacer que la bola se lance
    void LaunchBall()
    {
        //Aplicamos esa nueva direcci�n a la bola
        ball.GetComponent<Rigidbody2D>().velocity = direction;
    }
}
