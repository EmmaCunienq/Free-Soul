using UnityEngine;

public class PortalLight : MonoBehaviour
{
    private Color goalColor;
    private bool isActive;

    private void Start()
    {
        if(gameObject.name == "Red light")
        {
            goalColor = Color.red;
        }
        else if (gameObject.name == "Green Light")
        {
            goalColor = Color.green;
        }
        else if (gameObject.name == "Blue Light")
        {
            goalColor = Color.blue;
        }
        else
        {
            Debug.Log("Cette lumière : " + gameObject + " n'est pas bien nommée !");
        }

        isActive = false;
    }

    public bool CheckSoulColor (GameObject soul)
    {
        return goalColor == soul.GetComponent<SpriteRenderer>().color;
    }

    public void ActiveLight ()
    {
        GetComponent<SpriteRenderer>().color = goalColor;
        isActive = true;
    }
}
