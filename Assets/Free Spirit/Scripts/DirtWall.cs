using UnityEditor.Rendering;
using UnityEngine;

public class DirtWall : MonoBehaviour
{

    public bool isActive;

    private void Start()
    {
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
