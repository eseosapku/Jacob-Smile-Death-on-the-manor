using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Rendering;

public class PrintReveal : MonoBehaviour
{
    private Transform playerLocation;
    public AudioSource audiosource;
    private Material printMaterial;
    private float alphaAmount = 0f;
    private bool isClose = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        printMaterial = GetComponent<Renderer>().material;
        playerLocation = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
     float distance = Vector3.Distance(transform.position, playerLocation.position);
     float speed = Mathf.Lerp(0.75f, 2f, 1 - distance / 10);
     audiosource.pitch = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("UV stick"))
        {
            isClose = true;
            StartCoroutine(FadePrints());
        }
    }

    IEnumerator FadePrints()  
    {
        float fadeTime = 2f;
        float elapseTime = 0f;

        while(elapseTime < fadeTime)
        {
            elapseTime += Time.deltaTime;
            float alphaAmount = elapseTime / fadeTime;

            Color tempColor = printMaterial.color;
            tempColor.a = alphaAmount;
            printMaterial.color = tempColor;
            
            yield return null;
        }
        if (PuzzleTracker.Instance != null)
        {
            PuzzleTracker.Instance.CompletePuzzle();
        }
    }
}
