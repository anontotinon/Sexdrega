using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    //public GameObject player;
    private bool focusThis;

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);    
        
    }

    //look if obj is close to player.
    void AddToInteractable()
    {
        var x = InteractionManager.instance;
        x.interactableObjects.Add(this);
    }

    public virtual void Interact()
    {
       // Debug.Log(this.transform.parent.gameObject);
        Debug.Log(this.gameObject);
    }
    
}
