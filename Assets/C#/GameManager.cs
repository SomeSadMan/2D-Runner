
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    public Text score;
    private float distance;
    private float highRecord;
    private float checkPoint;
    [SerializeField]private PlatformController platformSpeed;
    private NewSpawnerScriptFromDino spawnInterval;
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
        platformSpeed.speed = 3f;
        spawnInterval.spawnInterval = 2f;
    }

   
   

    private void ChangeSpeedLevel()
    {
        if (distance > checkPoint + 100 )
        {
            //TODO: Сделать повышение скорости для всех поатформ , сейчас скорость повышается только для одной платформы
            
            checkPoint += 100;
            platformSpeed.speed += 1f;
            // spawnInterval.spawnInterval -= 0.1f;
            Debug.Log("speed was increased");
        }
    }
    
}
