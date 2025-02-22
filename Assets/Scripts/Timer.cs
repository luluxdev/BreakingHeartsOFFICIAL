using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timer = 0f;
    public GameObject enemy;
    public float timeEnemy = 1.5f;
    public float timeStop = 10f;
    public float timeMenu = 12.5f;

    public GameObject generador;
    public GameObject menuGameplay;
    public EventSystem eventSystem;
    public ChangeMenu ChangeMenu;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeMenu.menuGameplay.activeSelf)
        {
            if (timer >= timeStop)
            {
                generador.SetActive(false);
            }
            if (timer >= timeMenu)
            {
                timer = 0f;
                ChangeMenu.EnemyTurn();
                generador.SetActive(true);
            }
            timer += Time.deltaTime;
        }
        if (ChangeMenu.menuEnemy.activeSelf)
        {
            if (timer >= timeEnemy)
            {
                timer = 0f;
                ChangeMenu.AbrirMenuInicial();
            }
            timer += Time.deltaTime;
        }
    }
}
