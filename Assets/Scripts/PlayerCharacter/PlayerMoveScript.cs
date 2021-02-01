
using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum FacingDiractions
{
    Up,
    Down,
    Left,
    Right,
}

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] public PlayerInput playerInput;
    private Vector3 inputMove;
    public float moveSpeed = 1f;

    private bool _isAttacking;
    private bool _isDashing;

    public DamageOnTouch damageUp;
    public DamageOnTouch damageDown;
    public DamageOnTouch damageLeft;
    public DamageOnTouch damageRight;

    public FacingDiractions facing = FacingDiractions.Down;
    //private Button inputDash;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public float timeInAttack = .5f;

    protected bool isInAttack = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    #region MoveEvents

    private void OnMove(InputValue value)
    {
        inputMove = value.Get<Vector2>();
        
        Debug.Log(inputMove);
        
        if(inputMove.x == -1)
        {
            facing = FacingDiractions.Left;
            return;
        }
        if (inputMove.x == 1)
        {
            facing = FacingDiractions.Right;
            return;
        }
        if (inputMove.y == -1)
        {
            facing = FacingDiractions.Down;
            return;
        }
        if (inputMove.y == 1)
        {
            facing = FacingDiractions.Up;
            return;
        }
    }

    private void OnAttack(InputValue value)
    {
        if (!isInAttack)
        {
            _animator.SetTrigger("Attacking");
            StartCoroutine(AttackAction());
        }
    }

    private IEnumerator AttackAction()
    {
        DamageOnTouch currentDamage = damageDown;

        switch(facing)
        {
            case FacingDiractions.Up:
                currentDamage = damageUp;
                break;
            case FacingDiractions.Down:
                currentDamage = damageDown;
                break;
            case FacingDiractions.Left:
                currentDamage = damageLeft;
                break;
            case FacingDiractions.Right:
                currentDamage = damageRight;
                break;
        }

        isInAttack = true;

        if (!_isAttacking)
            SoundManager.PlaySound(SoundManager.Sound.sword);

        currentDamage.Attack();
        
        yield return new WaitForSeconds(timeInAttack);

        currentDamage.EndAttack();
        isInAttack = false;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        if (inputMove != Vector3.zero)
        {
            gameObject.transform.position += inputMove * moveSpeed * Time.deltaTime;

            _animator.SetFloat("MoveX", inputMove.x);
            _animator.SetFloat("MoveY", inputMove.y);
            _animator.SetBool("Idle", false);
            //SoundManager.PlaySound(SoundManager.Sound.PlayerMove);
        }

        if (_isAttacking == false)
        {
            if (inputMove != Vector3.zero)
            {
                gameObject.transform.position += inputMove * moveSpeed * Time.deltaTime;

                _animator.SetFloat("MoveX", inputMove.x);
                _animator.SetFloat("MoveY", inputMove.y);
                _animator.SetBool("Idle", false);
            }
            else
            {
                _animator.SetBool("Idle", true);
            }

        }
    }

    void LateUpdate()
    {

        _animator.SetBool("Idle", inputMove == Vector3.zero);

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
        {
            _isAttacking = true;
            Debug.Log(_isAttacking);
        }
        else
        {
            _isAttacking = false;
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("DashMoving"))
        {
            _isDashing = true;
        }
        else
        {
            _isDashing = false;
        }
    }

    private void OnDash(InputValue value)
    {
        float dashMove = 50f;
        if (!_isDashing)
        {
            gameObject.transform.position += inputMove * dashMove * Time.deltaTime;
            _animator.SetTrigger("Dash");
        }
    }
}