using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg : MonoBehaviour
{
    public EnemyAI enemyAI;
    public void DmgA()
    {
        enemyAI.AttackDamage();
    }
}
