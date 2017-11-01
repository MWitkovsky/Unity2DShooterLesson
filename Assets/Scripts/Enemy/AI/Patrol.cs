using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public float moveSpeed;
    public Vector3 patrolDistance;

    private Vector3 originalPosition, offsetPosition, targetPosition;
    private Vector3 direction;
    private float previousDistance, currentDistance;

    void Start () {
        originalPosition = transform.position;
        offsetPosition = originalPosition + patrolDistance;
        targetPosition = offsetPosition;
        direction = (targetPosition - transform.position).normalized;
        currentDistance = 99999.9f;
    }
	
	void FixedUpdate () {
        previousDistance = currentDistance;
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);
        currentDistance = Vector3.Distance(transform.position, targetPosition);

        if (currentDistance > previousDistance)
        {
            transform.position = targetPosition;
            if (targetPosition == offsetPosition)
            {
                targetPosition = originalPosition;
            }
            else
            {
                targetPosition = offsetPosition;
            }
            direction = (targetPosition - transform.position).normalized;

            currentDistance = 99999.9f;
        }
    }
}
