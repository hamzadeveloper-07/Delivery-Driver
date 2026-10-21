using UnityEngine;

public class Delivery : MonoBehaviour
{
   [SerializeField] Color32 hasPackageColor = new Color32 (1,0,0,1);
   [SerializeField] Color32 noPackageColor = new Color32(0,0,0,1);

   SpriteRenderer spriteRenderer;
   void Start() {
      spriteRenderer = GetComponent<SpriteRenderer>();
   }
   [SerializeField] float destroyDelay = 0.5f;
   bool hasPackage = false;
   void OnCollisionEnter2D(Collision2D other)
   {
      Debug.Log("Collision occured!");
   }
   
   void OnTriggerEnter2D(Collider2D other) {
     if(other.tag == "Package" && hasPackage == false)
      {
         Debug.Log("Package picked up!");
         hasPackage = true;
         Destroy(other.gameObject,destroyDelay);
         spriteRenderer.color = hasPackageColor;
      }
      if(other.tag == "Customer" && hasPackage)
      {
         Debug.Log("Package Delivered!");
         hasPackage = false;  
         spriteRenderer.color = noPackageColor;    
      } 
   }
}
