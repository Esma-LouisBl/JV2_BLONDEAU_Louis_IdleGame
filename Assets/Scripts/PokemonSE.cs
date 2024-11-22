using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPokemon", menuName = "Pokemon", order =0)]

public class PokemonSE : ScriptableObject
{
    public string pokemonName;
    public Sprite sprite;
    public int totalHp;
    public int atq;
}
