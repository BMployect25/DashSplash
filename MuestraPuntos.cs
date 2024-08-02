using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuestraPuntos : MonoBehaviour
{
   [SerializeField] private Transform Origen;
   [SerializeField] private Transform Destino;

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.cyan;
    Gizmos.DrawSphere(Origen.position, 0.1f);
    Gizmos.DrawSphere(Destino.position, 0.1f);
  }
}

