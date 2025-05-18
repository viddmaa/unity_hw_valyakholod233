using UnityEngine;
using System.Collections;
using UnityEngine.Audio;


public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireDelay = 0.5f;

    public AudioClip shootSound;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;

    private AudioSource audioSource;
    private bool canShoot = true;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.outputAudioMixerGroup = sfxMixerGroup;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        canShoot = false;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed;

        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
}
