using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

public class Portal : MonoBehaviour
{
    public bool portalActivation;

    public bool isPlayerOver;
    private GameObject player;

    private PortalLight[] portalLights;

    private EndLight skyLight;

    void Start()
    {
        portalActivation = false;

        player = GameObject.FindGameObjectWithTag("Player");

        portalLights = FindObjectsByType<PortalLight>(FindObjectsSortMode.None);

        skyLight = FindFirstObjectByType<EndLight>();
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

    public void CheckActivation ()
    {
        if (portalLights.All(portal => portal.isActive))
        {
            portalActivation = true;

            StartCoroutine(skyLight.SkyLight());
        }
    }

}
