using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Pokedex.Model.PokeApi;

namespace Pokedex.Model
{

    public class PokemonDb : ObservableObject
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                SetProperty(ref _id, value, nameof(Id));
            }
        }

        private int _hp;
        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                SetProperty(ref _hp, value);
            }
        }

        private int _attack;
        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                SetProperty(ref _attack, value);
            }
        }

        private int _defense;
        public int Defense
        {
            get
            {
                return _defense;
            }
            set
            {
                SetProperty(ref _defense, value);
            }
        }

        private int _specialAttack;
        public int SpecialAttackense
        {
            get
            {
                return _specialAttack;
            }
            set
            {
                SetProperty(ref _specialAttack, value);
            }
        }

        private int _specialDefense;
        public int SpecialDefense
        {
            get
            {
                return _specialDefense;
            }
            set
            {
                SetProperty(ref _specialDefense, value);
            }
        }

        private int _speed;
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                SetProperty(ref _speed, value);
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value, nameof(Name));
            }
        }

        private int _height;
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                SetProperty(ref _height, value, nameof(Height));
            }
        }

        private int _weigth;
        public int Weight
        {
            get
            {
                return _weigth;
            }
            set
            {
                SetProperty(ref _weigth, value, nameof(Weight));
            }
        }

        private int _baseExperience;
        public int BaseExperience
        {
            get
            {
                return _baseExperience;
            }
            set
            {
                SetProperty(ref _baseExperience, value, nameof(BaseExperience));
            }
        }

        private string _abilitiesSlotOne;
        public string AbilitiesSlotOne
        {
            get
            {
                return _abilitiesSlotOne;
            }
            set
            {
                SetProperty(ref _abilitiesSlotOne, value);
            }
        }

        private string _abilitiesSlotTwo;
        public string AbilitiesSlotTwo
        {
            get
            {
                return _abilitiesSlotTwo;
            }
            set
            {
                SetProperty(ref _abilitiesSlotTwo, value);
            }
        }        

        private string _spritesFrontDefault;
        public string SpritesFrontDefault
        {
            get
            {
                return _spritesFrontDefault;
            }
            set
            {
                SetProperty(ref _spritesFrontDefault, value);
            }
        }

        private string _spritesOfficialArtwork;
        public string SpritesOfficialArtwork
        {
            get
            {
                return _spritesOfficialArtwork;
            }
            set
            {
                SetProperty(ref _spritesOfficialArtwork, value);
            }
        }

        private string _typeOne;
        public string TypeOne
        {
            get
            {
                return _typeOne;
            }
            set
            {
                SetProperty(ref _typeOne, value);
            }
        }

        private List<Moves> _moves;
        public List<Moves> Moves
        {
            get
            {
                return _moves;
            }
            set
            {
                SetProperty(ref _moves, value, nameof(Moves));
            }
        }                      
    }
}