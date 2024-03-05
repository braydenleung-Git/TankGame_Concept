using UnityEngine;

public class Bound_Handlling : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    [SerializeField] GameObject tankObject;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, Camera.main.transform.position.z));
        objectWidth = tankObject.transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        objectHeight = tankObject.transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x+objectWidth, (screenBounds.x*-1)-objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y,screenBounds.y+objectHeight,(screenBounds.y*-1)-objectHeight);
    }
}
