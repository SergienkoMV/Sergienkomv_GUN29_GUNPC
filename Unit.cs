namespace Homewark_Classs
{
    public class Unit
    {
        //Переменные
        private string name;
        private float health;
        float damage;
        float baseDamage = 5f;
        private float _armor;
        private Weapon weapon;
        private Helm helm;
        private Shell shell;
        private Boots boots;

        //public string Weapon 
        //{
        //    get
        //    {
        //        if (weapon != null)
        //        {
        //            return weapon;
        //        }
        //        return "Unnamed weapon";
        //    }
        //}

        //Свойстно для имени name: Свойство только для чтения
        public string Name { get => name; }

        //Свойство для здороья health: Свойство только для чтения
        public float Health { get => health; }

        //Свойство для здороья урона damage: 
        public float Damage
        {
            get
            {
                //!!!пока не понял как здесь получить урон из другого класса. По идее это можно сделать с помощью отдельного метода
                //но как это сделать в свойствах, непонятно.

                if (weapon != null) 
                {
                    damage = baseDamage + weapon.GetDamage();
                    return damage;
                }
                return baseDamage;
            }
            set
            {
                //damage = Weapon.GetDamage(); //Weapon.GetDamage();
            }
        }

        public float Armor
        {
            get
            {
                //4.3 Значение рассчитывается как сумма показателя брони шлема(класс Helm), доспехов(класс Shell) и ботинок(класс Boots);
                if (helm != null)  { _armor += helm.Аrmor; }
                if (shell != null) { _armor += shell.Armor; }
                if (boots != null) { _armor += boots.Аrmor; }

                //4.1 Возвращает число типа float (округленное до двух знаков);
                _armor = (float)Math.Round(_armor, 2, MidpointRounding.AwayFromZero); //без MidpointRounding.AwayFromZero по описанию
                //отрабатывает банковское округление (до ближайшего четного числа).

                //4.2 Значение определяется в диапазоне от 0 до 1;
                if (_armor < 0)
                {
                    _armor = 0;
                }
                else if (_armor > 1)
                {
                    _armor = 1;
                }
                return _armor;
            }
        }

        //Открытые методы:
        //1. Конструктор
        //1.1
        //1.3 Конструктор без аргумента должен вызывать конструктор с аргументом через ключевое слово this;
        public Unit() : this("Unknown Unit") { }
        
        //1.2
        public Unit(string UnitName)
        {
            name = UnitName;
        }

        public Unit(string UnitName, float UnitHealth)
        {
            name = UnitName;
            health = UnitHealth;
        }

        //Methods:
        //2. Фактическое здоровье
        public float RealHealth() => Health * (1f + Armor);

        //3. Получить урон
        public bool SetDamage(float value)
        {
            //3.2
            //int value = 1; // value - в задании не описано, чему равно.
            float realHealth;
            if (Armor != 0)
            {
                health = RealHealth() - value * Armor; 
                //realHealth = RealHealth() - value * Armor; //value - в задании не описано, чему равно.
            }
            else
            {

                health = RealHealth() - value;
                //realHealth = RealHealth() - value;
            }

            //3.1
            
            if (health <= 0)
            //if (realHealth <= 0)
            {
                return true;
            }
            return false;
        }

        //4. Снарядить оружие 
        public void EquipWeapon(Weapon weapon)
        {
            //4.3 Заменяет текущее оружие (если оно есть) на новое;
            //Добавить после описания класса и методов Weapon
            //В задании нет описания работы и использования данного метода.
            this.weapon = weapon;
        }

        //5. Набор методов снарядить броню 
        public void EquipHelm(Helm helm)
        {
            //5.3 Заменяет текущее снаряжение (если оно есть) на новое.
            //helm = new Helm();
            this.helm = helm;
        }

        public void EquipShell(Shell shell)
        {
            //5.3 Заменяет текущее снаряжение (если оно есть) на новое.
            this.shell = shell;
        }

        public void EquipBoots(Boots boots)
        {
            //5.3 Заменяет текущее снаряжение (если оно есть) на новое.
            this.boots = boots;
        }
    }

}
