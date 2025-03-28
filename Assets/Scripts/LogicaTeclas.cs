using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaTeclas : MonoBehaviour
{

    public float speed;
    public int counter = 0;
    public bool inside = false;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        vertical = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, vertical).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //verificar si la tecla esta dentro
        if (counter == 2)
        {
            inside = true;
        }
        else
        {
            inside = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (inside == true)
            {
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score++;
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();

                Destroy(gameObject);
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (inside == true)
            {
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score++;
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();

                Destroy(gameObject);
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (inside == true)
            {
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score++;
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();

                Destroy(gameObject);
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (inside == true)
            {
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score++;
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();

                Destroy(gameObject);
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            counter++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            counter--;
        }
    }
}
