using AAMT;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class MoveAssetsToPersistentDataPath : MonoBehaviour
    {
        public Button moveButton;
        void Start()
        {
            if(moveButton) moveButton.onClick.AddListener(OnMoveAssets);
        }

        private void OnMoveAssets()
        {
            AAMTDefine.SetMoveFilesToPersistentComplete(false);
            var handler = AAMTManager.MoveBundles();
            handler.onProgress += OnProgress;
            handler.onComplete += OnComplete;
        }

        private void OnComplete(AsyncHandler obj)
        {
            Debug.Log("Move Complete");
        }

        private void OnProgress(AsyncHandler obj)
        {
            Debug.Log(obj.progress);
        }
    }
}
