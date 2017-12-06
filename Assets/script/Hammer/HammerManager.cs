using UnityEngine;
using forge.Iron;

namespace forge.hammer
{
  public class HammerManager : MonoBehaviour
  {
    
    private Rigidbody rigidBody;

    void Start()
    {
      rigidBody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
      if (collision.impulse.sqrMagnitude >= 100)
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