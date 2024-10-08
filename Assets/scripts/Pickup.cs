using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("player interact");
            GameManager.instance.SaveCivilian();
            Destroy(gameObject);
        }
    }
}