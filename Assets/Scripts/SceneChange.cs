using UnityEngine;
using UnityEngine.SceneManagement;
using static Timer;
public class SceneChange : MonoBehaviour
{
    public void PlayGame(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
        Timer.elapsedTime = 0;
    }
}
