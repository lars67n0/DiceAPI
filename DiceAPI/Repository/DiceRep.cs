using DiceLib;

namespace DiceAPI.Repository
{
    public class DiceRep
    {
        
        private int _nextId;

        private List<Dice> _dice;

        public DiceRep()
        {
            _nextId = 1;
            _dice = new List<Dice>()
            {
                new Dice() { Id = _nextId++, Color = "Black", SideAmount = 5 },
                new Dice() { Id = _nextId++, Color = "Green", SideAmount = 18 },
                new Dice() { Id = _nextId++, Color = "Red", SideAmount = 12 },
                new Dice() { Id = _nextId++, Color = "Yellow", SideAmount = 9 },
                new Dice() { Id = _nextId++, Color = "Red", SideAmount = 16 }

            };
        }
        

        // Methods

        // Get All Method
        public List<Dice> GetAll() { return new List<Dice>(_dice); }

        // Get By Id Method
        public Dice? GetById(int Id) { return _dice.Find(d => d.Id == Id); }

        // Create New Method
        public Dice Add(Dice newDice)
        {
            newDice.SideVal();
            newDice.ColorVal();
            newDice.Id = _nextId++;
            _dice.Add(newDice);
            return newDice;
        }

        // Update Method

        public Dice? Update(int Id, Dice Updated)
        {
            Updated.SideVal();
            Updated.ColorVal();
            Dice? DiceToUpdate = GetById(Id);
            if (DiceToUpdate == null) { return null; }
            DiceToUpdate.Color = Updated.Color;
            DiceToUpdate.SideAmount = Updated.SideAmount;
            return DiceToUpdate;
        }


    }
}
