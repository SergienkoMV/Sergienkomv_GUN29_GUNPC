namespace Homewark_Classs
{
    public class Helm
    {
        private string _name = "Helm";
        private float _armorValue = 0.1f;

        //1.2 Свойство только для чтения;
        public string Name { get { return _name; } }

        //2. Показатель брони (Armor):
        public float Аrmor
        {
            get
            {
                return _armorValue;
            }
            set
            {
                if (value < 0)
                {
                    _armorValue = 0;
                    Console.WriteLine("Incorret armor value");
                }
                else if (value > 1)
                {
                    _armorValue = 1;
                    Console.WriteLine("Incorret armor value");
                }
                else
                {
                    _armorValue = value;
                }
            }
        }

        //1.1 Задается строкой в конструкторе.По-умолчанию, значение равно “Helm”
        public Helm() : this("Helm")
        {

        }
        public Helm(string name) 
        { 
        _name = name;
        }
    }

    public class Shell
    {
        private string _name = "Shell";
        private float _armorValue;

        //1.2 Свойство только для чтения;
        public string Name { get { return _name; } }

        //2. Показатель брони (Armor):
        public float Armor
        {
            get
            {
                return _armorValue;
            }
            set
            {
                if (value < 0)
                {
                    _armorValue = 0;
                    Console.WriteLine("Incorret armor value");
                }
                else if (value > 1)
                {
                    _armorValue = 1;
                    Console.WriteLine("Incorret armor value");
                }
                else
                {
                    _armorValue = value;
                }
            }
        }

        //1.1 Задается строкой в конструкторе.По-умолчанию, значение равно “Shell”
        public Shell() : this("Shell")
        {

        }
        public Shell(string name)
        {
            _name = name;
        }
    }

    public class Boots
    {
        private string _name = "Boots";
        private float _armorValue;

        //1.2 Свойство только для чтения;
        public string Name { get { return _name; } }

        //2. Показатель брони (Armor):
        public float Аrmor
        {
            get
            {
                return _armorValue;
            }
            set
            {
                if (value < 0)
                {
                    _armorValue = 0;
                    Console.WriteLine("Incorret armor value");
                }
                else if (value > 1)
                {
                    _armorValue = 1;
                    Console.WriteLine("Incorret armor value");
                }
                else
                {
                    _armorValue = value;
                }
            }
        }

        //1.1 Задается строкой в конструкторе.По-умолчанию, значение равно “Boots”
        public Boots() : this("Boots")
        {

        }
        public Boots(string name)
        {
            _name = name;
        }
    }
}
