using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tazer : MonoBehaviour
{
    public float range = 20f;
    public Camera FPScamera;
    public bool PuedeTirar;
    private float temporizador;
    public float TiempoEntreTiros;

    public ParticleSystem tazerRay;

    void Update()
    {

        if (!PuedeTirar)
        {
            temporizador += Time.deltaTime;
            if (temporizador > TiempoEntreTiros)
            {
                PuedeTirar = true;
                temporizador = 0;
            }
        }

        if (Input.GetButtonDown("Fire1") && PuedeTirar==true)
        {
            Shoot();
            PuedeTirar = false;
            
        }
    }
    void Shoot ()
	{
        tazerRay.Play();
        RaycastHit hit;
        if (Physics.Raycast(FPScamera.transform.position, FPScamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            follower follower = hit.transform.GetComponent<follower>();
            if (follower != null)
            {
                
                follower.stuned = true;
            }
        }
	}

  
}
