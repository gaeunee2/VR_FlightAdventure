using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is looking good!");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartSuccessSequence()
    {
        audioSource.PlayOneShot(success);
        GetComponent<Movements>().enabled = false;
        Invoke("NextLevel", levelLoadDelay);
    }
    void StartCrashSequence()
    {
        audioSource.PlayOneShot(crash);
        GetComponent<Movements>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }
    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}