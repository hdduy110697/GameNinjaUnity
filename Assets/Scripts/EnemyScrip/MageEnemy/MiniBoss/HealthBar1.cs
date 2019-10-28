using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar1 : MonoBehaviour
{
    public EnemyMage1 enemyMage;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        enemyMage = GameObject.FindGameObjectWithTag("EnemyMage1").GetComponent<EnemyMage1>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = enemyMage.health/enemyMage.maxHealth;
        transform.localScale = localScale;
    }
}
