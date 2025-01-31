using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private PlatformController[] platforms;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text record;
    [SerializeField] private Text finalScore;
    [SerializeField] private Text coinText;

    private IState state;
    private IHealth _health;
    private ICharacter _player;

    
    public int СoinsScore { get; set; }
    private float distance;
    private float highRecord;
    private float checkPoint;

    public void GameManagerConstruct (IHealth health,  ICharacter player , IState state)
    {
        _health = health;
        _player = player;
        this.state = state;
        DeathService death = new DeathService();
        health.OnDeath += () => death.Death(_player);
    }
    private void Start()
    {
        Time.timeScale = 1;
        coinText.text = $" {СoinsScore} ";
    }

    private void Update()
    {
        GlobalStuff();
        ChangeSpeedLevel();
        DistanceUpdate();
    }

    private void DistanceUpdate()
    {
        distance += Time.deltaTime * 10f;
        currentScore.text = distance.ToString("F0");
        highRecord = distance;
    }


    private void HighScoreObservation()
    {
        print("метод вызван");
        record.text = "Ваш рекорд: " + PlayerPrefs.GetFloat("Record").ToString("F0");
        finalScore.text = "Вы набрали: " + distance.ToString("F0");
        if (PlayerPrefs.GetFloat("Record") <= distance)
        {
            PlayerPrefs.SetFloat("Record", distance);
            PlayerPrefs.Save();
        }
    }
    

    public void GlobalStuff()
    {
        if (state.GetCurrentState() == PlayerState.MovementState.Death)
        {
            deathScreen.SetActive(true);
            HighScoreObservation();
            Time.timeScale = 0;
        }
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
            if (platform.speed < platform.msxSpeed)
            {
                platform.speed += 1f;
                print($"current speed lvl is {platform.speed}");
            }
            else
            {
                print("Maximum speed reached!");
            }
        }
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    
   
}
