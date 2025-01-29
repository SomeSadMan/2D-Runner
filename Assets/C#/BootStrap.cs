using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    private IDeath deathService;
    [SerializeField] private Player player;
    [SerializeField] private GameObject[] hpImage;
    void Start()
    {
        InjectPlayerDependencies(player);
        deathService = new DeathService();
    }

    private void InjectPlayerDependencies(Player _player)
    {
        IMovement movement = new PlayerMovement(_player.Rb, _player.JumpVelocity, _player.FallVelocity);
        IState state = new PlayerState(_player.Rb, _player.Anim);
        IHealth health = new CharacterHealth(3, hpImage );
        _player.Construct(movement, state, health); 
    }

    
}
