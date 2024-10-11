
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    public Text score;
    private float distance;
    private float highRecord;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text record;
    [SerializeField] private GameObject loseScreen;
    
    


    void Start()
    {
        distance = 0;
        Time.timeScale = 1;

    }

    
    void Update()
    {
        score.text = distance.ToString("F0");
        distance += Time.deltaTime * 10f;
        highRecord = distance;

        if (!Player.playerAlive)
        {
            record.text = "Ваш рекорд: " + PlayerPrefs.GetFloat("Record").ToString("F0");
            scoreText.text = "Вы набрали: " + distance.ToString("F0");
            loseScreen.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("Record")<= highRecord)
        {
            PlayerPrefs.SetFloat("Record", highRecord);
        }

        ChangeSpeedLevel();
        


    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        PlatformController.speed = 3f;
        NewSpawnerScriptFromDino.spawnInterval = 2f;
        
    }

   
   

    private void ChangeSpeedLevel()
    {
        if (score.text == "100")
        {
            PlatformController.speed = 4f;
            NewSpawnerScriptFromDino.spawnInterval = 1.9f;
            
        }
        if (score.text == "200")
        {
            PlatformController.speed = 5f;
            NewSpawnerScriptFromDino.spawnInterval = 1.8f;
        }
        if (score.text == "300")
        {
            PlatformController.speed = 5.5f;
            NewSpawnerScriptFromDino.spawnInterval = 1.7f;
        }

        if (score.text == "400")
        {
            PlatformController.speed = 6f;
            NewSpawnerScriptFromDino.spawnInterval = 1.6f;
        }

        if (score.text == "500")
        {
            PlatformController.speed = 7f;
            NewSpawnerScriptFromDino.spawnInterval = 1.5f;
        }

        if (score.text == "600")
        {
            PlatformController.speed = 8f;
            NewSpawnerScriptFromDino.spawnInterval = 1.4f;
        }
        if (score.text == "700")
        {
            PlatformController.speed = 9f;
            NewSpawnerScriptFromDino.spawnInterval = 1.1f;
        }
        if (score.text == "800")
        {
            PlatformController.speed = 10f;
            NewSpawnerScriptFromDino.spawnInterval = 0.8f;
            
        }

    }
}
