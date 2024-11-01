using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    public bool canDrag {get; private set;}
    [HideInInspector] public bool isDragging;
    public bool canMove;
    public EZonesTypes currentStand;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canDrag = false;
        isDragging = false;
        canMove = true;
    }

    void FixedUpdate()
    {
        if (canMove) {
            UpdateMovement();
        }
    }

    void UpdateMovement() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(moveX > 0) {
            spriteRenderer.sprite = sprites[2];
        } else if (moveX < 0) {
            spriteRenderer.sprite = sprites[1];
        } else if (moveY > 0) {
            spriteRenderer.sprite = sprites[3];
        } else {
            spriteRenderer.sprite = sprites[0];
        }

        Vector2 movement = new Vector2(moveX, moveY) * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    public void OnZoneEnter(EZonesTypes type) {
        currentStand = type;
        switch(type) {
            case EZonesTypes.HOME:
                canDrag = true;
                Textbubble.instance.showBubble = true;
                break;
            case EZonesTypes.PHOTO:
                canDrag = true;
                break;
            case EZonesTypes.RETURN:
                canDrag = true;
                break;
            case EZonesTypes.ASSEMBLY:
                UIManager.instance.ShowAssemblyUIPanel();
                break;
            default:
                break;
        }
    }
    public void OnZoneExit(EZonesTypes type) {
        currentStand = EZonesTypes.NONE;
        switch(type) {
            case EZonesTypes.HOME:
                canDrag = false;
                isDragging = false;
                Textbubble.instance.HideBubble();
                CameraZoom.instance.ResetZoom();
                Textbubble.instance.showBubble = false;
                break;
            case EZonesTypes.PHOTO:
                canDrag = false;
                isDragging = false;
                CameraZoom.instance.ResetZoom();
                break;
            case EZonesTypes.RETURN:
                canDrag = false;
                isDragging = false;
                UIManager.instance.HideFolderUIPanel();
                CameraZoom.instance.ResetZoom();
                break;
            default:
                break;
        }
    }
}
