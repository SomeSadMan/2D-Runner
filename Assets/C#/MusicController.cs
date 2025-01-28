using UnityEngine;
using UnityEngine.Serialization;

public class MusicController : MonoBehaviour
{
    [SerializeField] private  AudioSource mainMusic;
    [SerializeField] private GameObject musicOn;
    [SerializeField] private GameObject musicOff;

    private static MusicController _instance;
    private bool _isPlaying;


    private void Start()
    {
        _isPlaying = true; 
    }

    private void Awake()
    {
        mainMusic.Play();
        if ( _instance != null )
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    private void Update()
    {
        CheckMusic();
    }

    public void MusicOff()
    {
        mainMusic.Pause();
        musicOn.SetActive(true);
        musicOff.SetActive(false);
        _isPlaying = false;
    }

    public void MusicOn()
    {
        mainMusic.Play();
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        _isPlaying = true;
    }
    
    private void CheckMusic()
    {
       if( _isPlaying && Time.timeScale == 0 )
       {
            mainMusic.volume = 0;
            _isPlaying = false;
       }
       else if( !_isPlaying && Time.timeScale == 1 )
       {
            mainMusic.volume = 0.5f;
            _isPlaying = true;
       }
    }
}
