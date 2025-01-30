using System;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    private IMovement _imovement;
    private IState _state;
    private IHealth _health;
    private BoxCollider2D coll;

    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }
    public event Action<GameObject> OnReturnInPool;
    
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float fallVelocity;
    [SerializeField] private LayerMask jumpableGround;
    public float JumpVelocity => jumpVelocity;
    public float FallVelocity => fallVelocity;
    
    
    private bool jump;
    private bool doubleJump;
    private bool down;
    public bool CanDoubleJump { get; private set; }

    public void Construct(IMovement movement, IState state, IHealth health)
    {
        _imovement = movement;
        _state = state;
        _health = health;
    }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        FlagsChecker();
    }
    
    private void Update()
    {
        PlayerInputsObserver();
        _state.CheckAnimationState(this, _health);
        
    }

    private void PlayerInputsObserver()
    {
        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            jump = true;
        }
        
        if (Input.GetButtonDown("Jump") && CanDoubleJump && !IsGrounded())
        {
            doubleJump = true;
        }
        
        if (Input.GetButtonDown("Vertical"))
        {
            down = true;
        }
    }
    
    private void FlagsChecker()
    {
        if (jump)
        {
            _imovement.Jump(jumpVelocity);
            jump = false;
            CanDoubleJump = true;
        }
        
        if (doubleJump)
        {
            _imovement.DoubleJump(jumpVelocity);
            doubleJump = false;
            CanDoubleJump = false;
        }
        
        if (down)
        {
            _imovement.Down(fallVelocity);
            down = false;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _health.TakeDamage(1);// заглушка , в будущем можно сменить на интерфейс Damagable, который будет наносить урон 
            _health.HideHeartFromBar();
            //TODO:сделать анимацию получения урона (мигание спрайта или визуальный эффект) 
            //Debug.Log($"hp deducted, your current hp is {hp.HpValue}");
            //pool.ReturnObstacle(collision.gameObject);
            OnReturnInPool?.Invoke(collision.gameObject);
            
            
        }
    }
}