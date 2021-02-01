using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.AISystem;

public class AIFallbackDistanceDecision : AIDecision
{
    public GameObject target;

    public float MaxDistanceInFallback = 5f;
    private void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public override bool Decide()
    {
        return CheckMaxDistance();
    }

    protected virtual bool CheckMaxDistance()
    {
        float distance = Vector3.Distance(target.transform.position, this.transform.position);
        if (distance >= MaxDistanceInFallback)
        {
            Debug.Log(":::: Distancia entre enemigo y player: " + distance);
            return true;
        }
        return false;
    }

}
