using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public static  int frontEnemy;
    public Waves[] wave;
    public Transform START;
    public float waveRate=4;
    private Coroutine coroutine;


	// Use this for initialization
	void Start () {
        coroutine = StartCoroutine(Joker());
	}

    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator Joker()
    {
        //所有波敌人的生成
        foreach  (Waves apple in wave)
        {
            //一波敌人的生成
            frontEnemy = apple.count;        
            for (int i=0; i < apple.count; i++)
            {
                GameObject.Instantiate(apple.enemyPrefab, START.position-new Vector3(0,1,0), Quaternion.identity);
                yield return new WaitForSeconds(apple.rate);
            }
            while (frontEnemy > 0) yield return 0;
       
            yield return new WaitForSeconds(waveRate);
        }
    }


}
