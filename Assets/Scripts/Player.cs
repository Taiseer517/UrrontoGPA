using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer SpriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public float gravity = -9.8f;
    public float strength = 5f;
    [SerializeField] private AudioSource jumpSoundEffect, scoreSoundEffect, deathSoundEffect, BGmusic;


    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
        deathSoundEffect.Stop();
        BGmusic.Play();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            jumpSoundEffect.Play();
        }
    

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
              direction = Vector3.up * strength;
              jumpSoundEffect.Play();
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite(){
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        SpriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle"){
            FindObjectOfType<GameManager>().GameOver();
            BGmusic.Stop();
            deathSoundEffect.Play();
        }

        else if (other.gameObject.tag == "Scoring"){
            FindObjectOfType<GameManager>().IncreaseScore();
            scoreSoundEffect.Play();
        }
    }


}
