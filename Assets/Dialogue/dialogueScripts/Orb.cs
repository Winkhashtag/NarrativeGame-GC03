using UnityEngine;
using Yarn.Unity;
using System.Collections;

public class Orb : MonoBehaviour
{
    [YarnCommand("grow")]
   public IEnumerator Grow(float target, float time)
    {
       
        float initial = transform.localScale.x; //always scale equally

        float elapsed = 0f;
        while (elapsed < time)    //going from 0 to 1 during the duration of the while loop
        {
            //fins how mch percentage of the time has elapsed (0 -> 1)
            float elapsedPct = elapsed / time;
            //animate anything you want using elapsed percent (elaspedPct)
            //in this case move from initialScale to targetScale
            float currScale = Mathf.Lerp(1f, target, elapsedPct); //however much is left is however much we move to the target
            transform.localScale = currScale * Vector3.one;

            elapsed += Time.deltaTime; //how much time has passed between the frame being called
            yield return null;
        }
        transform.localScale = target * Vector3.one;
    
    }

    [YarnCommand("change_light")]
    public void ChangeLight(GameObject target) 
    {
        target.transform.position = transform.position + Random.onUnitSphere * 2f;
    }
}
