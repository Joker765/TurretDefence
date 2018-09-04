using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 30;
    public float speed = 20;
    public GameObject explosionEffectPrefab;
    private Transform target;
    private bool isSetTarget=false;

    public void SetTarget(Transform _target)
    {
      //  isSetTarget = true;
        this.target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Die();
            return;
        }
        transform.LookAt(target.position);
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
