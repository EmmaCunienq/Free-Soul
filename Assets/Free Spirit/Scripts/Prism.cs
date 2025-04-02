using UnityEngine;

public class Prism : MonoBehaviour
{
    private bool isActive;
    private Color prismColor;

    private GameObject[] waterfalls;

    private void Start()
    {
        if(gameObject.name == "Water prism")
        {
            prismColor = Color.blue;
            isActive = true;
        }
        else if (gameObject.name == "Earth prism")
        {
            prismColor = Color.green;
            isActive = true;
        }
        else if (gameObject.name == "Fire prism")
        {
            prismColor = Color.red;
            isActive = false;
        }
        else
        {
            Debug.Log("Le nom du prism : " + gameObject.name + " n'est pas le bon");
        }

        if (isActive)
        {
            GetComponent<SpriteRenderer>().color = prismColor;
        }

        waterfalls = GameObject.FindGameObjectsWithTag("Waterfall");
    }

    public void ActivatePrism ()
    {
        isActive = true;

        GetComponent<SpriteRenderer>().color = prismColor;
    }

    public void DeactivatePrism ()
    {
        isActive = false;

        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void ActivateWaterfalls ()
    {
        foreach (GameObject waterfall in waterfalls)
        {
            waterfall.GetComponent<Waterfall>().Activate();
        }
    }

    public void DeactivateWaterfalls ()
    {
        foreach (GameObject waterfall in waterfalls)
        {
            waterfall.GetComponent<Waterfall>().Deactivate();
        }
    }
}
