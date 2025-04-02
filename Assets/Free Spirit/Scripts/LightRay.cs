using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

public class LightRay : MonoBehaviour
{

    private LineRenderer linerenderer;

    private GameObject child;
    private Vector2 direction;
    private Vector2 origin;

    public GameObject end;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
        child.GetComponent<SpriteRenderer>().enabled = false;


        Vector2 aPoint = new Vector2(transform.position.x, transform.position.y);
        Vector2 bPoint = new Vector2(child.transform.position.x, child.transform.position.y);

        direction = (bPoint - aPoint).normalized;

        origin = transform.position;

        linerenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        if (hit.collider != null)
        {
            if (hit.collider == end.GetComponent<PolygonCollider2D>())
            {
                hit.collider.GetComponent<Prism>().ActivatePrism();
            }
            else
            {
                //end.GetComponent<Prism>().DeactivatePrism();
            }

            linerenderer.positionCount = 2;
            linerenderer.SetPosition(0, origin);
            linerenderer.SetPosition(1, hit.point);
            

            GetReflectedValues(hit.collider.CompareTag("Mirror"), hit, direction);
        }
        else
        {
            linerenderer.positionCount = 2;
            linerenderer.SetPosition(0, origin);
            linerenderer.SetPosition(1, direction * 100);
        }
    }

    private void GetReflectedValues(bool checkCollisonMirror, RaycastHit2D hit, Vector2 direction)
    {
        if (checkCollisonMirror)
        {
            Vector2 normalDirection = hit.normal;
            Vector2 newOrigin = hit.point + hit.normal * 0.01f;
            Vector2 newDirection = Vector2.Reflect(direction, normalDirection);

            TraceRay(newOrigin, newDirection);
        }
    }

    private void TraceRay (Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        if (hit.collider != null)
        {
            if (hit.collider == end.GetComponent<PolygonCollider2D>())
            {
                hit.collider.GetComponent<Prism>().ActivatePrism();
            }
            else
            {
                //end.GetComponent<Prism>().DeactivatePrism();
            }

            linerenderer.positionCount++;
            linerenderer.SetPosition(linerenderer.positionCount-1, hit.point);


            GetReflectedValues(hit.collider.CompareTag("Mirror"), hit, direction);
        }
        else
        {
            Debug.DrawRay(origin, direction * 100, Color.red);
            linerenderer.positionCount++;
            linerenderer.SetPosition(linerenderer.positionCount - 1, direction * 100); // erreur quand le laser est dans le vide... le deuxieme point n'est pas le bon
        }
    }
}
