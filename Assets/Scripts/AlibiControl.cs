using UnityEngine;
using UnityEngine.UI;

public class AlibiControl : MonoBehaviour
{
    public Button[] alibiButtons;
    public GameObject[] suspects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < alibiButtons.Length; i++)
        {
            int index = i;
            alibiButtons[i].onClick.AddListener(() => PlayAlibi(index));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAlibi(int index)
    {
        foreach (GameObject suspect in suspects)
        {
            AudioSource source = suspect.GetComponent<AudioSource>();
            if (source != null) source.Stop();
        }
        AudioSource selectedAudio = suspects[index].GetComponent<AudioSource>();
        if (selectedAudio != null) selectedAudio.Play();
    }
}
