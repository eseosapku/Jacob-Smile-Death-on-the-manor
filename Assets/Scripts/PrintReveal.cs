using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PrintReveal : MonoBehaviour
{


    private Material printMaterial;
    private float alphaAmount = 0f;
    private bool isClose = false;
    private float printSpeed = 0f;
    private bool printShown = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        printMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
     
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

    }
}
