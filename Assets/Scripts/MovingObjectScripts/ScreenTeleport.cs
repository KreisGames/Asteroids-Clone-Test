using UnityEngine;

namespace MovingObjectScripts
{
    public class ScreenTeleport : MonoBehaviour
    {

        private Camera _mainCamera;
        private Transform _transform;
        
        private void Awake()
        {
            _transform = transform;
            
            //Stop debugger if no main camera detected
            if (Camera.main != null)
            {
                _mainCamera = Camera.main;
            }
            else
            {
                Debug.LogError("No Main Camera found!");
                Debug.Break();
            }
        }

        //Teleport object then it leaves screen
        private void OnBecameInvisible()
        {
            if (_mainCamera == null) return;
            var offscreenPosition = transform.position;
            var viewportXPos = _mainCamera.WorldToViewportPoint(offscreenPosition).x;
            var viewportYPos = _mainCamera.WorldToViewportPoint(offscreenPosition).y;
            
            //Revert object position, putting it little closer to center than actual border
            if (viewportXPos <= 0)
                viewportXPos = 0.99f;
            else if (viewportXPos >= 1)
                viewportXPos = 0.01f;

            if (viewportYPos <= 0)
                viewportYPos = 0.99f;
            else if (viewportYPos >= 1)
                viewportYPos = 0.01f;
            
            //Move object to new position
            _transform.position = _mainCamera.ViewportToWorldPoint(new Vector3(viewportXPos, viewportYPos,
                _mainCamera.WorldToViewportPoint(offscreenPosition).z));
        }
        
    }
}
