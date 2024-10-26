using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [HideInInspector] public bool canMove;

    void Start() {
        canMove = true;
    }
    void Update()
    {
        if(canMove) {
            UpdateMovement();
        }
    }

    void UpdateMovement() {
        Vector2 targetPosition = Vector2.zero; 
        Vector2 currentPosition = transform.position;
        
        if (Vector2.Distance(currentPosition, targetPosition) > 0.1f)
        {
            Vector2 direction = (targetPosition - currentPosition).normalized; 

            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        }

    }
}
