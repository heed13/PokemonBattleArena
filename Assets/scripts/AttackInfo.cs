public struct AttackInfo 
{	
	public AttackInfo(int teamId, pokemonType type, float dmg, PokemonInfo pokemon, PlayerInfo player, System.Action<HitInfo> hitcallback, System.Action<HitInfo> killcallback)
	{
		this.teamId = teamId;
		this.type = type;
		this.damage = dmg;
		this.pokemon = pokemon;
		this.player = player;
		this.hitCallback = hitcallback;
		this.killCallback = killcallback;
	}
	public int teamId;
	public pokemonType type; // elemental type of the attack
	public float damage; // amount of damage to apply to whoever is hit

	public PokemonInfo pokemon; // the pokemon attacking
	public PlayerInfo player; // the player attacking

	public System.Action<HitInfo> hitCallback; // function to call if this hits something
	public System.Action<HitInfo> killCallback; // function to call if this kills something
}
