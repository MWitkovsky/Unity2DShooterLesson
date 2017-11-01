using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject objectToFire;
    public float shootDelay;

    private float shootDelayTimer;

	void Start () {
        shootDelayTimer = shootDelay;
	}
	
	void Update () {
        if (shootDelayTimer > 0.0f)
            shootDelayTimer -= Time.deltaTime;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (shootDelayTimer <= 0.0f && collision.CompareTag("Player"))
        {
            GameObject newBullet = Instantiate(objectToFire, transform.position, Quaternion.identity);
            newBullet.GetComponent<EnemyBullet>().SetDirection((collision.transform.position - transform.position).normalized);
            newBullet.GetComponent<EnemyBullet>().OffsetBullet(1.0f);
            shootDelayTimer = shootDelay;
        }
    }
}
