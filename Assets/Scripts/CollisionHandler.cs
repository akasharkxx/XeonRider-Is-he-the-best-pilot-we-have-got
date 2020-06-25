using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("in seconds")][SerializeField]
    private float LoadTime = 2f;
    [Tooltip("FX prefab in Player GameObject")][SerializeField]
    private GameObject explosionGameObject;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        explosionGameObject.SetActive(true);
        Invoke("ReloadLevel", LoadTime);
    }

    private void ReloadLevel() //String referenced
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
