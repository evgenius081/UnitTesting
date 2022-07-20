namespace UnitTesting
{
    public class GameCharacterController
    {
        private GameCharacterRepository _characterRepository;

        public GameCharacterController(GameCharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public virtual string Find(string name)
        {
            GameCharacter? foundOne = _characterRepository.FindByName(name);
            if (foundOne != null) return foundOne.ToString();
            return "Not found";
        }

        public string Delete(string name)
        {
            try
            {
                _characterRepository.DeleteByName(name);
                return "Game character successfully deleted";
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }

        public string Save(GameCharacter gc)
        {
            try
            {
                _characterRepository.Save(gc);
                return "Game character successfully saved";
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }
    }
}