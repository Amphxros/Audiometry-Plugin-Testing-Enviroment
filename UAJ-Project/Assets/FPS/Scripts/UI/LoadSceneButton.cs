using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Unity.FPS.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        public string SceneName = "";
        public bool AudiometryEnabled = true;

        void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject
                && Input.GetButtonDown(GameConstants.k_ButtonNameSubmit))
            {
                
                LoadTargetScene();
            }
        }

        public void LoadTargetScene()
        {
            if (AudiometryEnabled) SceneName = "HearingTest";

            SceneManager.LoadScene(SceneName);
        }
    }
}