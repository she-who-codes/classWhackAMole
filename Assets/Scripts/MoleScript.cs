using System.Collections;
using UnityEngine;

public class MoleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosition);

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == this.gameObject)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    GameManager.Instance._OnClickedMole();
                    collider.enabled = false;
                    StartCoroutine(resetRoutine()); 
                    break;
                }
            }
        }
    }

    IEnumerator resetRoutine() 
    {
        yield return new WaitForSeconds(1);
        resetMole();
    }
    public void resetMole() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<CircleCollider2D>().enabled = true;
        gameObject.SetActive(false);
    }
}
