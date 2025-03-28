using UnityEngine;
using UnityEngine.Timeline;

public class Portal : MonoBehaviour
{
    public bool isPlayerOver;
    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player.GetComponent<Collider2D>())
        {
            isPlayerOver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == player.GetComponent<Collider2D>())
        {
            isPlayerOver = false;
        }
    }
}
