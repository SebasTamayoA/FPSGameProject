using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform spawnBulletPoint;
    public Transform playerPosition;
    public float bulletSpeed = 100f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPosition = player.transform;
            Invoke("ShootPlayer", 3);
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShootPlayer()
    {
        if (playerPosition != null)
        {
            Vector3 playerDirection = playerPosition.position - transform.position;
            GameObject newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletSpeed, ForceMode.Force);
        }
        Invoke("ShootPlayer", 3);
    }
}
