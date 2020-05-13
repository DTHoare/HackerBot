using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableOnPlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventManager.StartListening ("PlayerDeath", enable);
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
