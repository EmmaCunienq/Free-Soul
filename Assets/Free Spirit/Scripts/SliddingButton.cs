using UnityEngine;

public class SliddingButton : MonoBehaviour
{
    public GameObject guide;
    public float minX;
    public float maxX;

    private void Start()
    {
        guide = transform.parent.gameObject;
        float guideSize = guide.transform.localScale.x;
        minX = transform.position.x - guideSize / 2;
        maxX = transform.position.x + guideSize / 2;
    }

    private void FixedUpdate()
    {
        float currentXPos = transform.position.x;
        float xPos = Mathf.Clamp(currentXPos, minX, maxX);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
