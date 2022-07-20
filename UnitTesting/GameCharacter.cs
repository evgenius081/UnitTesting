namespace UnitTesting
{
    public class GameCharacter
    {
        private readonly string _name;
        private readonly int _level;
        public string Name => _name;
        public int Level => _level;

        public GameCharacter(string name, int level){
            _name = name;
            _level = level;
        }
        
        public override string ToString()
        {
            return $"GameCharacter[{Name}, level:{Level}]";
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (GetType() != obj?.GetType()) return false;
            GameCharacter gc = (GameCharacter) obj;
            return gc.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _level);
        }
    }
}