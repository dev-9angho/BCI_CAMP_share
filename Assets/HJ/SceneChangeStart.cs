using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneChanger : MonoBehaviour
{
    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
}