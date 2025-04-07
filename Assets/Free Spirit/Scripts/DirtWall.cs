using UnityEditor.Rendering;
using UnityEngine;

public class DirtWall : MonoBehaviour
{
    public bool firstActive;
    public bool isActive;

    private GameObject child;

    private void Start()
    {
        SwitchActivation();

        child = transform.GetChild(0).gameObject;
    }

    public void SetColor (Color color)
    {
        child.GetComponent<SpriteRenderer>().color = color;
    }

    public void InitiateWall ()
    {
        isActive = firstActive;
        SwitchActivation();
    }

    public void ActivateWall ()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    public void DeactivateWall ()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void SwitchActivation ()
    {
        if (isActive)
        {
            ActivateWall();
        }
        else
        {
            DeactivateWall();
        }
    }
}
