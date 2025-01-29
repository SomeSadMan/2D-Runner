using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private Player player;
    void Start()
    {
        InjectPlayerDependencies(player);
    }

    private void InjectPlayerDependencies(Player _player)
    {
        IMovement movement = new PlayerMovement(_player.Rb, _player.JumpVelocity, _player.FallVelocity);
        IState state = new PlayerState(_player.Rb, _player.Anim);
        _player.Construct(movement, state);
    }

    
}
