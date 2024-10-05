
using UnityEngine;

[ExecuteInEditMode]
public class followPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(0, offset.y, player.position.z + offset.z);
    }
}
