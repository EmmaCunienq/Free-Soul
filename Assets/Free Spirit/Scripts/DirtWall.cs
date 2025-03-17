using UnityEditor.Rendering;
using UnityEngine;

public class DirtWall : MonoBehaviour
{

    public bool isActive;

    public void ActivateWall ()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        isActive = true;
    }

    public void DeactivateWall ()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        isActive = false;
    }

    public void SwitchActivation ()
    {
        if (isActive)
        {
            DeactivateWall();
        }
        else
        {
            ActivateWall();
        }
    }
}
