using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisionBehaviour : MonoBehaviour
{
    private const float VisionAngle = 90f, Half = 2f;
    public bool IsInVision(GameObject player)
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        // Si el jugador está dentro del ángulo de visión
        if (angleToPlayer <= VisionAngle / Half)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit))
            {
                if (hit.collider.CompareTag(player.tag))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
