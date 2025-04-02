using UnityEngine;

public class SwitchDirtWall : MonoBehaviour
{
    private Animator animator;

    private bool isPlayerOver;

    public GameObject[] dirtWalls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        GetAllChildren(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOver & Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("PlayedOnce");
            SwitchDirtWalls();
            Debug.Log("j'active " + gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOver = collision.CompareTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOver = collision.CompareTag("Player");
    }

    private void GetAllChildren ()
    {
        dirtWalls = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            dirtWalls[i] = transform.GetChild(i).gameObject;
        }
    }

    private void SwitchDirtWalls ()
    {
        foreach (GameObject dirtwall in dirtWalls)
        {
            dirtwall.GetComponent<DirtWall>().isActive = !dirtwall.GetComponent<DirtWall>().isActive;
            dirtwall.GetComponent<DirtWall>().SwitchActivation();
        }
    }
}
