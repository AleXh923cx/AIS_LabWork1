namespace Model
{
    /// <summary>
    /// Класс персонажа, наследующий IDomainObject
    /// </summary>
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

        /// <summary>
        /// Идентификатор персонажа
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Имя персонажа
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Вид персонажа (это как класс персонажа)
        /// </summary>
        public string Genus
        {
            get => _genus;
            set => _genus = value;
        }

        /// <summary>
        /// Возраст персонажа
        /// </summary>
        public int Age
        {
            get => _age;
            set => _age = value;
        }

        /// <summary>
        /// Уровень персонажа (вычислительное свойство)
        /// </summary>
        public int Level => _age / 10;
    }
}
