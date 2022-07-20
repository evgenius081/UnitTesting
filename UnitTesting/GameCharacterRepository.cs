namespace UnitTesting
{
    public class GameCharacterRepository
    {
        private HashSet<GameCharacter> _gameCharacters;

        public GameCharacterRepository()
        {
            _gameCharacters = new HashSet<GameCharacter>();
        }

        public virtual GameCharacter? FindByName(string name)
        {
            foreach (var gameCharacter in _gameCharacters)
            {
                if (gameCharacter.Name.Equals(name))
                {
                    return gameCharacter;
                }
            }
            return null;
        }

        public virtual void DeleteByName(string name)
        {
            if (_gameCharacters.Count == 0 || !_gameCharacters.Remove(FindByName(name)!))
            {
                throw new ArgumentException("Not found");
            }
        }

        public virtual void Save(GameCharacter gc)
        {
            Console.WriteLine(gc);
            if (!_gameCharacters.Add(gc))
            {
                throw new ArgumentException("Already exists");
            }
        }
    }
}