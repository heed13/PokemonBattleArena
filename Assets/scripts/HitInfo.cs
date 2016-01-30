
public struct HitInfo 
{	
	public HitInfo(float dmg, float weakDmg, float resistBlock, bool isDead, float xp, PokemonInfo pokemon, PlayerInfo player)
	{
		this.totalDmgDealt = dmg;
		this.weaknessDmg = weakDmg;
		this.resistantLoss = resistBlock;
		this.killed = isDead;
		this.xpGiven = xp;
		this.pokemon = pokemon;
		this.player = player;
	}

	public float totalDmgDealt; // Total amount of dmg given
	public float weaknessDmg; // Amount of damage that came from weakness
	public float resistantLoss; // Amount of damage lost from a resistance
	public bool killed; // If the pokemon was killed
	public float xpGiven;
	public PokemonInfo pokemon; // The pokemon that was hit
	public PlayerInfo player; // The player that was hit
}
