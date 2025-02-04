using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject[] bgSkins;
    [SerializeField] private GameObject backGtound;
    [SerializeField] private GameObject oldBG;
    [SerializeField] private PlatformController[] platforms;
    
    
    [SerializeField] private Text currentScore;
    [SerializeField] private Text record;
    [SerializeField] private Text finalScore;
    [SerializeField] private Text coinText;

    private int selectedskin;
    private IState state;
    private IHealth _health;
    private ICharacter _player;

    public event Action<int> OnCoinCollected;
    public event Action OnHintDissapear;

    private int СoinsScore { get; set; }
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
        СoinsScore = PlayerPrefs.GetInt("CoinValue", 0);
        coinText.text = $" {СoinsScore} ";
        OnCoinCollected += UpdateCoinText;
    }

    private void Update()
    {
        ActivateDeathState();
        ChangeSpeedLevel();
        DistanceUpdate();
        HintDisappearing();

    }

    public void LoadBGSkin()
    {
        selectedskin = PlayerPrefs.GetInt("selectedBG", -1);
        GameObject pref = bgSkins[selectedskin];
        GameObject clone = Instantiate(pref, backGtound.transform.position, Quaternion.identity);
        clone.transform.SetParent(backGtound.transform);
        clone.transform.rotation = Quaternion.Euler(90 , 180 , 0);
        oldBG.SetActive(false);
        clone.SetActive(true);
        
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
    

    private void ActivateDeathState()
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

    public void UpdateCoinText( int amount)
    {
        СoinsScore += amount;
        coinText.text = $" {СoinsScore} ";
        PlayerPrefs.SetInt("CoinValue", СoinsScore);
        PlayerPrefs.Save();
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    private void HintDisappearing()
    {
        if (distance > 100)
        {
            if (OnHintDissapear != null) OnHintDissapear.Invoke();
        }
    }
    
   
}
