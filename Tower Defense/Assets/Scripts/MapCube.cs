using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {
    [HideInInspector] //不会显示再Inspector面板上
    public GameObject turretOn;  //当前Cube身上的炮台
    public TowerData towerDataOn;
    [HideInInspector]
    public bool isUpgraded = false;

    public GameObject buildEffect;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void BuildTurret(TowerData towerData)
    {
        this.towerDataOn = towerData;
        turretOn = GameObject.Instantiate(towerData.turretPrefab, transform.position, Quaternion.identity);
        GameObject tmp= GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(tmp, 1f);
    }

    public void UpgradeTurret()
    {
        isUpgraded = true;
        Destroy(turretOn);
        turretOn=GameObject.Instantiate(towerDataOn.turretUpdatePrefab, transform.position, Quaternion.identity);
        GameObject tmp = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(tmp, 1f);
    }

    public void DestroyTurret()
    {
        Destroy(turretOn);
        GameObject tmp = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(tmp, 1f);
        isUpgraded = false;
        turretOn = null;
        towerDataOn = null;
    }

    private void OnMouseEnter()
    {
        if (turretOn == null && EventSystem.current.IsPointerOverGameObject()==false) //鼠标未悬停在UI上
        {
            _renderer.material.color = Color.red;
        }
    }
    private void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }

    
}
