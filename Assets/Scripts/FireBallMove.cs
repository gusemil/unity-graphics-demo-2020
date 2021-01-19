using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
    public float moveSpeed;
    public GameObject hitEffect;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        Instantiate(hitEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
        Destroy(this.gameObject);
    }
}
