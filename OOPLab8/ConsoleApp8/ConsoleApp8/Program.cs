using System;
using ManLibrary;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Man[] people = new Man[]
        {
            new Student("Олеся", 20, 55.5, "Жінка", 2),
            new Worker("Ігор", 30, 75.0, "Чоловік", "Інженер")
        };

        Console.WriteLine("Меню:");
        Console.WriteLine("1. Показати інформацію про всіх людей");
        Console.WriteLine("2. Змінити інформацію про особу");
        Console.WriteLine("3. Працювати з дробами");
        Console.WriteLine("Введіть Ваш вибір:");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                foreach (var person in people)
                {
                    person.ShowInfo();  // Оновлена інформація після зміни
                }
                break;


            case 2:
                // Запитуємо у користувача, для якої особи змінити дані
                Console.WriteLine("Введіть індекс особи для зміни (0 для першої, 1 для другої):");
                string inputIndex = Console.ReadLine();

                // Перевірка правильності вводу індексу
                if (int.TryParse(inputIndex, out int personIndex) && personIndex >= 0 && personIndex < people.Length)
                {
                    // Запитуємо, яке саме значення хоче змінити користувач
                    Console.WriteLine("Виберіть параметр для зміни:");
                    Console.WriteLine("1. Вік");
                    Console.WriteLine("2. Рік навчання (для студента)");
                    Console.WriteLine("3. Посада (для працівника)");
                    int changeChoice = int.Parse(Console.ReadLine());

                    switch (changeChoice)
                    {
                        case 1:
                            // Зміна віку
                            Console.WriteLine("Введіть новий вік:");
                            string inputAge = Console.ReadLine();
                            if (int.TryParse(inputAge, out int newAge))
                            {
                                people[personIndex].ChangeAge(newAge);
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректний вік!");
                            }
                            break;

                        case 2:
                            // Зміна року навчання (якщо особа студент)
                            if (people[personIndex] is Student student)
                            {
                                Console.WriteLine("Введіть новий рік навчання:");
                                int newYear = int.Parse(Console.ReadLine());
                                student.ChangeYearOfStudy(newYear);
                            }
                            else
                            {
                                Console.WriteLine("Ця особа не є студентом!");
                            }
                            break;

                        case 3:
                            // Зміна посади (якщо особа працівник)
                            if (people[personIndex] is Worker worker)
                            {
                                Console.WriteLine("Введіть нову посаду:");
                                string newPosition = Console.ReadLine();
                                worker.ChangePosition(newPosition);
                            }
                            else
                            {
                                Console.WriteLine("Ця особа не є працівником!");
                            }
                            break;

                        default:
                            Console.WriteLine("Невірний вибір!");
                            break;
                    }

                    // Виведення оновленої інформації про всіх осіб
                    Console.WriteLine("Оновлена інформація про осіб:");
                    foreach (var person in people)
                    {
                        person.ShowInfo();  // Виведемо інформацію для кожної особи
                    }
                }
                else
                {
                    Console.WriteLine("Невірний індекс! Виберіть індекс між 0 та " + (people.Length - 1));
                }
                break;

            case 3:
                var f1 = new Fraction(3, 4);
                var f2 = new Fraction(2, 5);

                // Виведення операцій з дробами
                Console.WriteLine($"{f1} + {f2} = {f1 + f2}");  // Додавання
                Console.WriteLine($"{f1} - {f2} = {f1 - f2}");  // Віднімання
                Console.WriteLine($"{f1} * {f2} = {f1 * f2}");  // Множення
                Console.WriteLine($"{f1} / {f2} = {f1 / f2}");  // Ділення

                // Переведення дробу в десятковий вигляд
                Console.WriteLine($"{f1} як десятковий дріб: {(double)f1}");
                break;
        }
        Console.WriteLine("Натисніть будь-яку клавішу, щоб закрити програму...");
        Console.ReadKey();
    }
}



