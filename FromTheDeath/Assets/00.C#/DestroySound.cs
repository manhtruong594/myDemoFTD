using System.Collections;
using UnityEngine;

public class DestroySound : MonoBehaviour
{
    [SerializeField]
    AudioSource _Audio = null;
    public AudioSource Audio => _Audio;
    // Start is called before the first frame update
    void Awake()
    {
        _Audio = this.GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        StartCoroutine(WaitDone());
    }


    IEnumerator WaitDone()
    {
        yield return new WaitUntil(() => !_Audio.isPlaying);
        this.gameObject.SetActive(false);
    }
}
