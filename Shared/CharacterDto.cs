namespace Shared
{
    public class CharacterDto
    {
        private int _id;
        private string _name;
        private string _genus;
        private int _age;

        public const int NameMaxLength = 14;
        public const int GenusMaxLength = 12;

        public CharacterDto(int id, string name, string genus, int age)
        {
            _id = id;
            _name = name;
            _genus = genus;
            _age = age;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Genus
        {
            get => _genus;
            set => _genus = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public int Level => _age / 10;
    }
}
