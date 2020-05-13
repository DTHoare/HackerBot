using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableOnVictory : MonoBehaviour
{
  // Start is called before the first frame update
  void Awake()
  {
      EventManager.StartListening ("Victory", enable);
      gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {

  }

  void enable()
  {
    gameObject.SetActive(true);
  }
}
