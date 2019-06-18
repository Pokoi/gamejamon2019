using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_manager : MonoBehaviour
{
    public Text winner_text;
    public Canvas game_canvas;
    public Canvas game_end_canvas;
    public Player_manager player_one;
    public Player_manager player_two;
    public Text remaining_time;
    public int game_duration_in_seconds;
    private float remaining_seconds;

    private bool is_player_one_winner;

    public enum GamePhases { playing, finished }
    public GamePhases current_game_phase;

    // Start is called before the first frame update
    void Start() { current_game_phase = GamePhases.playing; remaining_seconds = game_duration_in_seconds; }

    // Update is called once per frame
    void Update()
    {
        if (current_game_phase == GamePhases.playing) {
            remaining_seconds -= Time.deltaTime;
            int minutes = (int)remaining_seconds / 60;
            int seconds = (int)remaining_seconds % 60;
            remaining_time.text = minutes < 10 ? "0" : "";
            remaining_time.text += ":";
            remaining_time.text += seconds < 10 ? "0" : "";
            remaining_time.text += seconds;

            if (remaining_seconds <= 0) OnGameEnds(CheckWinner());
        }
    }

    /// <summary>
    /// Determina si estamos jugando
    /// </summary>
    /// <returns></returns>
    public bool isPlaying()
    {
        return current_game_phase == GamePhases.playing;
    }

    /// <summary>
    /// Reloads the scene
    /// </summary>
    public void ReloadGame() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    /// <summary>
    /// When the game is finished, this method is called
    /// </summary>
    public void OnGameEnds(int _winner_points)
    {
        current_game_phase = GamePhases.finished;
        game_canvas.gameObject.SetActive(false);
        winner_text.text = is_player_one_winner ? "Player one wins with " : "Player two wins with ";
        winner_text.text += _winner_points.ToString() + " points.";
        game_end_canvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// Check which player is the winner of the match and returns his points
    /// </summary>
    /// <returns></returns>
    public int CheckWinner() { is_player_one_winner = player_one.drinked_glasses > player_two.drinked_glasses; return is_player_one_winner ? player_one.drinked_glasses : player_two.drinked_glasses; }
}
