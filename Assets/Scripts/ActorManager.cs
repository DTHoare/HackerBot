using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{

  public List<Actor> actors {get; private set;}

  private void Awake()
  {
    actors = new List<Actor>();
  }
}
