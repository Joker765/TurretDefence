using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    public TowerData laserTurretData;
    public TowerData missileTurretData;
    public TowerData standardTurretData;

    //private bool isUpgraded = false;
    private TowerData selectedData;
    //private GameObject frontTurret;
    private MapCube mapCube;

    //public Canvas upgradeCanvas;
    public GameObject upgradeCanvas;
    public Button upgradeButton;

    public Text moneyText;
    public int money = 1000;
    public Animator moneyAnimator;

    void UpdateMoney(int change=0)
    {
        money += change;
        moneyText.text = "￥" + money;
    }


    private void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            if (! EventSystem.current.IsPointerOverGameObject()) //鼠标没有在UI上
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitImfo;
                bool isCollide = Physics.Raycast(ray,out hitImfo, 1000, LayerMask.GetMask("MapCube"));
                if (isCollide)
                {
                    // GameObject mapCube = hitImfo.collider.gameObject;  //得到鼠标指向的MapCube
                    MapCube mapCube = hitImfo.collider.GetComponent<MapCube>();
                    if (selectedData != null && mapCube.turretOn == null)
                    {
                        //可以创建Turret
                        if (money >= selectedData.cost)
                        {
                            UpdateMoney( -selectedData.cost);
                            mapCube.BuildTurret(selectedData);
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flick");
                        }
                    }else if (mapCube.turretOn!= null)
                    {
                        //升级
                        
                        
                        if (this.mapCube==mapCube  && upgradeCanvas.activeInHierarchy)
                        {
                            HideUpgradeCanvas();
                        } else ShowUpgradeCanvas(mapCube.transform.position, mapCube.isUpgraded);

                        this.mapCube = mapCube;
                    }
                }
            }
        }
    }



    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedData = laserTurretData;
        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedData = missileTurretData;
        }
    }

    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedData = standardTurretData;
        }
    }

    void ShowUpgradeCanvas(Vector3 pos, bool kk=false)
    {
        //GameObject.Instantiate(upgradeCanvas);
        upgradeCanvas.transform.position = pos+ new Vector3(0,1,0);
        upgradeCanvas.SetActive(true); 
        upgradeButton.interactable = !kk;
    }

    private void HideUpgradeCanvas()
    {
        upgradeCanvas.SetActive(false);

    }

    public void OnUpgradeButtonDown()
    {
        if (!mapCube.isUpgraded)
        {
            if (money >= selectedData.upgradeCost)
            {
                UpdateMoney(-selectedData.upgradeCost);
                mapCube.UpgradeTurret();
            }
            else
            {
                //提示钱不够
                moneyAnimator.SetTrigger("Flick");
            }
        }
        HideUpgradeCanvas();
    }

    public void OnDestroyButtonDown()
    {
        mapCube.DestroyTurret();
        HideUpgradeCanvas();
    }
}
