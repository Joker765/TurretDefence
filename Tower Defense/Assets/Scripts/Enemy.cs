using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float hp=100;
    public GameObject explosionEffect;
    public float speed=10;
    public int repay = 10;

    private float maxHp;
    private Slider hpSlider;
    private Transform[] pos;
    private int i=0;

	// Use this for initialization
	void Start () {
        hpSlider =GetComponentInChildren<Slider>();
        pos = Findway.pos;
        maxHp = hp;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        if (i >= pos.Length)
        {
            ReachDestination();
            return;
        }
        transform.Translate((pos[i].position - transform.position).normalized*speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pos[i].position) < 0.2f)
        {
            i++;
        }
    }

    void ReachDestination()
    {
        //BuildManager.Instance.UpdateMoney(repay);
        GameManager.Instance.Failed();
        GameObject.Destroy(this.gameObject);
        EnemySpawn.frontEnemy--;
 
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / maxHp;
        if (hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        GameObject tmp= GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(tmp, 1.5f);
        GameObject.Destroy(this.gameObject);
        EnemySpawn.frontEnemy--;
        BuildManager.Instance.UpdateMoney(repay);
    }

}
