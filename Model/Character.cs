namespace Model
{
    public class Character : IDomainObject
    {
        private int _id;
        private string _name;
        private string _genus;
        private int _age;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Имя</param>
        /// <param name="genus">Вид</param>
        /// <param name="age">Возраст</param>
        public Character(int id, string name, string genus, int age)
        {
            _id = id;
            Name = name;
            Genus = genus;
            Age = age;
        }

        public int Id { get { return _id; } }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Genus // Это как класс персонажа
        {
            get { return _genus; }
            set { _genus = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int Level => _age / 10;
    }
}
