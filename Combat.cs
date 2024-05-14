using System;

namespace Homewark_Classs
{
    //Структура Interval, будет использоваться для определение границ интервала чисел с плавающей точкой.
    public struct Interval
    {
        //Предположительно, я все объявляю в классе, а надо в структуре
        private float _minValue = 0f; //без иницализации поля, конструктор вызывающий другой конструкторв выдает ошибку
        private float _maxValue = 0f;
        //private float _minDamage;
        //private float _maxDamage;


        //1. Конструктор с двумя целочисленными аргументами.Первый minValue, второй - maxValue.
        //Конструктор вызывает внутри себя второй конструктор;
        //Конструктор 1:

        public Interval(int minValue, int maxValue)
        {
            new Interval((float)minValue, (float)maxValue);
        }

        //2. Конструктор с двумя аргументами типа числа с плавающей точкой.
        //Первый minValue - определяет нижнюю границу интервала, второй - maxValue - определяет верхнюю границу интервала;
        //Конструктор 2:
        public Interval(float minValue, float maxValue)
        {
            //4. Внутри конструктора должна проверяться допустимость входных значений.
            //Если minDamage больше maxDamage - числа меняются местами,
            //а в консоль выводится сообщение о некорректных входных данных;
            if (minValue > maxValue)
            {
                _maxValue = minValue;
                _minValue = maxValue;
                Console.WriteLine("Incorrect data. Min value more than max.");
            } 
            else
            //5.Если оба числа равны - инициализация должна произойти без сообщений;
            {
                _minValue = minValue;
                _maxValue = maxValue;
            }
        }

        //3. Конструктор с одним числом с плавающей точкой.
        //value - вызывает внутри себя второй конструктор,
        //где в качестве первого и второго аргумента передается свой собственный аргумент;
        //Конструктор 3:
        Interval(float value)
        {
            new Interval((float)value, (float)value);
        }

        ////Open properties:
        ////1. Получить (Get) - возвращает случайное число из интервала между minValue и maxValue;
        public float Get
        {
            get
            {
                var rand = new Random();
                double randomValue = rand.NextDouble();
                double range = Min - Max;
                double randomInRange = range * randomValue + _minValue;
                return (float)randomInRange;
            }
        }
        //2. Минимум(Min) - возвращает значение, равное минимальной границе интервала;
        public float Min { get => _minValue; }
        //3. Максимум(Max) - возвращает значение, равное максимальной границе интервала;
        public float Max { get => _maxValue; }
        //4. Среднее(Average) - возвращает средне арифметическое значение интервала;
        public float Avarage { get => (Min + Max) / 2; }


        //Из задания не очевидно откуда берутся minDamage и maxDamage, так как не описаны нигде,
        //кроме как в разделе Конструкторы, пункт 4. Предположил,
        //что параметры, которые устанвливаются значениями maxValue и minValue
        //private float MinDamage { set => _minValue = value; }
        //private float MaxDamage { set => _maxValue = value; }
    }


    
    //Структура Rate, будет хранить информацию об одном кадре поединка между персонажами:
    public struct OneRate
    {
        //1. Поле Unit - хранит ссылку на юнита, который наносил урон;
        public Unit Alien;
        //2. Поле Damage - хранит целочисленное значение урона, нанесенное юниту;
        public int GetDamage;
        //3. Поле Health - хранит число с плавающей точкой, означающее здоровье, оставшееся у юнита после атаки.
        //Округляется до двух знаков после запятой;
        public float SetHealth; //округление реализовано в конструкторе. 



        //4. Конструктор, принимает три аргумента: ссылка на экземпляр класса юнита, инициирующего атаку,
        //значение нанесенного урона и значение здоровья противника.

        public OneRate(Unit alienUnit, float getDamage, float health)
        {
            Alien = alienUnit;
            GetDamage = (int)getDamage;
            SetHealth = (float)Math.Round(health, 2, MidpointRounding.AwayFromZero);
        }
    }


    //Класс Combat, инкапсулирующий логику работы боя
    public class Combat
    {
        //1.	Внутри класса хранится массив Rate и индекс, указывающий на текущий индекс.
        //По-умолчанию, в Rate 1 элемент и индекс равен 0.
        public OneRate[] Rate;
        private uint _index; //как я понял по умолчанию инициализируется со значением 0
        
        //2.	Конструктора нет. Конструктор по-умолчанию инициализирует массив.
        public Combat()
        {
            Rate = new OneRate[1];        
        }

        //3.	Два публичных метода: StartCombat, принимающий на вход два экземпляра юнитов, и ShowResults, выводящий результат боя.
        public void StartCombat(Unit unit1, Unit unit2)
        {
            //4.	Внутри StartCombat запускается бесконечный цикл.

            //int randNumber = rand.Next(0, 11);
            //if (randNumber % 2 == 0)
            //{
            //    Console.WriteLine("Урон получил игрок " + unit1.Name);
            //    //5.	Происходит создание новой структуры Rate и сохранение в массив. 
            //    Rate[x] = new OneRate(unit1, 1, unit1.Health);
            //    x++;

            //}
            //else
            //{
            //    Console.WriteLine("Урон получил игрок " + unit2.Name);
            //    //5.	Происходит создание новой структуры Rate и сохранение в массив. 
            //    Rate[x] = new OneRate(unit2, 1, unit2.Health - 1);
            //    x++;
            //}
            int x = 0;
            var rand = new Random();
            while (true)
            {
                //Бой проходит в автоматическом режиме с применением случайных чисел (используйте класс Random).

                int randNumber = rand.Next(0, 11);
                //Если выпадает чётное число (от 1 до 10) - урон получает первый боец, если нечётное - урон получает второй боец.

                if (randNumber % 2 == 0) 
                {

                    //5.	Происходит создание новой структуры Rate и сохранение в массив. 
                    if (Rate.Length > x) //при первом проходи длинна масива 1 и x = 0. Не надо делать Resize
                    {
                        unit1.SetDamage(unit2.Damage);
                        Rate[x] = new OneRate(unit2, unit2.Damage, unit1.Health);
                    } 
                    else
                    {
                        unit1.SetDamage(unit2.Damage);
                        Array.Resize(ref Rate, Rate.Length + 1);
                        Rate[x] = new OneRate(unit2, unit2.Damage, unit1.Health);
                    }
                    Console.WriteLine("Урон получил игрок " + unit1.Name);
                    Console.WriteLine("Получено " + unit2.Damage + " урона");
                    Console.WriteLine("У воина " + unit1.Name + " осталось " + unit1.Health + " HP");
                }
                else
                {
                    //5.	Происходит создание новой структуры Rate и сохранение в массив. 
                    if (Rate.Length > x) //при первом проходи длинна масива 1 и x = 0. Не надо делать Resize
                    {
                        unit2.SetDamage(unit1.Damage);
                        Rate[x] = new OneRate(unit1, unit1.Damage, unit2.Health);
                    }
                    else
                    {
                        unit2.SetDamage(unit1.Damage);
                        Array.Resize(ref Rate, Rate.Length + 1);
                        Rate[x] = new OneRate(unit1, unit1.Damage, unit2.Health);
                    }
                    Console.WriteLine("Урон получил игрок " + unit2.Name);
                    Console.WriteLine("Получено " + unit2.Damage + " урона");
                    Console.WriteLine("У воина " + unit2.Name + " осталось " + unit2.Health + " HP");
                }
                x++;

                //6.	Как только здоровье одного из бойцов падает до 0, цикл завершается.
                if (unit1.Health == 0 || unit2.Health == 0)
                {
                    break;
                }
            }
        }

        //3.	Два публичных метода: StartCombat, принимающий на вход два экземпляра юнитов, и ShowResults, выводящий результат боя.
        public void ShowResults() 
        {
            //7.	Внутри метода ShowResults происходит итерация по элементам массива Rate и выводится результат:
            //Боец <Имя> нанёс урон <значение урона> и оставил <значение здоровья> здоровья.
            for (int i = 0; i < Rate.Length; i++)
            {
                Console.WriteLine("Боец " + Rate[i].Alien.Name + "нанес урон " + Rate[i].GetDamage + " и оставил " + Rate[i].SetHealth);   
            }
            //return;
        }

        //private void GetHit(Unit unit, Unit alienUnit, float getDamage, int setHealth)
        //{
        //    var rand = new Random();


        //    if (randNumber % 2 == 0)
        //    {
        //        Console.WriteLine("Урон получил игрок " + unit1.Name);
        //        //5.	Происходит создание новой структуры Rate и сохранение в массив. 
        //        Rate[x] = new OneRate(unit1, 1, unit1.Health);
        //        x++;
        //        GetHit(Unit unit1, Unit unit2, 1, unit1.Health);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Урон получил игрок " + unit2.Name);
        //        //5.	Происходит создание новой структуры Rate и сохранение в массив. 
        //        Array.Resize(ref Rate, Rate.Length);
        //        Rate[x] = new OneRate(unit2, 1, unit2.Health - 1);
        //        x++;
        //    }
        //    Console.WriteLine("Урон получил игрок " + unit.Name);
        //}
    }
}
