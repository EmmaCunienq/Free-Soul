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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        isFollowing = true;

        animator = GetComponent<Animator>();
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFollowing = true;
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
