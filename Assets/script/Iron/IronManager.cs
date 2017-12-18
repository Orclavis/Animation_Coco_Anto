using UnityEngine;

namespace forge.Iron
{
    public class IronManager : MonoBehaviour, IIronManager
    {


        private int nbCoup = 0;
        private GameObject anvil = null;
        private Renderer rend;
        private Color orange;
        private GameObject sword;

        void Start()
        {
            rend = GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.red);
            orange = new Color(1F, 165.0f/255.0f, 0F);
            sword = GameObject.Find("sword");
        }


        public void Upgrade()
        {
            if (anvil)
            {
                if (nbCoup == 0)
                    rend.material.SetColor("_Color", orange);
                if (nbCoup == 1)
                    rend.material.SetColor("_Color",Color.yellow);
                if (nbCoup == 2)
                {
                    sword.transform.position = transform.position+new Vector3(0.8f,0,0);
                    Destroy(gameObject);
                }
                    
                
                nbCoup++;

            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (!anvil && collision.gameObject.tag == "Anvil")
                anvil = collision.gameObject;
        }

        public void OnCollisionExit(Collision collision)
        {
            if (anvil && collision.gameObject.tag == "Anvil")
                anvil = null;
        }
    }
}