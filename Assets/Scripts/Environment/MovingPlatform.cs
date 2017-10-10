using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float moveSpeed;
    public Vector3 targetOffset;

    private Vector3 originalPosition, offsetPosition, targetPosition;
    private Vector3 direction;
    private float previousDistance, currentDistance;

	void Start () {
        //Store platform's original position
        originalPosition = transform.position;
        //Calculate offset position
        offsetPosition = originalPosition + targetOffset;
        //Set target to be the offset position to start with
        targetPosition = offsetPosition;
        //Calculate the direction towards the target position
        direction = (targetPosition - transform.position).normalized;
        //Set current distance to some really high number by default
        currentDistance = 99999.9f;
	}
	
	void FixedUpdate () {
        //Store the previous distance away from target
        previousDistance = currentDistance;
        //Perform the translation
        transform.parent.Translate(direction * moveSpeed * Time.fixedDeltaTime);
        //Calculate new distance from target
        currentDistance = Vector3.Distance(transform.position, targetPosition);

        //Check if we've passed our target
        if (currentDistance > previousDistance)
        {
            //We've reached our target.
            transform.position = targetPosition;
            //Time to swap our target position
            if (targetPosition == offsetPosition)
            {
                targetPosition = originalPosition;
            }
            else
            {
                targetPosition = offsetPosition;
            }
            //Recalculate the direction towards the target position
            direction = (targetPosition - transform.position).normalized;
            //Reset current distance to some really high number
            currentDistance = 99999.9f;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Moves everything in the trigger along with the platform
        collision.transform.SetParent(transform.parent);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.SetParent(null);
    }
}
