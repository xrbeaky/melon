using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneRotation : MonoBehaviour
{

    [SerializeField] float maxDegrees = 15f;
    [SerializeField] float cycleTime = 5f;
    float time;

    RotationState state = RotationState.PosInc;

    private void Start()
    {
        time = 0;
        state = RotationState.PosInc;
    }

    private void Update()
    {
        switch (state)
        {
            case RotationState.PosInc:
                time += Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0, maxDegrees, time / cycleTime));
                break;
            case RotationState.PosDec:
                time -= Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0, maxDegrees, time / cycleTime));
                break;
            case RotationState.NegDec:
                time -= Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0, maxDegrees, time / cycleTime));
                break;
            case RotationState.NegInc:
                time += Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(0, maxDegrees, time / cycleTime));
                break;
        }
    }
}

enum RotationState
{
    PosInc, PosDec, NegDec, NegInc
}