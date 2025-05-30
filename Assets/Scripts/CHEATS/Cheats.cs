using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    void Update()
    {
        // Cheats para cambiar de nivel (ignora lvlsUnblocked)
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Batalla_1");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            GameManager.Instance.lvlsUnblocked = 1;
            GameManager.Instance.lvlsCompletados = new List<int> { 0 };
            SceneManager.LoadScene("Batalla_2");
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            GameManager.Instance.lvlsCompletados = new List<int> { 0, 1};
            GameManager.Instance.lvlsUnblocked = 2;
            SceneManager.LoadScene("Batalla_3");
        }
        // Cheat para reiniciar nivel
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
