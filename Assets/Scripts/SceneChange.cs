using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void PlayGame(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}
