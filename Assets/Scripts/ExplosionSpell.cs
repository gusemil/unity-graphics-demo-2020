using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpell : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject,2.5f);
    }
}
