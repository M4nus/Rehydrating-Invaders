#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[RequireComponent(typeof(SpriteRenderer))]
public class EmissionOverride : MonoBehaviour
{
    [SerializeField]
    private Color color = new Color(0, 0, 0, 1);

    [SerializeField]
    private float intensity;

    private GlobalAssets asset;

    void OnValidate()
    {
        SetMaterial();
        ChangeEmissiveColor();
    }

    void SetMaterial()
    {

        asset = UnityEditor.AssetDatabase.FindAssets("t:GlobalAssets", new[] { "Assets/Data" })
                                         .Select(UnityEditor.AssetDatabase.GUIDToAssetPath)
                                         .Select(UnityEditor.AssetDatabase.LoadAssetAtPath<GlobalAssets>).First();
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
#endif
