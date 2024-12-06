using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController _instance;
    public static AudioController Instance { get { return _instance; } }
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        if(_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField] AudioSource _audioChildPrefab;
    [SerializeField] List<AudioClip> _audioClips = new List<AudioClip>();
    List<AudioSource> _audioSources = new List<AudioSource>();

    public void PlaySound(string nameSound)
    {

        AudioClip audioClip = null;
        foreach (AudioClip clip in _audioClips)
        {
            if (clip.name.ToLower().Equals(nameSound.ToLower()))
            {
                audioClip = clip;
                break;
            }
        }
        if (audioClip == null)
        {
            Debug.LogError("sound " + nameSound + " not found");
            return;
        }

        AudioSource sourceSound = null;  // kết hợp ObjectPooling
        foreach (AudioSource source in _audioSources)
        {
            if (source.gameObject.activeSelf) continue;
            sourceSound = source;
        }

        if (sourceSound == null)
        {
            sourceSound = Instantiate<AudioSource>(_audioChildPrefab, this.transform.position, Quaternion.identity, this.transform);
            _audioSources.Add(sourceSound);
        }

        sourceSound.gameObject.SetActive(false);
        sourceSound.clip = audioClip;
        sourceSound.gameObject.SetActive(true);
    }
}
