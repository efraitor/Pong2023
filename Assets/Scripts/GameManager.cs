using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Librería para poder acceder a los TextMeshPro
using UnityEngine.UI; //Librería para acceder a los componentes de la UI

public class GameManager : MonoBehaviour
{
    //Referencias a los objetos que queremos que se activen o desactiven
    /*public GameObject ball,;
    public GameObject rackectLeft;*/
    public GameObject ball, racketLeft, racketRight, dottedLine;
    public TextMeshProUGUI leftScore, rightScore, title;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para que el juego empiece al pulsar el botón
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
}
