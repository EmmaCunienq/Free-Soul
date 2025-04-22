using UnityEngine;

public class SwitchWaterfall : MonoBehaviour
{
    public bool activated;

    private bool isPlayerOver;

    private GameObject waterfall;
    private Collider2D waterfallCollider;
    private Renderer waterfallRenderer;

    //Animation
    private Animator animator;


    void Start()
    {
        activated = false;

        waterfall = transform.parent.gameObject;
        waterfallCollider = waterfall.GetComponent<Collider2D>();
        waterfallRenderer = waterfall.GetComponent<Renderer>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOver && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("PlayedOnce");
            ChangeWaterfallState();
        }
        if (activated)
        {
            
        }
        



    }

    void ChangeWaterfallState ()
    {
        waterfallCollider.enabled = !waterfallCollider.enabled;
        waterfallRenderer.enabled = !waterfallRenderer.enabled;
        activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOver = collision.CompareTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOver = !collision.CompareTag("Player");
    }

    


}
