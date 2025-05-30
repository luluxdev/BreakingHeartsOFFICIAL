using UnityEngine;

public class SpriteChangeLvls : MonoBehaviour
{
    private SpriteRenderer spritePlayer;
    public Sprite spriteBloqueado;
    public Sprite spriteDesbloqueado;
    public Sprite spriteJugado;
    public int lvlDeDesbloqueo;

    // Start is called before the first frame update
    void Start()
    {
        spritePlayer = GetComponent<SpriteRenderer>();
        spritePlayer.sprite = spriteBloqueado;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.lvlsUnblocked < lvlDeDesbloqueo)
        {
            spritePlayer.sprite = spriteBloqueado;
        }
        if (GameManager.Instance.lvlsUnblocked == lvlDeDesbloqueo) {
            spritePlayer.sprite = spriteDesbloqueado;
        }
        if (GameManager.Instance.lvlsUnblocked > lvlDeDesbloqueo)
        {
            spritePlayer.sprite = spriteJugado;
        }
    }
}