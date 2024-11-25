
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    public Text score;
    private float distance;
    private float highRecord;
    private float checkPoint;
    [SerializeField] private PlatformController[] platforms;
    [SerializeField] private NewSpawnerScriptFromDino spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text record;
    [SerializeField] private GameObject loseScreen;
    
    void Start()
    {
        Time.timeScale = 1;
    }
    
    void Update()
    {
        ChangeSpeedLevel();
        score.text = distance.ToString("F0");
        distance += Time.deltaTime * 10f;
        highRecord = distance;

        if (!Player.PlayerAlive)
        {
            record.text = "Ваш рекорд: " + PlayerPrefs.GetFloat("Record").ToString("F0");
            scoreText.text = "Вы набрали: " + distance.ToString("F0");
            loseScreen.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("Record")<= highRecord)
        {
            PlayerPrefs.SetFloat("Record", highRecord);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    
    private void ChangeSpeedLevel()
    {
        if (distance > checkPoint + 100 )
        {
            checkPoint += 100;
            ChangePlatformSpeed();
            spawner.spawnInterval -= 0.1f;
            print($"current spawn lvl is {spawner.spawnInterval}");
            
        }
    }

    void ChangePlatformSpeed()
    {
        foreach (var platform in platforms)
        {
            platform.speed += 1f;
            print($"current speed lvl is {platform.speed}");
        }
    }
}
