using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [Tooltip("The bullet speed")]
    public float speed = 35;

    public GameObject ownerPlayer;

    void Start()
    {
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ownerPlayer)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            return;
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);

            Startup manager = Object.FindFirstObjectByType<Startup>();
            manager.Reset(ownerPlayer.name + " wins!");
        }

        gameObject.SetActive(false);
        Destroy(this);
    }
}
