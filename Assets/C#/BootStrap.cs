using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Player player;
    [SerializeField] private GameObject[] hpImage;
    void Start()
    {
        InjectPlayerDependencies(player);
        
    }

    private void InjectPlayerDependencies(Player _player)
    {
        IMovement movement = new PlayerMovement(_player.Rb);
        IState state = new PlayerState(_player.Rb, _player.Anim);
        IHealth health = new CharacterHealth(3, hpImage );
        gameManager = new GameManager(health, _player);
        _player.Construct(movement, state, health); 
    }

    
}
