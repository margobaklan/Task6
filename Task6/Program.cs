using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

string path = @"C:\Users\Margo\source\repos\Task6\Task6\bookinfo.json";
using (FileStream fs = new FileStream(path, FileMode.Open))
{
    var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
    foreach (var book in books)
    {
        Console.WriteLine($"{book.PublishingHouseId} - {book.Title} - {book.PublishingHouse.Id} - " +
                    $"{book.PublishingHouse.Name} - {book.PublishingHouse.Adress}");
    }
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
    public int PublishingHouseId { get; set; }
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