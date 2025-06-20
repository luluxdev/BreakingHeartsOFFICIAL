using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeTextByCharacter : MonoBehaviour
{
    //asigna el texto donde estara el dialogo
    public TMP_Text nameLabel;
    public TMP_Text textLabel;
    public Animator anim;
    public GameObject feedback;
    public int indexCinematica = 1;
    public float waitCinematica = 5f;

    //hace una area en el inspector que puede alargarse hasta 3 sin scroll
    //(max de lineas que puede mostrar sin que se salga del rectangulo)
    public string[] name;
    [TextArea(1, 3)]
    public string[] dialogue;
    //velocidad en la que va el texto al escribirse
    public float textSpeed;

    //index del dialogo que se va a mostrar dentro de la string de dialoue[]
    //y para saber si la coroutina esta en funcionamiento
    private int index;
    private Coroutine _isTyping;

    void Start()
    {
        feedback.SetActive(false);
        nameLabel.text = string.Empty;
        textLabel.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (index == 1)
        {
            anim.SetBool("2nd", true);
        }
        if (index == 2)
        {
            anim.SetBool("3rd", true);
        }

        //si apretamos el click derecho del raton
        if (Input.GetMouseButtonDown(0))
        {
            //si se estaba haciendo una coroutina esta se para y se muestra todo el dialogo
            if (_isTyping != null)
            {
                feedback.SetActive(true);
                StopCoroutine(_isTyping);
                textLabel.maxVisibleCharacters = textLabel.textInfo.characterCount;
                _isTyping = null;
            }
            //si no, muestra el siguiente dialogo en el index
            else
            {
                NextDialogue();
            }
        }
    }

    //funcion que hace empezar de 0 el dialogo
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(ShowDialogueCoroutine());
    }

    //funcion que hace que todas las letras del dialogo se vuelvan invisibles
    IEnumerator ShowDialogueCoroutine()
    {
        if (index == indexCinematica) {
            feedback.SetActive (false);
            yield return new WaitForSeconds(waitCinematica);
        }

        nameLabel.text = name[index];
        textLabel.text = dialogue[index];
        textLabel.maxVisibleCharacters = 0;
        _isTyping = StartCoroutine(RevealCharacters());
    }

    //coroutina que hace visibles las letras una por una
    IEnumerator RevealCharacters()
    {
        feedback.SetActive(false);
        //se actualiza el texto y se cuentan cuantas letras hay en el texto para meterlas en una variable
        textLabel.ForceMeshUpdate();
        int totalCharacters = textLabel.textInfo.characterCount;

        // variable que sirve de index para mostrar letra por letra hasta llegar al maximo a la velocidad del textSpeed
        int visibleCount = 0;
        while (visibleCount <= totalCharacters)
        {
            textLabel.maxVisibleCharacters = visibleCount;
            visibleCount++;
            yield return new WaitForSeconds(textSpeed);
        }

        _isTyping = null;
        feedback.SetActive(true);
    }
    
    //actualiza el index, si hay mas dialogo que mostrar, se suma el index y se muestra dicho nuevo dialogo,
    //si no, se destruye el objeto
    void NextDialogue()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            StartCoroutine(ShowDialogueCoroutine());
        }
        else
        {
            textLabel.text = string.Empty;
            if (SceneManager.GetActiveScene().name == "SelectorDeNiveles")
            {
                Destroy(gameObject);
            }
            if (SceneManager.GetActiveScene().name == "End")
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
    }
}