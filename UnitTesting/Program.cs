namespace UnitTesting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameCharacterRepository gameCharacterRepository = new GameCharacterRepository();
            GameCharacterController gameCharacterController = new GameCharacterController(gameCharacterRepository);

            GameCharacter character1 = new GameCharacter("Adam", 20);
            GameCharacter character2 = new GameCharacter("Marcus", 50);
            GameCharacter character3 = new GameCharacter("John", 999);

            gameCharacterController.Save(character1);
            gameCharacterController.Save(character2);
            gameCharacterController.Save(character3);
            
            Console.WriteLine(gameCharacterController.Find("John"));
            Console.WriteLine(gameCharacterController.Delete("John"));
            Console.WriteLine(gameCharacterController.Save(new GameCharacter("Perseus", 10)));
        }
    }
}