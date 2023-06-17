using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public float platformHeight;

    private bool isDrawing = false;
    private Vector2 lastPosition;
    private GameObject currentPlatform;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartDrawing(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (isDrawing)
                {
                    ContinueDrawing(touch.position);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                StopDrawing();
            }
        }
    }

    private void StartDrawing(Vector2 position)
    {
        isDrawing = true;
        lastPosition = Camera.main.ScreenToWorldPoint(position);
        currentPlatform = Instantiate(platformPrefab, lastPosition, Quaternion.identity);
        currentPlatform.transform.SetParent(transform);
    }

    private void ContinueDrawing(Vector2 position)
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(position);
        RaycastHit2D hit = Physics2D.Linecast(lastPosition, currentPos);

        if (hit.collider != null && hit.collider.gameObject == currentPlatform)
        {
            ResizePlatform(currentPos);
        }
    }

    private void StopDrawing()
    {
        isDrawing = false;
    }

    private void ResizePlatform(Vector2 currentPos)
    {
        Vector2 platformScale = new Vector2(Vector2.Distance(lastPosition, currentPos), platformHeight);
        currentPlatform.transform.localScale = new Vector3(platformScale.x, currentPlatform.transform.localScale.y, currentPlatform.transform.localScale.z);
        currentPlatform.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(currentPos.y - lastPosition.y, currentPos.x - lastPosition.x) * Mathf.Rad2Deg);
    }
}
