using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 2f;
    [SerializeField] AudioClip crashSound;

    bool HasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !HasCrashed)
        {
            HasCrashed = true;
            crashEffect.Play();
            FindObjectOfType<PlayerController>().DisableControls();
            Invoke(nameof(ReloadScene), loadDelay); 
            GetComponent<AudioSource>().PlayOneShot(crashSound);
        }
    }

       void ReloadScene()
    {
        SceneManager.LoadScene(0); 
    }
}
