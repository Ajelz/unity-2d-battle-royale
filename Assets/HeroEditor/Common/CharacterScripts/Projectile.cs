using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.HeroEditor.Common.CharacterScripts
{
    /// <summary>
    /// General behaviour for projectiles: bullets, rockets and other.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        public List<Renderer> Renderers;
        public GameObject Trail;
        public GameObject Impact;
	    public Rigidbody2D myRigidbody;

        public void Start()
        {
            Destroy(gameObject, 5);
        }
	    public void Update()
	    {
		   if (myRigidbody != null)
		   {
                transform.right = myRigidbody.velocity.normalized;
                transform.Translate(Vector2.right.normalized * 0.4f); //edit the multiplied number to control bullet speed (recommended (0.1f-0.05f)
            }
	    }

        //BULLET COLLISION DAMAGE
        public void OnTriggerEnter2D(Collider2D other)
        {
            Vector3 bulletDir = this.gameObject.transform.forward;
            bulletDir.y = 0;
            float force = 500;

            other.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * force);
            Bang(other.gameObject);
            if (other.gameObject.CompareTag("Object"))
            {
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
            }
            if (other.gameObject.CompareTag("Player"))
            {
                userHeadPanel myUserHeadPanel = other.GetComponent<userHeadPanel>();
                userHealthbar myUserHealthbar = other.GetComponent<userHealthbar>();
                myUserHeadPanel.TriggerHeadPanel();
            }
            //print("banged yes?" + other.gameObject);
        }

     // public void OnCollisionEnter2D(Collision2D other)
     // {
     //     Bang(other.gameObject); //DISABLED CUZ NOT NEEDED
     // }

        private void Bang(GameObject other)
        {
            ReplaceImpactSound(other);
            Impact.SetActive(true);
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 1);

            foreach (var ps in Trail.GetComponentsInChildren<ParticleSystem>())
            {
                ps.Stop();
            }

	        foreach (var tr in Trail.GetComponentsInChildren<TrailRenderer>())
	        {
		        tr.enabled = false;
			}
		}

        private void ReplaceImpactSound(GameObject other)
        {
            var sound = other.GetComponent<AudioSource>();

            if (sound != null && sound.clip != null)
            {
                Impact.GetComponent<AudioSource>().clip = sound.clip;
            }
        }
    }
}