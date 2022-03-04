using UnityEngine;

public class Player : MonoBehaviour
{
    //inisialisasi variabel
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.81f;
    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //start
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    //update
    private void Update()
    {
        //untuk menggerakan burung agar terbang
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the bird based on the direction
        //Vector3 rotation = transform.eulerAngles;
        //rotation.z = direction.y * tilt;
        //transform.eulerAngles = rotation;
    }

    //Animate
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    //Penghitung Nilai
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) //jika nabrak
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.CompareTag("Nilai"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(); //jika berhasil
        }
    }
}
