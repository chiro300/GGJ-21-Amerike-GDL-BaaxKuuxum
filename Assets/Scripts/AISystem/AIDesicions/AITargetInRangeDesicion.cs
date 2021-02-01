using Assets.Scripts.AISystem;
using System.Collections;
using UnityEngine;

public class AITargetInRangeDesicion : AIDecision
{
    public GameObject target;

    private Animator animator;

    private int idParameterPlayerInRange;
    public string nameParameterPlayerInRange;

    public float boundsExtentsLeft;
    public float boundsExtentsRight;
    public float boundsExtentsUp;
    public float boundsExtentsDown;

    protected Vector2 _boundsLeft;
    protected Vector2 _boundsRight;
    protected Vector2 _boundsUp;
    protected Vector2 _boundsDown;

    protected bool _init = false;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        idParameterPlayerInRange = Animator.StringToHash(nameParameterPlayerInRange);

        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        EstablishBounds();
    }

    public override bool Decide()
    {
        //Regresar true cuando el objetivo este en rango
        return CheckTargetInBounds();
    }

    protected virtual bool CheckTargetInBounds()
    {
        if (target.transform.position.x >= _boundsLeft.x &&
            target.transform.position.x <= _boundsRight.x &&
            target.transform.position.y >= _boundsDown.y &&
            target.transform.position.y <= _boundsUp.y)
        {
            return true;
        }

        return false;
    }

    protected virtual void EstablishBounds()
    {
        _boundsLeft = this.transform.position + Vector3.left * boundsExtentsLeft;
        _boundsRight = this.transform.position + Vector3.right * boundsExtentsRight;
        _boundsUp = this.transform.position + Vector3.up * boundsExtentsUp;
        _boundsDown = this.transform.position + Vector3.down * boundsExtentsDown;
    }

    protected virtual void OnDrawGizmos()
    {
        if (!_init)
        {
            EstablishBounds();
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_boundsLeft + Vector2.down * 1f, _boundsLeft + Vector2.up * 1f);
        Gizmos.DrawLine(_boundsRight + Vector2.down * 1f, _boundsRight + Vector2.up * 1f);
        Gizmos.DrawLine(_boundsUp + Vector2.right * 1f, _boundsUp + Vector2.left * 1f);
        Gizmos.DrawLine(_boundsDown + Vector2.right * 1f, _boundsDown + Vector2.left * 1f);
    }
}