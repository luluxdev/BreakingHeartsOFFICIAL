using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class TurnoEnemigo : MonoBehaviour
{
    public VidaJugador VidaJugador;
    public ChangeMenu ChangeMenu;
    public int dano_r; 
    public int dano;
    public bool ataco = false;
    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        dano_r = Random.Range(232, 680);

        if (dano_r % 4 == 0)
        {
            dano = 2;
        }
        else if(dano_r % 9 == 0)
        {
            dano = 3;
        }
        else { dano = 1;}

        if (ChangeMenu.menuEnemy.activeSelf) {
            if (!ataco)
            {
                Debug.Log("enemigo ataca");
                Debug.Log(dano_r);
                VidaJugador.TomarDa�o(dano);
                ataco = true;
            }
        }
        
        if (ChangeMenu.menuGameplay.activeSelf)
        {
            ataco = false;
        }
    }
}
