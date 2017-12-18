using UnityEngine;
using forge.Iron;

namespace forge.hammer
{
  public class HammerManager : MonoBehaviour
  {

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.impulse.sqrMagnitude >= 5)
      {
        GameObject hited=collision.gameObject;
        if (hited.tag=="Iron")
        {
          hited.GetComponent<IronManager>().Upgrade();
        }

      }
    }
  }
}