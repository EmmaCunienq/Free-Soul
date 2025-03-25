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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        isFollowing = true;

        animator = GetComponent<Animator>();

        prisms = GameObject.FindGameObjectsWithTag("Prism");
        goingToPrism = false;
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
                Debug.Log("je suis proche de : " + prism.name);
                
                StartCoroutine(GoToPrism(prism));
                
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

        return ((transform.position.x < player.transform.position.x + playerDistance && transform.position.x > player.transform.position.x - playerDistance) && (transform.position.y < player.transform.position.y + playerDistance && transform.position.y > player.transform.position.y - playerDistance));
    }


    IEnumerator GoToPrism (GameObject prism)
    {
        goingToPrism = true;

        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(prism.transform.position.x, prism.transform.position.y, prism.transform.position.z);
        while (Vector3.Distance(transform.position,targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, soulSpeed * Time.deltaTime);
            yield return null;
        }

        GetComponent<SpriteRenderer>().color = prism.GetComponent<SpriteRenderer>().color;

        isFollowing = true;
        goingToPrism = false;
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
