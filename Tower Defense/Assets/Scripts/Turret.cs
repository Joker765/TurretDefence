using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private List<GameObject> enemys = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }



    public float attackRate = 0.5f;
    private float timer=0.5f;

    public GameObject weaponPrefab;
    public Transform firePosition;
    public Transform head;

    private void Update()
    {
        timer += Time.deltaTime;
        print(enemys.Count);
        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPos = enemys[0].transform.position;
            targetPos.y = head.position.y;
            head.LookAt(targetPos);
        }

        if (enemys.Count>0 && timer > attackRate && enemys[0] != null)
        {
            timer = 0;
            Attack();
        }

      //  if (enemys[0] == null) enemys.Remove(enemys[0]);   第一个被销毁的不一定是数组第一个，（除了到达终点死意外，还可以被其他炮塔打死）
    }
    void Attack()
    {
        if (enemys[0] == null)
        {
            //enemys.RemoveAll(null);
            UpdateList();
            if (enemys.Count <= 0) { timer = attackRate; return; }
        }
        GameObject bullet= GameObject.Instantiate(weaponPrefab, firePosition.position, firePosition.rotation);
        bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
    }

    void UpdateList()
    {
      //  List<int> emptyIndex = new List<int>();

        for (int i=0; i<enemys.Count; i++)
        {
            if  (enemys[i] == null)
            {
                enemys.RemoveAt(i);
                i--;
            }
        }
    }
}
