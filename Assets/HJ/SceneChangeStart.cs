using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneChangeStart : MonoBehaviour
{
    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
}