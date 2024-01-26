using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour{
    public int playerScore = 0;
    
    void FixedUpdate() { 
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = worldPosition - transform.position;

        float parentScaleX = transform.parent.localScale.x;
        if (parentScaleX < 0) {
            direction.x = -direction.x; // Invert the direction when the parent is flipped
            direction.y = -direction.y;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -110, 110);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }


    private void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Enemy") && Input.GetMouseButtonDown(0)){
            Destroy(collision.gameObject,0.2f);
            playerScore += 1;
        }
    }
}