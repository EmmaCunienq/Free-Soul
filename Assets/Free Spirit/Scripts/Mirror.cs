using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Color color;
    public GameObject slideButton;

    void Start()
    {
        color = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("SlideButton");

        foreach (GameObject button in buttons)
        {
            Debug.Log(button);
            SpriteRenderer childSprite = button.transform.GetChild(0).GetComponent<SpriteRenderer>();
            Debug.Log(childSprite);
            Color slideColor = childSprite.color;
            Debug.Log("slide :" + button.name + " color : " + slideColor + " vs mirrorcolor : " + color);
             if (color == slideColor)
            {
                Debug.Log("here i am");
                slideButton = button;
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
