using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Start() 
    {
        Resize();
    }

    void Update() 
    {
        offset += moveSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }

    void Resize()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 newScale = transform.localScale;
        newScale.x = worldScreenWidth / width;
        newScale.y = worldScreenHeight / height;
        
        newScale *= 1.1f; 

        transform.localScale = newScale;

        if (material != null)
        {
            material.mainTextureScale = new Vector2(newScale.x, newScale.y);
        }
    }

}
