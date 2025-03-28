using System.Collections;
using UnityEngine;

public class EndLight : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        Vector3 newScale = transform.localScale;
        newScale.y = 0;
        transform.localScale = newScale;
    }
    public IEnumerator SkyLight ()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        Vector3 targetScale = transform.localScale;
        targetScale.y = 55;


        while (Vector3.Distance(targetScale,transform.localScale) > 0.1f)
        {
            float newY = Mathf.Lerp(transform.localScale.y, targetScale.y, 1f * Time.deltaTime);
            transform.localScale = new Vector3(targetScale.x, newY, targetScale.y);
            yield return null;
        }
    }
}
