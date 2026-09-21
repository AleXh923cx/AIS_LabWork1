namespace Model
{
    public class Character
    {
        private int _id;
        private string _name;
        private int _age;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        public Character(int id, string name, int age)
        {
            _id = id;
            Name = name;
            Age = age;
        }

        public int Id { get { return _id; } }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int Level => _age / 10;
    }
}
