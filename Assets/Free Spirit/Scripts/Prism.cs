using UnityEngine;

public class Prism : MonoBehaviour
{
    public bool isActive;

    private void Start()
    {
        if(gameObject.name == "Water prism")
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            isActive = true;
        }
        else if (gameObject.name == "Earth prism")
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            isActive = true;
        }
        else if (gameObject.name == "Fire prism")
        {
            isActive = false;
        }
    }
}
