namespace Homewark_Classs
{
    public class Weapon
    {
        //Variables
        private string _name;
        private float _damage;
        private float _minDamage;
        private float _maxDamage;

        //Properties
        public string Name { get => _name; }
        public float Damage { get => _damage; }
        private float MinDamage { set => _minDamage = value; }
        private float MaxDamage { set => _maxDamage = value; }

        //Constructor
        public Weapon()
        {
            _name = "Great Sward";
        }

        //1.1 Со строковым аргументом - устанавливает значение строки в свойство Name;
        public Weapon(string name)
        {
            _name = name;
        }

        //1.2 Со строковым аргументом и двумя числами типа float. Первое число - minDamage, второе - maxDamage;
        //1.3 Конструктор с тремя аргументами должен вызывать конструктор с одним аргументом через ключевое слово this
        //и передавать в него имя оружия;
        public Weapon(string name, float x, float y) : this(name)
        {
            //1.4 Конструктор с тремя аргументами должен вызывать в теле метод SetDamageParams;
            SetDamageParams(x, y);
        }

        //Methods
        //2
        public void SetDamageParams(float x, float y)
        {
            //2.3 Внутри метода должна проверяться допустимость входных значений.
            //Если minDamage больше maxDamage - числа меняются местами,
            //а в консоль выводится сообщение о некорректных входных данных (с указанием имени оружия);
            if (x > y) 
            {
                MinDamage = y;
                MaxDamage = x;
                Console.WriteLine("Incorrect incoming atributs for weapon " + Name);
            }
            else
            {
                MinDamage = x;
                MaxDamage = y;
            }

            //2.4 Если minDamage меньше 1f, минимальный урон оружия задается значением 1f,
            //а в консоль выводится сообщение о форсированной установки минимального значения;
            if (_minDamage < 1f)
            {
                MinDamage = 1f;
                Console.WriteLine("Minimal damage les then 1. It setuped to 1");
            }

            //2.5 Если maxDamage меньше или равен 1f, то устанавливаем значение 10f;
            if (_maxDamage < 1f)
            {
                MaxDamage = 10f;
            }
        }

        //3. Вернуть урон (GetDamage):
        public float GetDamage()
        {
            //3.2 Возвращает число типа float, рассчитываемое, как среднее арифметическое между MinDamage и MaxDamage;
            _damage = (_minDamage + _maxDamage) / 2;
            return _damage;
        }
    }  
}
