using Assets.Scripts.AISystem;
using Assets.Scripts.Behaivors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrollingAction : AIAction
{
    public float boundsExtentsLeft;    
    public float boundsExtentsRight;
    public float boundsExtentsUp;
    public float boundsExtentsDown;

    protected Vector2 _boundsLeft;
    protected Vector2 _boundsRight;
    protected Vector2 _boundsUp;
    protected Vector2 _boundsDown;

    public string patrollingParameterName;
    private int patrollingParameterId;

    private Animator animator;

    protected WalkingBeheivor walking;

    protected bool _init = false;
    protected bool inOutLimits = false;

    private void Awake()
    {
        _init = true;
        animator = gameObject.GetComponent<Animator>();
        walking = gameObject.GetComponent<WalkingBeheivor>();

        ChangeDirection(1, 0);

        if (animator != null)
        {
            patrollingParameterId = Animator.StringToHash(patrollingParameterName);
        }

        EstablishBounds();
    }

    public override void Action()
    {
        //TODO: Optimizar esto  
        if(!string.IsNullOrEmpty(patrollingParameterName))
            animator.SetBool(patrollingParameterId, true);

        CheckForDistance();
    }


    public override void ExitAction()
    {
        animator.SetBool(patrollingParameterId, false);
    }

    

    protected virtual void CheckForDistance()
    {   
        if (this.transform.position.x < _boundsLeft.x)
        {
            ChangeDirection(Vector2.right + new Vector2(0, Random.Range(-1f, 1f)));
            inOutLimits = true;
            return;
        }
        if (this.transform.position.x > _boundsRight.x)
        {
            ChangeDirection(Vector2.left + new Vector2(0, Random.Range(-1f, 1f)));
            inOutLimits = true;
            return;
        }
        if (this.transform.position.y < _boundsDown.y)
        {
            ChangeDirection(Vector2.up + new Vector2(Random.Range(-1f, 1f), 0));
            inOutLimits = true;
            return;
        }
        if (this.transform.position.y > _boundsUp.y)
        {
            ChangeDirection(Vector2.down + new Vector2(Random.Range(-1f, 1f), 0));
            inOutLimits = true;
            return;
        }

        inOutLimits = false;
    }

    protected virtual void ChangeDirection(Vector2 vector)
    {
        ChangeDirection(vector.x, vector.y);
    }
    
    protected virtual void ChangeDirection(float x, float y)
    {
        if (!inOutLimits)
        {
            walking.SetHorizontalMove(x);
            walking.SetVerticalMove(y);
        }        
    }

    protected virtual void EstablishBounds()
    {
        _boundsLeft = this.transform.position + Vector3.left * boundsExtentsLeft;
        _boundsRight = this.transform.position + Vector3.right * boundsExtentsRight;
        _boundsUp = this.transform.position + Vector3.up * boundsExtentsUp;
        _boundsDown = this.transform.position + Vector3.down * boundsExtentsDown;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        if (!_init)
        {
            EstablishBounds();
        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_boundsLeft + Vector2.down * 1f, _boundsLeft + Vector2.up * 1f);
        Gizmos.DrawLine(_boundsRight + Vector2.down * 1f, _boundsRight + Vector2.up * 1f);
        Gizmos.DrawLine(_boundsUp + Vector2.right * 1f, _boundsUp + Vector2.left * 1f);
        Gizmos.DrawLine(_boundsDown + Vector2.right * 1f, _boundsDown + Vector2.left * 1f);
    }
}