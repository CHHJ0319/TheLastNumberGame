using UnityEngine.SceneManagement;

namespace Algorythm 
{
    public static class SceneLoader
    {
        public static void LoadSceneByName(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}