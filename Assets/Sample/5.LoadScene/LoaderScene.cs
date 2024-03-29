using AAMT;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class LoaderScene : MonoBehaviour
    {
        public Button loaderButton;

        void Start()
        {
            loaderButton.onClick.AddListener(onLoadScene);
        }

        private void onLoadScene()
        {
            var path = "Sample/Res/Scenes/TestScene1.unity";
            AAMTManager.LoadScene(path, () => { Debug.Log("Load Scene Complete!!"); });
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}