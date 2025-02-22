using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlaySceneBootStrap : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Player player;
    [SerializeField] private GameObject[] hpImage;

    private int  selectedSkin;
    private IMovement movement;
    private IState state;
    private IHealth health;
    private ICharacter character;

    void Start()
    {
        
        health = new CharacterHealth(3, hpImage );
        InjectPlayerDependencies(player); 
        gameManager.GameManagerConstruct(health, character, state);
        gameManager.LoadBGSkin();
    }

    private void InjectPlayerDependencies(Player _player)
    {
        character = _player;
        movement = new PlayerMovement(_player.Rb);
        state = new PlayerState(_player.Rb, _player.Anim);
        _player.Construct(movement, state, health); 
    }
    
    
}
