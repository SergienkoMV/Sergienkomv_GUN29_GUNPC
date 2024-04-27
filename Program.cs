namespace Homewark_Classs
{


    internal class Program
    {
        static void Main(string[] args)
        {
            //float WarriorHealth;
            string WarriorName;
            Unit warrior;
            Helm helm = new Helm();
            Shell shell = new Shell();
            Boots boots = new Boots();
            Weapon weapon;

            //1. При запуске программы выводится сообщение “Подготовка к бою:”;
            Console.WriteLine("Preparation for battle");

            //2. Выводится сообщение с запросом: “Введите имя бойца:”. Далее ожидается ввод имени юнита;
            Console.WriteLine("Input warrior's name:");

            while (true)
            {
                WarriorName = Console.ReadLine();
                if (WarriorName != "")
                {
                    break;
                }
                Console.WriteLine("Incorrect input. Input warrior's name");
            }

            //3.	Выводится сообщение с запросом: “Введите начальное здоровье бойца (10-100):”.
            //Далее ожидается целое число в диапазоне от 10 до 100 включительно;
            Console.WriteLine("Input start health for warrior, from 10 to 100");
            InputHealth();
       

            //4.	Выводится сообщение с запросом: “Введите значение брони шлема от 0, до 1:”.
            //Далее ожидается число типа float в диапазоне от 0 до 1, включительно;
            helm.Аrmor = InputArmor("helm");
            warrior.EquipHelm(helm);

            //5.	Выводится сообщение с запросом: “Введите значение брони кирасы от 0, до 1:”.
            //Далее ожидается число типа float в диапазоне от 0 до 1, включительно;
            shell.Armor = InputArmor("shell");
            warrior.EquipShell(shell);

            //6.	Выводится сообщение с запросом: “Введите значение брони сапог от 0, до 1:”.
            //Далее ожидается число типа float в диапазоне от 0 до 1, включительно;
            boots.Аrmor = InputArmor("boots");
            warrior.EquipBoots(boots);

            //7. Выводится сообщение с запросом: “Укажите минимальный урон оружия (0-20): “.
            //Далее ожидается число типа float в диапазоне от 0 до 20 включительно;
            //8. Выводится сообщение с запросом: “Укажите максимальный урон оружия(20 - 40): “.
            //Далее ожидается число типа float в диапазоне от 20 до 40 включительно;
            weapon = new Weapon("Sward", InputDamage("min", 0, 20), InputDamage("max", 20, 40));
            warrior.EquipWeapon(weapon);
            

           void InputHealth()
            {
                while (true)
                {
                    if (float.TryParse(Console.ReadLine(), out var TypedHealth))
                    {
                        if (TypedHealth < 10)
                        {
                            Console.WriteLine("Health should be more then 10. Please input again");
                            continue;
                        }
                        else if (TypedHealth > 100)
                        {
                            Console.WriteLine("Health should be less then 100. Please input again");
                            continue;
                        }
                        else
                        {
                            warrior = new Unit(WarriorName, TypedHealth);
                            break;
                        }
                    }
                }
            }

            float InputArmor(string armorType)
            {
                Console.WriteLine("Input armor for " + armorType + ", from 0 to 1");
                while (true)
                {
                    if (float.TryParse(Console.ReadLine(), out var a))
                    {
                        if (a < 0 || a > 1)
                        {
                            Console.WriteLine("Incorret value. Input value from 0 to 1");
                        }
                        else
                        {
                            return a;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value for armour. Input number from 0 to 1");
                    }
                }
            }

            float InputDamage(string valueLimit, int minValue, int maxValue)
            {
                Console.WriteLine("Input " + valueLimit + " damage for weapon, from " + minValue + " to " + maxValue);
                while (true)
                {
                    if (float.TryParse(Console.ReadLine(), out var a))
                    {
                        if (a < minValue || a > maxValue)
                        {
                            Console.WriteLine("Incorret value. Input value from " + minValue + " to " + maxValue);
                        }
                        else
                        {
                            return a;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value for armour. Input number " + minValue + " to " + maxValue);
                    }
                }
            }

            //9. На основе введенных данных создается экземпляр класса Unit для игрока;
            //Unit player = new Unit(WarriorName);

            //10. В консоль выводится сообщение “Общий показатель брони равен: “.
            //Далее выводится значение свойства Armor юнита;
            Console.WriteLine("The warrior created:");    
            Console.WriteLine("Warrior's name is: " + warrior.Name);
            Console.WriteLine("Warrior's HP = " + warrior.Health);
            Console.WriteLine("Common value of armor = " + warrior.Armor);
            Console.WriteLine("Weapon name = " + weapon.Name);
            Console.WriteLine("Weapon Damage = " + warrior.Damage);

            //11. В консоль выводится сообщение “Фактическое значение здоровья равно: “.
            //Далее выводится значение свойства RealHealth;
        }
    }
}
