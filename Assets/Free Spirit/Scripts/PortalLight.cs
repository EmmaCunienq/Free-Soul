using UnityEngine;

public class PortalLight : MonoBehaviour
{
    public Color goalColor;

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
    }
}
