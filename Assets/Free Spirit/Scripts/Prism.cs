using UnityEngine;

public class Prism : MonoBehaviour
{
    private bool isActive;
    private Color prismColor;

    private GameObject[] waterfalls;

    private GameObject[] dirtWalls;

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


        dirtWalls = GameObject.FindGameObjectsWithTag("Earth Wall");
        HideWalls();
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

    //methodes à metre dans une classe héritée?
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

    public void InitiateWalls ()
    {

        foreach (GameObject dirwall in dirtWalls)
        {
            Debug.Log("j'initie chaque mur");
            dirwall.GetComponent<DirtWall>().InitiateWall();
        }
    }

    public void HideWalls ()
    {
        foreach (GameObject dirtwall in dirtWalls)
        {
            dirtwall.GetComponent<DirtWall>().DeactivateWall();
        }
    }
}
