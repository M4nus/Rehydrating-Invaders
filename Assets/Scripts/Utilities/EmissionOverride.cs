using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EmissionOverride : MonoBehaviour
{
    [SerializeField]
    private Color color = new Color(0, 0, 0, 1);

    [SerializeField]
    private float intensity;

    private GlobalAssets asset;

#if UNITY_EDITOR
    void OnValidate()
    {
        SetMaterial();
        ChangeEmissiveColor();
    }
#endif

    private void Start()
    {
        SetMaterial();
        ChangeEmissiveColor();
    }

    void SetMaterial()
    {
        asset = Resources.Load<GlobalAssets>("Data/GlobalAssets");
        GetComponent<SpriteRenderer>().sharedMaterial = new Material(asset.emissive);
    }

    void ChangeEmissiveColor()
    {
        Material material = GetComponent<SpriteRenderer>().sharedMaterial;

        if(!material)
            return;

        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", color * intensity);
    }
}
