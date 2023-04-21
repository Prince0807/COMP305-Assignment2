using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Platform))]
public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Properties")]
    [Range(0.1f, 2f)]
    public float speed = 0.02f;
    public List<Transform> pathNodes;

    private int currentTargetIndex;

    private void Start()
    {
        if (pathNodes == null)
            Destroy(this);
        else
            currentTargetIndex = 0;
    }

    private void Update()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, pathNodes[currentTargetIndex].position)) < 0.1f)
            SetNextTargetPosition();

        transform.position = Vector2.LerpUnclamped(transform.position, pathNodes[currentTargetIndex].position, speed * Time.deltaTime);
    }

    private void SetNextTargetPosition()
    {
        currentTargetIndex++;
        if (currentTargetIndex >= pathNodes.Count)
            currentTargetIndex = 0;
    }
}
