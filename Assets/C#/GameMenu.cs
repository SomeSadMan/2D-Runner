using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
 
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
}
