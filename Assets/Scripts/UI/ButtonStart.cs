using UnityEngine.SceneManagement;
using UnityEngine;


public class ButtonStart : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
