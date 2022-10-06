using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
     [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
     [SerializeField] Color32 hasNoPackageColor = new Color32(1, 1, 1, 1);

     [SerializeField] float destroyTimer = 0.5f;
     bool hasPackage = false;

     SpriteRenderer spriteRenderer;

     void Start()
     {
          spriteRenderer = GetComponent<SpriteRenderer>();
     }

     void OnCollisionEnter2D(Collision2D other)
     {
          Debug.Log("collided");
     }

     void OnTriggerEnter2D(Collider2D other)
     {
          if(other.tag == "Package" && !hasPackage)
          {
               Debug.Log("picked up");
               hasPackage = true;
               spriteRenderer.color = hasPackageColor;
               Destroy(other.gameObject, destroyTimer);
          }
          if(other.tag == "Customer" && hasPackage == true)
          {
               Debug.Log("Delivered");
               hasPackage = false;
               spriteRenderer.color = hasNoPackageColor;
          }
     }
}
