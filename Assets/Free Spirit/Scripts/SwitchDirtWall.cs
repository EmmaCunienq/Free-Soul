using UnityEngine;

public class SwitchDirtWall : MonoBehaviour
{
    private Animator animator;

    private bool isPlayerOver;

    public Color color;
    private GameObject child;

    public GameObject[] dirtWalls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        GetAllDirtWalls();

        child = transform.GetChild(0).gameObject;
        child.GetComponent<SpriteRenderer>().color = color;

        foreach (GameObject dirtWall in dirtWalls)
        {
            dirtWall.GetComponent<DirtWall>().SetColor(color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOver & Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("PlayedOnce");
            SwitchDirtWalls();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOver = collision.CompareTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOver = !collision.CompareTag("Player");
    }

    private void GetAllDirtWalls ()
    {
        dirtWalls = new GameObject[transform.childCount - 1];
        int k = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Earth Wall"))
            {
                dirtWalls[k] = transform.GetChild(i).gameObject;
                k++;
            }  
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
