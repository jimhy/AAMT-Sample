using AAMT;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class LoadPrefab : MonoBehaviour
    {
        public Button LoadButton;
        public Button ReleaseButton;
        public Transform PrefabLayer;
        private string[] prefabBundlePathList;

        void Start()
        {
            //====================================
            // 前期工作:重要!重要!重要!
            // 1.点击Editor工具栏AAMT->MainWindow面板->运行按钮
            // 2.当前平台类型选择为windows
            // 3.运行游戏即可加载streamingAssets路径的bundle文件
            //====================================
            prefabBundlePathList = new[]
            {
                "Sample/Res/Prefabs/Capsule.prefab", //注意:这里需要Assets目录下的全路径，包含扩展名
                "Sample/Res/Prefabs/Sphere.prefab"
            };
            if (LoadButton != null) LoadButton.onClick.AddListener(onLoad);
            if (ReleaseButton != null) ReleaseButton.onClick.AddListener(onRelease);
        }

        private void onLoad()
        {
            AAMTManager.GetAssetsAsync<GameObject>(prefabBundlePathList, (go) =>
            {
                var x = Random.Range(-5, 5);
                var z = Random.Range(-5, 5);
                if (go != null) Instantiate(go, new Vector3(x, 0, z), Quaternion.identity, PrefabLayer);
            });
        }

        private void onRelease()
        {
            AAMTManager.Release(prefabBundlePathList);
            //这里如果在项目中应该还要调用在场景中的gameObject的Destroy接口
            //这里故意不这样做，是要让大家看清楚bundle包在内存中被销毁的情况，会变成分红色，表示bundle包资源已经被释放掉了。
        }

        void Update()
        {
        }
    }
}