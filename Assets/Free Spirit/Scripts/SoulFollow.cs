using System.Collections;
using TMPro;
using UnityEngine;

public class SoulFollow : MonoBehaviour
{
    private GameObject player;

    public float soulSpeed;
    public float playerDistance;
    private bool isFollowing;
 
    //Animations Parameters
    private Animator animator;
    public float facing = 0;

    public GameObject[] prisms;
    public bool goingToPrism;

    public Portal portal;
    public PortalLight[] portalLights;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        isFollowing = true;

        animator = GetComponent<Animator>();

        prisms = GameObject.FindGameObjectsWithTag("Prism");
        goingToPrism = false;

        portal = FindFirstObjectByType<Portal>();
        portalLights = FindObjectsByType<PortalLight>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            if (!isClose())
            {
                Following();
            }
            else
            {
                facing = 0;
            }
        }
        else
        {
            facing = 0;
        }

        UpdateAnimationsParameters();

        
        foreach (GameObject prism in prisms)
        {
            if (player.GetComponent<PlayerDeplacements>().isClosePrism(prism) && Input.GetKeyDown(KeyCode.E))
            {
                isFollowing = false;

                goingToPrism = true;

                StartCoroutine(GoTo(prism));
            }
        }

        if (portal.isPlayerOver && Input.GetKeyDown(KeyCode.E))
        {
            foreach (PortalLight portalLight in portalLights)
            {
                if (portalLight.CheckSoulColor(gameObject))
                {
                    isFollowing = false;

                    StartCoroutine(GoTo(portalLight.gameObject));
                }
            }
        }
    }

    void Following ()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);


        //Configuring facing for soul's animation
        if (currentPosition.x - targetPosition.x > 0)
        {
            facing = -1;
        }
        else if (currentPosition.x - targetPosition.x < 0)
        {
            facing = 1;
        }
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, soulSpeed * Time.deltaTime);
    }

    bool isClose ()
    {
        return Vector2.Distance(transform.position, player.transform.position) < playerDistance;
        //return ((transform.position.x < player.transform.position.x + playerDistance && transform.position.x > player.transform.position.x - playerDistance) && (transform.position.y < player.transform.position.y + playerDistance && transform.position.y > player.transform.position.y - playerDistance));
    }


    IEnumerator GoTo (GameObject destination)
    {
        Vector3 targetPosition = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);

        while (Vector3.Distance(transform.position,targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, soulSpeed * Time.deltaTime);
            yield return null;
        }

        if (destination.tag == "Prism")
        {
            GetComponent<SpriteRenderer>().color = destination.GetComponent<SpriteRenderer>().color;

            if (destination.name == "Water prism")
            {
                destination.GetComponent<Prism>().ActivateWaterfalls();
            }
            else
            {
                destination.GetComponent<Prism>().DeactivateWaterfalls();
            }

                isFollowing = true;
            goingToPrism = false;
        }
        else if (destination.tag == "Portal Light")
        {
            destination.GetComponent<PortalLight>().ActiveLight();

            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            isFollowing = true;

            portal.CheckActivation();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!goingToPrism)
            {
                isFollowing = true;
            }
        }

        if( collision.gameObject.CompareTag("Waterfall"))
        {
            isFollowing = false;
        }
    }


    //Animations
    void UpdateAnimationsParameters()
    {
        animator.SetFloat("Facing", facing);
    }
}
