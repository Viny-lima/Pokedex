using System;

namespace Pokedex.Model.Entities
{
    public abstract class AttributesDB
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            AttributesDB attribute = (AttributesDB) obj;

            return Name.Equals(attribute.Name) && Id.Equals(attribute.Id);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Id, Name).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }




    }
}
