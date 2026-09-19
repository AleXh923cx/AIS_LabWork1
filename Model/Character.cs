namespace Model
{
    public class Character
    {
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int Level => _age / 10;
    }
}
