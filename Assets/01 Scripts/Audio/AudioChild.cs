using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChild : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        StartCoroutine(waitSoundDone());
    }
    IEnumerator waitSoundDone()
    {
        yield return new WaitUntil(() => !_audioSource.isPlaying);
        this.gameObject.SetActive(false);
    }
}
