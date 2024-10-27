using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [HideInInspector] public float centerRadius = 2f;
    [SerializeField] float speed = 1f;
    [HideInInspector] public bool canMove;
    Vector2 randomDestination = Vector2.zero;
    bool inCoroutine = false;

    // Identity trait
    public int ID;
    public string IDname;
    public bool hasGlasses;
    public bool hasHat;
    public bool hasTie;
    public bool hasCollar;
    public EDeathCauses deathCause;
    public string sentence;


    void Start() {
        canMove = true;
        StartCoroutine(SelectRandomDestination(new WaitForSeconds(0)));
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
        
        if (Vector2.Distance(currentPosition, targetPosition) > centerRadius)
        {
            // Go to the center
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        } else {
            // Random movement
            if(randomDestination != Vector2.zero) {
                if (Vector2.Distance(currentPosition, randomDestination) > 0.1f) {
                    transform.position = Vector2.MoveTowards(currentPosition, randomDestination, speed * Time.deltaTime);
                } else {
                    if (!inCoroutine) {
                        StartCoroutine(SelectRandomDestination(new WaitForSeconds(Random.Range(2f,5f))));
                    }
                }
            }
            
        }

    }

    IEnumerator SelectRandomDestination(WaitForSeconds wait) {
        inCoroutine = true;
        float radius = centerRadius - 0.5f;
        float targetX = Random.Range(-radius, radius);
        float targetY = Random.Range(-radius, radius);
        yield return wait;
        randomDestination = new Vector2(targetX, targetY);
        inCoroutine = false;
    }
}
