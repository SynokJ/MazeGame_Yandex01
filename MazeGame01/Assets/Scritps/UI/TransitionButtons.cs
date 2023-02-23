public class TransitionButtons : UnityEngine.MonoBehaviour
{
    private const string _MAIN_MENU_SCENE_NAME = "MazeGeneration";
    private const string _SHOP_SCENE_NAME = "GameShop";

    public void OnMenuButtonClicked() => UnityEngine.SceneManagement.SceneManager.LoadScene(_MAIN_MENU_SCENE_NAME);
    public void OnShopButtonClicked() => UnityEngine.SceneManagement.SceneManager.LoadScene(_SHOP_SCENE_NAME);
}
