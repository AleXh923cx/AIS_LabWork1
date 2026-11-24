namespace Shared
{
    /// <summary>
    /// DTO персонажа: содержит идентификатор, имя, род/вид и возраст.
    /// Также предоставляет вычисляемый уровень персонажа.
    /// </summary>
    public class CharacterDto
    {
        private int _id;
        private string _name;
        private string _genus;
        private int _age;

        /// <summary>
        /// Максимальная допустимая длина имени персонажа.
        /// </summary>
        public const int NameMaxLength = 14;
        /// <summary>
        /// Максимальная допустимая длина названия вида персонажа.
        /// </summary>
        public const int GenusMaxLength = 12;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Имя</param>
        /// <param name="genus">Вид</param>
        /// <param name="age">Возраст</param>
        public CharacterDto(int id, string name, string genus, int age)
        {
            _id = id;
            _name = name;
            _genus = genus;
            _age = age;
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
        /// Вид персонажа
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
