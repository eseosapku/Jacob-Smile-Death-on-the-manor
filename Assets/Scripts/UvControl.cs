using UnityEngine;
using UnityEngine.Audio;

public class UvControl : MonoBehaviour
{
    private float lifeTimer = 0f;
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
            isDragging = false;
        }
    }
}