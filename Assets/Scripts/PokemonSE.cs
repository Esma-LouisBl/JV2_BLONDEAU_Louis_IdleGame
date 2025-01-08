using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPokemon", menuName = "Pokemon", order =0)]

public class PokemonSE : ScriptableObject
{
    public string pokemonName;
    public Sprite sprite;
    public AudioClip cry;
    public PokemonType type1;
    public PokemonType type2;
    public int totalHp;
    public int atq;
    public float cooldown;
    public int catchRate;
    public int moneyDrop;
    public int rarity;
}
