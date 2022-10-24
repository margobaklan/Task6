using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

var books = new List<Book>();

var PublishingHouseInfo1 = new PublishingHouseInfo(2, "ГІМНАЗІЯ", "Адреса 2");
var PublishingHouseInfo2 = new PublishingHouseInfo(1,"Видавництво старого лева", "Адреса 1");
var b1 = new Book(2, "Підручник. Алгебра 8", PublishingHouseInfo1);
var b2 = new Book(1, "Щоденник нейрохірурга", PublishingHouseInfo2);
var b3 = new Book(2, "Посібник. Алгебра 9", PublishingHouseInfo2);

books.Add(b1);
books.Add(b2);
books.Add(b3);

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
};

string path = @"C:\Users\Margo\source\repos\Task6\Task6.2\bookinfoS.json";
using (FileStream fs = new FileStream(path, FileMode.Create))
{
    await JsonSerializer.SerializeAsync(fs, books, options);
    Console.WriteLine("Записано у файл");
}
Console.ReadKey();

public class Book
{
    public Book(int publishingHouseId, string title, PublishingHouseInfo publishingHouse)
    {
        PublishingHouseId = publishingHouseId;
        Title = title;
        PublishingHouse = publishingHouse;
    }
    //[JsonIgnore] 
    public int PublishingHouseId { get; set; }
    //[JsonPropertyName("Name")]
    public string? Title { get; set; }
    public PublishingHouseInfo PublishingHouse { get; set; }
}

public class PublishingHouseInfo
{
    public PublishingHouseInfo(int id, string name, string adress)
    {
        Id = id;
        Name = name;
        Adress = adress;
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Adress { get; set; }
}