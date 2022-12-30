using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Maze Components: ")]
    [SerializeField] private GameObject _wallPref;
    [SerializeField] private GameObject _wallParent;

    private const float _MAZE_SCALE = 5.0f;

    private Maze _maze;


    private void Start()
    {
        GenerateMazeBasic();
        GenerateRandomPaths();
    }

    public void GenerateMazeBasic()
    {
        _maze = new Maze();
        _maze.InitData(_wallPref, _wallParent.transform);

        _wallParent.transform.localScale *= _MAZE_SCALE;
    }

    public void GenerateRandomPaths()
    {
        _maze.SetRandomPath();
    }

    public void DestroyMaze()
    {
        _maze.ClearMaze();
    }
}
