using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [Tooltip("The player speed")]
    public float speed = 1;
    public float rotatespeed = 1;


    [Tooltip("The key to press for moving left.")]
    public KeyCode left;

    [Tooltip("The key to press for moving right.")]
    public KeyCode right;

    [Tooltip("The key to press for moving up.")]
    public KeyCode up;

    [Tooltip("The key to press for moving down.")]
    public KeyCode down;

    [Tooltip("The key to press for shooting.")]
    public KeyCode shoot;

    [Tooltip("The key to press for rotating clock-wise.")]
    public KeyCode rotatecw;

    [Tooltip("The key to press for rotating anti clock-wise.")]
    public KeyCode rotateacw;


    [Tooltip("The bullet object.")]
    public GameObject bulletPrefab;


    private GameObject gun;


    private float elpshoot;
    private const float shoottime = 0.5f;

    void Start()
    {
        gun = this.transform.GetChild(0).gameObject;
        float randomRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
    }

    void Update()
    {
        if (Input.GetKey(left))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(up))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(down))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey(rotatecw))
        {
            this.transform.Rotate(new Vector3(0, 0, rotatespeed));
        }
        if (Input.GetKey(rotateacw))
        {
            this.transform.Rotate(new Vector3(0, 0, -rotatespeed));
        }

        if (Input.GetKeyDown(shoot))
        {
            if (elpshoot > shoottime)
            {
                GameObject obj = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
                Bullet bullet = obj.GetComponent<Bullet>();
                bullet.ownerPlayer = gameObject;
                elpshoot = 0;
            }
        }

        elpshoot += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
