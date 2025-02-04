using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class ButtonController : MonoBehaviour
    {
        public void LoadLevelString(string levelName)
        {
            CanvasFader.Instance.FaderLoadString(levelName);
        }

        public void LoadLevelInt(int index)
        {
            CanvasFader.Instance.FaderLoadInt(index);
        }

        public void RestartLevel()
        {
            CanvasFader.Instance.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
