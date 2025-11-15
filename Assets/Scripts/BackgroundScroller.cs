using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    void Start() 
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update() 
    {
        offset += moveSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }

}
