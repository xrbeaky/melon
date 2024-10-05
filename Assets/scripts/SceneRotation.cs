using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneRotation : MonoBehaviour
{
    [SerializeField] float maxDegrees = 15f;
    [SerializeField] float cycleTime = 5f;
    float time;
    float stateTime;

    RotationState state = RotationState.PosInc;

    private void Start()
    {
        time = 0;
        state = RotationState.PosInc;
        transform.localRotation = Quaternion.identity;
    }

    private void Update()
    {
        stateTime += Time.deltaTime;

        //Don't @ me
        switch (state)
        {
            case RotationState.PosInc:
                time += Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.SmoothStep(0, maxDegrees, time / cycleTime));
                if(stateTime >= cycleTime)
                {
                    stateTime = 0;
                    transform.localRotation = Quaternion.Euler(0f, 0f, maxDegrees);
                    state = RotationState.PosDec;      
                }
                break;
            case RotationState.PosDec:
                time -= Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.SmoothStep(0, maxDegrees, time / cycleTime));
                if (stateTime >= cycleTime)
                {
                    stateTime = 0;
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    state = RotationState.NegDec;
                }
                break;
            case RotationState.NegDec:
                time += Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.SmoothStep(0, maxDegrees, time / cycleTime));
                if (stateTime >= cycleTime)
                {
                    stateTime = 0;
                    transform.localRotation = Quaternion.Euler(0f, 0f, -maxDegrees);
                    state = RotationState.NegInc;
                }
                break;
            case RotationState.NegInc:
                time -= Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.SmoothStep(0, maxDegrees, time / cycleTime));
                if (stateTime >= cycleTime)
                {
                    stateTime = 0;
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    state = RotationState.PosInc;
                }
                break;
        }
    }
}

enum RotationState
{
    PosInc, PosDec, NegDec, NegInc
}