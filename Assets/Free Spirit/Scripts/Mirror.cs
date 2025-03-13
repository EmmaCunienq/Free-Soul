using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Color color;
    public GameObject slideButton;

    public float baseRotation;

    void Start()
    {
        baseRotation =  transform.eulerAngles.z - 45;

        color = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("SlideButton");

        foreach (GameObject button in buttons)
        {
            SpriteRenderer childSprite = button.transform.GetChild(0).GetComponent<SpriteRenderer>();
            Color slideColor = childSprite.color;
             if (color == slideColor)
            {
                slideButton = button;
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        ChangeMirrorRotation(slideButton.transform.GetChild(0).GetComponent<SlidingButton>().GetRotationPercentage());
    }

    public void ChangeMirrorRotation(float _rotationPercentage)
    {
        float currentRotation = transform.rotation.z;
        transform.rotation = Quaternion.Euler(0, 0, baseRotation + 90 * _rotationPercentage / 100);
    }
}
