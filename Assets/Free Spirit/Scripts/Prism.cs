using UnityEngine;

public class Prism : MonoBehaviour
{
    private bool isActive;
    private Color prismColor;

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

        if (isActive)
        {
            GetComponent<SpriteRenderer>().color = prismColor;
        }
    }

    public void ActivatePrism ()
    {
        isActive = true;
        if (isActive)
        {
            GetComponent<SpriteRenderer>().color = prismColor;
        }
    }
}
