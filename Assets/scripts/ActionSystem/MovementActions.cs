﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementActions : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public bool willCalculateDirection = false;

    private void Start()
    {
        navMeshAgent =
            Util.CheckForNull(GetComponent<NavMeshAgent>(), typeof(NavMeshAgent), gameObject) as NavMeshAgent;
    }

    public void CircleAroundTarget(bool clockwise, float speed, bool willLookAtTarget, Transform target, bool rotateByRigidbody = true)
    {
        navMeshAgent.enabled = false;
        Vector3 directionVector = target.position - transform.position;
        if (rotateByRigidbody)
        {
            transform.GetComponent<Rigidbody>().AddForce(
                Vector3.Cross(directionVector, clockwise ? Vector3.down : Vector3.up).normalized * speed,
                ForceMode.Acceleration);
        }
        else
        {
            transform.position = transform.position + 
                Vector3.Cross(directionVector, clockwise ? Vector3.down : Vector3.up).normalized * speed;
            transform.LookAt(transform.position + 
                             Vector3.Cross(directionVector, clockwise ? Vector3.down : Vector3.up).normalized * speed);
        }

        if (willCalculateDirection)
            transform.rotation =
                Quaternion.LookRotation(Vector3.Cross(directionVector, clockwise ? Vector3.down : Vector3.up));
        if (willLookAtTarget)
            transform.LookAt(target);
    }

    public void ChaseDown(float runningSpeed, Transform target)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = true;
            navMeshAgent.speed = runningSpeed;
            transform.LookAt(target);
            target = GameObject.FindWithTag("Player").transform;
            navMeshAgent.SetDestination(target.transform.position);
        }
    }

    public void StopMoving()
    {
        navMeshAgent.enabled = false;
    }

    public void RunAwayFromTarget(Transform target)
    {
        transform.GetComponent<Rigidbody>().velocity += (transform.position - target.position);
    }
    
    public void TurnTo(Transform target)
    {
        transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.down);
    }
}