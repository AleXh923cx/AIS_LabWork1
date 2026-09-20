namespace Model
{
    public class Character
    {
        private string _name;
        private int _age;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        public Character(string name, int age)
        {
            Name = name;
            Age = age;
        }

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
