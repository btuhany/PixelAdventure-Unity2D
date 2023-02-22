using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    public class InteractHandler : MonoBehaviour
    {

        GameObject _currentInteractableObject;
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("InteractableObject"))
            {
                _currentInteractableObject = collision.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {

            _currentInteractableObject = null;
        }

        public void Interact()
        {
            if (_currentInteractableObject != null)
            {
                _currentInteractableObject.gameObject.GetComponent<LeverController>().LeverInteraction();
            }
        }
    }

}
