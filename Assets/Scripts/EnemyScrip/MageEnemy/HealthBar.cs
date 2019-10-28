using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public EnemyMage enemyMage;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        enemyMage = GameObject.FindGameObjectWithTag("EnemyMage").GetComponent<EnemyMage>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = enemyMage.health/30f;
        transform.localScale = localScale;
    }
}
