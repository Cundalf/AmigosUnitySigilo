using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Range(0, 360)] public float visAngle ;
    [Range(0, 15)] public float  visDist;
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visDist);
    }
}
