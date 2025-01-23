using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
