using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFinish : MonoBehaviour
{
    public void ChangeToGameScene()
    {
        
        SceneManager.LoadScene("SampleScene"); 
    }

    public void ChangeToStartScene()
    {
        SceneManager.LoadScene("Start");
    }
}