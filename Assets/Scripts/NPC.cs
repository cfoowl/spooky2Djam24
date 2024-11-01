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
    public float patienceMax;
    public float currentPatience;

    public NPCSprite nPCSprite;

    // Identity trait
    public int ID;
    public int spriteID;
    public string IDname;
    public int hatIndex; 
    public int colorIndex;
    public EDeathCauses deathCause;
    public string sentence;


    void Start() {
        canMove = true;
        StartCoroutine(SelectRandomDestination(new WaitForSeconds(0)));
        currentPatience = 0f;
    }
    void Update()
    {
        if(canMove) {
            UpdateMovement();
        }
        currentPatience += Time.deltaTime;
        if(currentPatience >= patienceMax) {
            BadEnd();
        }
    }

    void UpdateMovement() {
        Vector2 targetPosition = Vector2.zero; 
        Vector2 currentPosition = transform.position;
        
        if (Vector2.Distance(currentPosition, targetPosition) > centerRadius)
        {
            // Go to the center
            // if((currentPosition - targetPosition).x > 0 ) {
            //     nPCSprite.bodySpriteRenderer.flipX = false;
            //     nPCSprite.hatSpriteRenderer.flipX = false;
            // } else {
            //     nPCSprite.bodySpriteRenderer.flipX = true;
            //     nPCSprite.hatSpriteRenderer.flipX = true;
            // }
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        } else {
            // Random movement
            if(randomDestination != Vector2.zero) {
                if (Vector2.Distance(currentPosition, randomDestination) > 0.1f) {
                    // if((currentPosition - randomDestination).x > 0 ) {
                    //     nPCSprite.bodySpriteRenderer.flipX = false;
                    //     nPCSprite.hatSpriteRenderer.flipX = false;
                    // } else {
                    //     nPCSprite.bodySpriteRenderer.flipX = true;
                    //     nPCSprite.hatSpriteRenderer.flipX = true;
                    // }
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

    public void HappyEnd() {
        GameflowManager.instance.UpdateSatisfaction(1);
        SoundManager.instance.PlayHappyGhostSound();
        Delete();
    }
    public void BadEnd() {
        GameflowManager.instance.UpdateSatisfaction(-1);
        Delete();
    }

    public void Delete() {
        NPCManager.instance.NPCs.Remove(this);
        NPCManager.instance.spriteIDAvailable.Add(spriteID);
        Destroy(gameObject);
    }
}
