using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
	public string name;
	public int score;

	public Score(string name, int score)
	{
		this.name = name;
		this.score = score;
	}
}

public class Leaderboard : MonoBehaviour {

	public LeaderboardEntry leaderboardEntryPrefab;
	List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

	static Score[] initialScores = new Score[] {
		new Score("MUZ", 5), 
		new Score("BBB", 175), 
		new Score("CCC", 200), 
		new Score("DDD", 225), 
		new Score("EEE", 250), 
		new Score("FFF", 275), 
		new Score("GGG", 300), 
		new Score("HHH", 325), 
		new Score("III", 350), 
		new Score("JJJ", 375) 
	};

	static public bool DoIQualify(int score)
	{
		bool qualify = false;
		List<Score> scores = LoadScores ();
		if (score < scores [scores.Count - 1].score) {
			qualify = true;
		}
		return qualify;
	}

	static public void AddScore(string name, int score)
	{
		List<Score> scores = LoadScores ();
		if (score < scores [scores.Count - 1].score) {
			scores.RemoveAt (scores.Count - 1);
			scores.Add (new Score (name, score));
			scores.Sort ((a, b) => a.score - b.score);
			SaveScores (scores);
		}
	}

	static List<Score> LoadScores()
	{
		List<Score> scores = new List<Score> ();
		for (int i = 0; i < initialScores.Length; i++) {
			string key = string.Format ("Rank{0}", i + 1);
			Score scoreEntry;
			if (PlayerPrefs.HasKey (key)) {
				string scoreString = PlayerPrefs.GetString (key);
				scoreEntry = JsonUtility.FromJson<Score> (scoreString);
			} else {
				scoreEntry = initialScores [i];
			}
			scores.Add (scoreEntry);
		}
		return scores;
	}

	static void SaveScores(List<Score> scores)
	{
		for (int i = 0; i < initialScores.Length; i++) {
			string key = string.Format ("Rank{0}", i + 1);
			PlayerPrefs.SetString (key, JsonUtility.ToJson (scores [i]));
		}
	}

	void OnEnable()
	{
		foreach (var score in LoadScores ()) {
			LeaderboardEntry entry = Instantiate (leaderboardEntryPrefab, transform);
			entry.initials.text = score.name;
			entry.slider.value = score.score;
			entries.Add (entry);
		}
	}

	void OnDisable()
	{
		foreach (var entry in entries) {
			Destroy (entry.gameObject);
		}
		entries.Clear ();
	}
}
