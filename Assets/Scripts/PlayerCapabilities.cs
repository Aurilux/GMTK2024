using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCapabilities : MonoBehaviour {
    public bool _isJekyll = true;
    public int _numSerums = 0;

    private GameObject _jekyllObject;
    private GameObject _hydeObject;
    private Interactable _activeInteractable;

    void Start () {
        _jekyllObject = transform.GetChild(0).gameObject;
        _hydeObject = transform.GetChild(1).gameObject;
    }

    void Update() {
        bool interactionKeyPressed = Input.GetKeyDown(KeyCode.E);
        bool consumeSerumKeyPressed = Input.GetKeyDown(KeyCode.Q);

        bool abilityKeyPressed = interactionKeyPressed || consumeSerumKeyPressed;

        if (abilityKeyPressed) {
            if (_isJekyll) {
                if (consumeSerumKeyPressed && _numSerums > 0) {
                    _numSerums--;
                    ChangeCharacter();
                }
                if (interactionKeyPressed && _activeInteractable != null && _activeInteractable.isJekyllInteractable) {
                    _activeInteractable.onInteract();
                }
            }
            else { // !_isJekyll, aka isHyde
                if (interactionKeyPressed && _activeInteractable != null && _activeInteractable.isHydeInteractable) {
                    ChangeCharacter();
                }
            }
        }
    }

    private void ChangeCharacter() {
        if (_isJekyll) {
            _jekyllObject.SetActive(false);
            _hydeObject.SetActive(true);
            _jekyllObject.GetComponent<Animator>().SetBool("Switching", true);
        }
        else {
            _jekyllObject.SetActive(true);
            _hydeObject.SetActive(false);
            _hydeObject.GetComponent<Animator>().SetBool("Switching", true);
        }
        _isJekyll = !_isJekyll;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Interactable interactable = collider.gameObject.GetComponent<Interactable>();
        if (interactable != null) {
            _activeInteractable = interactable;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        _activeInteractable = null;
    }
}
