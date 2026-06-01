using UnityEngine;

namespace Objects
{
    public class InteractSwitch : MonoBehaviour
    {
        [SerializeField] private GameObject _enableObject;

        public void Switch()
        {
            if (_enableObject) _enableObject.SetActive(true);
            
            gameObject.SetActive(false);
        }

        public void Reset()
        {
            if (_enableObject) _enableObject.SetActive(false);
            
            gameObject.SetActive(true);
        }
    }
}