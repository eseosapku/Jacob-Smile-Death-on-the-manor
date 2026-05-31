using UnityEngine;

public class UvControl : MonoBehaviour
{
    private Camera playerCamera;
    private bool isDragging = false;
    private float dragDistance = 1.3f;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (!PuzzleSequence.gameStarted) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    Debug.Log("UV Stick selected - drag to move");
                }
            }
        }
        if (isDragging)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.origin + ray.direction * dragDistance;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                isDragging = false;
                Debug.Log("UV Stick released");
            }
        }
    }
}