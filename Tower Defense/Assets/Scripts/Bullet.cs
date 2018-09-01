using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 30;
    public float speed = 20;
    public GameObject explosionEffectPrefab;
    private Transform target;

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            print("GG");
            Die();
            return;
        }
        transform.LookAt(target.position,new Vector3(0,0,1));
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //局部坐标系，直接前方
    }

    private void OnTriggerEnter(Collider other)
    { 
      //  print(other.tag);
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            print("MM");
            Die();
        }
    }

    void Die()
    {
        GameObject tmp = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
        //  WaitForSeconds(0.5f); 
        Destroy(tmp, 0.5f);
    }
}
