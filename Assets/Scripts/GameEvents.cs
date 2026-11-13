using System;

public static class GameEvents
{
	public static event Action OnPlayerDie;

	public static void PlayerDie()
	{
        OnPlayerDie?.Invoke();
	}
}

