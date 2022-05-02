using System.Collections;
using UnityEngine;

public class GraphicsManager : SingletonPersistant<GraphicsManager>
{
    public GlobalAssets globalAssets;

    public float currentWaterAmount;
    public float currentWaterThreshold;
    public float waterPerHit = 0.1f;

    private void Start()
    {
        globalAssets.earthMaterial.SetFloat("_WaterAmount", 0);
        currentWaterAmount = 0f;
        currentWaterThreshold = 0f;
    }

    public IEnumerator AddWater()
    {
        if(currentWaterThreshold + waterPerHit > 1f)
        {
            foreach(Alien alien in AliensManager.Instance.aliens)
            {
                alien.transform.GetChild(1).gameObject.SetActive(true);
                StartCoroutine(AliensManager.Instance.TeleportAlien(alien.transform));
                StartCoroutine(AliensManager.Instance.ChangeScene());
            }
            yield return null;
        }

        currentWaterAmount = globalAssets.earthMaterial.GetFloat("_WaterAmount");
        currentWaterThreshold = currentWaterAmount + waterPerHit;

        while(currentWaterAmount <= currentWaterThreshold)
        {
            float waterLerp = Time.deltaTime * 0.001f;
            currentWaterAmount += waterLerp;
            globalAssets.earthMaterial.SetFloat("_WaterAmount", currentWaterAmount);
        }
    }
}
