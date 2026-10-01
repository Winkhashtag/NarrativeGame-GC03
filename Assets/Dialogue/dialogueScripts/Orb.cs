using UnityEngine;
using Yarn.Unity;
using System.Collections;

public class Orb : MonoBehaviour
{
    [YarnCommand("grow")]
   public IEnumerator Grow(float target, float time)
    {
        Vector3 targetScale = target * Vector3.one;
        float elapsed = 0f;
        while (elapsed < time)    //going from 0 to 1 during the duration of the while loop
        {
            float elapsedPct = elapsed / time;
            //animate anything you want using elapsed percent (elaspedPct)
            Vector3 currScale = Mathf.Lerp(1f, target, elapsedPct) * Vector3.one; //however much is left is however much we move to the target
            transform.localScale = elapsedPct * targetScale;

            elapsed += Time.deltaTime; //how much time has passed between the frame being called
            yield return null;
        }
        transform.localScale = targetScale;
    
    }

    [YarnCommand("change_light")]
    public void ChangeLight(GameObject target) 
    {
        target.transform.position = transform.position + Random.onUnitSphere * 2f;
    }
}
