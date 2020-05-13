using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
  public int enemiesToKill;
  private int enemiesKilled = 0;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening ("EnemyDeath", enemyKilled);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void enemyKilled()
    {
      enemiesKilled++;
      if(enemiesKilled >= enemiesToKill)
      {
        EventManager.TriggerEvent ("Victory");
      }
    }
}
