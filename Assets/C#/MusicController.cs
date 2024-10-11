using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private  AudioSource _mainMusic;
    [SerializeField] private GameObject _musicOn;
    [SerializeField] private GameObject _musicOff;

    private static MusicController _instance;
    private bool _isPlaying;


    private void Start()
    {
        _isPlaying = true; 
    }

    private void Awake()
    {

        
        _mainMusic.Play();
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
        _mainMusic.Pause();
        _musicOn.SetActive(true);
        _musicOff.SetActive(false);
        _isPlaying = false;
       

    }

    public void MusicOn()
    {
        _mainMusic.Play();
        _musicOn.SetActive(false);
        _musicOff.SetActive(true);
        _isPlaying = true;
        

    }
    
    private void CheckMusic()
    {
       if( _isPlaying && Time.timeScale == 0 )
       {
            _mainMusic.volume = 0;
            _isPlaying = false;
            
           
       }
        else if( !_isPlaying && Time.timeScale == 1 )
        {
            _mainMusic.volume = 0.5f;
            _isPlaying = true;
        }
        


    }
}
