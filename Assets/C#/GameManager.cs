
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
    private bool isTipHidden;
    public int Coins { get; set; }

    [SerializeField] private PlatformController[] platforms;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text record;
    [SerializeField] private GameObject loseScreen;
    

    void Start()
    {
        Time.timeScale = 1;
    }
    
    void Update()
    {
        HintDissappearance(out var tip);
        HighScoreObservation();
        ChangeSpeedLevel();
        score.text = distance.ToString("F0");
        distance += Time.deltaTime * 10f;
        highRecord = distance;

        
    }

    private void HighScoreObservation()
    {
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

    
    private void HintDissappearance(out GameObject hint)
    {
        hint = GameObject.FindGameObjectWithTag("tip");
        if (hint)
        {
            Animator anim = hint.GetComponent<Animator>();
            
            if (!isTipHidden && Time.time > 10f)
            {
                anim.SetBool("dis", true);
                isTipHidden = true;
                Destroy(hint);
            }
        }
    }
}
