using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BootStrap : MonoBehaviour
{
    private GameManager gameManager;
    private IMovement movement;
    private IState state;
    private IHealth health;
    private ICharacter character;
    private IDeath death;
    [SerializeField] private Player player;
    [SerializeField] private GameObject[] hpImage;
    void Start()
    {
        health = new CharacterHealth(3, hpImage );
        InjectPlayerDependencies(player);
        InjectDeathServiceDependencies();
        InjectGameManagerDependencies();

    }

    private void InjectPlayerDependencies(Player _player)
    {
        character = _player;
        movement = new PlayerMovement(_player.Rb);
        state = new PlayerState(_player.Rb, _player.Anim);
        _player.Construct(movement, state, health); 
    }

    private void InjectGameManagerDependencies()
    {
        gameManager = new GameManager(health, character , death);
        
    }
    private void InjectDeathServiceDependencies()
    {
        
        Debug.Log("InjectDsDependencies вызван!");
        Debug.Log("character: " + (character == null ? "NULL" : "OK"));
        Debug.Log("health: " + (health == null ? "NULL" : "OK"));
        death = new DeathService(character, health);
        death.AddEvent();
        

    }
    
}
