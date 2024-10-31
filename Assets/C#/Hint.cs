using UnityEngine;


public class Hint : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HintDissapearing();
    }

    private void HintDissapearing()
    {
        
    }
}
