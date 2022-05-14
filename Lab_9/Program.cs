using System.Text;
using System.Text.Encodings;
using System.Text.Encodings.Web;
using System.IO;

//Проверить уникальность записей по свойству Street.
//Найти заказ с наибольшей ценой.
//Отсортировать заказы по имени покупателя.
//Переместить заказы, где Tag имеет значение "Кошелек", в отдельный список.
//Сгенерировать новые случайные записи и добавить их в список, учитывая следующие условия: свойство Id должно быть итеративным, свойства ProductId, CustomerId, Phone, Email должны быть уникальными.

var file = "tabl.csv";
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Encoding encoding = Encoding.GetEncoding(1251);

var lines = File.ReadAllLines(file, encoding);
var infos = new Inform[lines.Length - 1];
for (int z = 1; z < lines.Length; z++)
{
    var splits = lines[z].Split(';');

    var info = new Inform();
    info.Id = Convert.ToInt32(splits[0]);
    info.Name = splits[1];
    info.Email = splits[2];
    info.Phone = splits[3];
    info.Age = Convert.ToInt32(splits[4]);
    info.City = splits[5];
    info.Street = splits[6];
    info.Tag = splits[7];
    info.Price = Convert.ToInt32(splits[8]);
    info.CustomerId = splits[9];
    info.ProductId = splits[10];

    infos[z - 1] = info;
}

//Задание 2
var maxprice = infos.Max(x => x.Price);
Console.WriteLine("Задание 2");
Console.Write("Наибольшая цена заказа:");
Console.WriteLine(maxprice);

//Задание 3
var sortinform = from p in infos
                 orderby p.Name
                 select p;
var result = "SortByName.csv";
using (StreamWriter streamWriter = new StreamWriter(result, false, encoding))
{
    streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");
    foreach (var info in sortinform)
    {
        streamWriter.WriteLine(info.ToExcel());
    }
}
//Задание 4
var sorttag = from v in infos
                 where v.Tag=="Кошелек"
                 select v;
var result1 = "SortByTag.csv";
using (StreamWriter streamWriter = new StreamWriter(result1, false, encoding))
{
    streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");
    foreach (var inf in sorttag)
    {
        streamWriter.WriteLine(inf.ToExcel());
    }
}
//Задание 1
Console.WriteLine("Задание 1");
var b = infos.GroupBy(a => a.Street).Where(l => l.Count() > 1).Select(l => l.Key);
if (b?.Any()==true)
{
    Console.WriteLine("Неуникальные записи:");
    foreach (var g in b)
    {
        Console.WriteLine(g);
    }
}
else
{
    Console.WriteLine("Все записи по свойству Street уникальны");
}
//Задание 5

Random rand = new Random();
string[] names = { "Владимир Редков", "Антон Шастун", "Арина Мелякина", "Мария Попова", "Ксения Чемлекчиева", "Роман Шершнёв", "Дмитрий Позов", "Егор Черемисинов", "Егор Мусин", "Владимир Артемьев", "Дима Билан", "Алексей Мышев", "Алексей Сидоров", "Дмитрий Синицкий", "Елена Кобылина" };
string[] emails = { "vlad_red@mail.ru", "shastoon007@impro.com", "todayisbad_astrh_17@gmail.ru", "maria_popit@yandeks.ru", "rvshershnev_23@mail.ru", "dimasik_poz@ixbox.ru", "eg_palma14@iate.ru", "egor_musin@yandex.ru", "papa_smurf@gmail.com", "kambridge_al666@mail.ru", "evniwoc_lexa@mail.com", "dmitrii_matrix@gmail.ru", "economica_onelove@mail.ru" };
string[] phones = {"(957)672-43-05", "(967)992-43-15", "(900)612-82-05", "(999)672-29-05", "(911)112-43-05", "(957)205-43-77", "(901)672-91-83", "(966)072-43-00", "(900)672-00-05", "(907)031-94-05", "(957)492-20-05", "(982)204-43-93", "(957)395-55-05", "(929)438-43-05", "(957)964-02-66" };
int[] ages = { 28, 33, 18, 19, 20, 24, 29, 21, 17, 55, 47, 80, 22, 57, 53 };
string[] cities = { "Москва", "Санкт-Петербург", "Астрахань", "Калуга", "Протвино", "Обнинск", "Тула", "Воронеж", "Екатеринбург", "Североморск", "Оболенск", "Казань", "Серпухов", "Подольск", "Волгоград" };
string[] streets = { "Ленинградское шоссе", "улица Южная", "улица Пушкинская", "улица Студгородок", "проспект Маркса", "улица Красных Зорь", "бульвар Победы", "Рязанский проспект", "Фестивальный проезд", "Лесной бульвар", "улица Московская", "Треугольная площаль", "проспект Ленина", "улица Ленина", "улица Курчатова" };
string[] tags = { "Вечернее платье", "Миксер", "Наушники", "Переноска", "Клавиатура", "Гантели", "Обруч", "Планетарный миксер", "Коврик для мышки", "Кроссовки", "Бальные туфли", "Чеснокодавилка", "Набор фломастеров", "Картина по номерам", "Самокат" };
int[] prices = { 3777, 290, 1000, 360, 20000, 900, 8200, 3000, 9225, 3990, 8900, 12000, 11300, 9300, 650 };
char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
var idcustome = new List<string>();
var idproduct = new List<string>();

//генерируем случайные стороки для CustomerId
for (int i = 0; i<15; i++) //отвечает за кол-во
{
    string str = "";
    for (int j = 0; j < 11; j++)
    {
        var h = symbols[rand.Next(0,symbols.Length)];
        str += h;
    }
    idcustome.Add(str);
}

//генерируем случайные стороки для ProductId
for (int s = 0; s < 15; s++) //отвечает за кол-во
{
    string str1 = "";
    for (int o = 0; o < 11; o++) //отвечает за длину
    {
        var m = symbols[rand.Next(0, symbols.Length)];
        str1 += m;
    }
    idproduct.Add(str1);
}
using (StreamWriter writer = new StreamWriter(file, true, encoding))
{
    for (int e = infos.Length + 2; e < infos.Length + 10; e++)
    {
        var newrecord = new List<Inform>()
        {
            new Inform {Id=e,Name=names[rand.Next(0,names.Length)], Email=emails[rand.Next(0,emails.Length)], Phone=phones[rand.Next(0,phones.Length)], Age=ages[rand.Next(0,ages.Length)], City=cities[rand.Next(0,cities.Length)], Street=streets[rand.Next(0,streets.Length)], Tag=tags[rand.Next(0,tags.Length)], Price=prices[rand.Next(0,prices.Length)], CustomerId=idcustome[rand.Next(0,idcustome.Count)], ProductId=idproduct[rand.Next(0,idproduct.Count)]}
        };
        foreach (var y in newrecord)
        {
            writer.WriteLine(y.ToExcel());
        }
    }
}



public class Inform
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Tag { get; set; }
    public int Price { get; set; }
    public string CustomerId { get; set; }  
    public string ProductId { get; set; }


    public override string ToString()
    {
        return $"Id: {Id}\n Имя и Фамилия: {Name}\n Электорнный адрес: {Email}\n Номер телефона: {Phone}\n Возраст: {Age}\n Город: {City}\n Улица: {Street}\n Товар: {Tag}\n Цена: {Price}\n Id покупателя: {CustomerId}\n Id товара: {ProductId}\n";
    }
    public string ToExcel()
    {
        return $"{Id};{Name};{Email};{Phone};{Age};{City};{Street};{Tag};{Price};{CustomerId};{ProductId}";
    }
}
