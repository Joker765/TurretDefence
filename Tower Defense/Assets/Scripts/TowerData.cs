using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TowerData  {
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpdatePrefab;
    public int upgradeCost;
    public TurretType type;

}

public enum TurretType
{
    LaserTurret,
    MissileTurret,
    StandardTurret
}
