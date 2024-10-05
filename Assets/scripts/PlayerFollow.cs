
using UnityEngine;

[ExecuteInEditMode]
public class PlayerFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    void Update()
    {
        //transform.position = new Vector3(0, offset.y, player.position.z + offset.z);

        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offset.z);
    }
}
