using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 20;
    public ParticleSystem muzzleFlash;
    public float range = 15;
    public float fireRate = 1;
    public AudioClip shotSFX;
    public AudioSource audioSource;
    public Transform bulletSpawn;
    public float force = 155;

    private float nextFire = 0;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = 0.3f;

        if (Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(shotSFX);
        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("asd" + hit.collider);

            if (hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }
}
