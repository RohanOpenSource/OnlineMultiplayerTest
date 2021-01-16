using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerSetup : NetworkBehaviour
{
  [SerializeField]
Behaviour[] componentsToDisable;

Camera SceneCamera;


void Start ()
{
  if(!isLocalPlayer){
    DisableComponents();
  }
  else{
    SceneCamera=Camera.main;
    if(SceneCamera != null){
      SceneCamera.gameObject.SetActive(false);
    }
  }


}
void OnDisable(){
  if(SceneCamera != null){
    SceneCamera.gameObject.SetActive(true);

  }

}


void DisableComponents ()
{
  for (int i = 0; i < componentsToDisable.Length; i++)
  {
    componentsToDisable[i].enabled = false;
  }
}

}
