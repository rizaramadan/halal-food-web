namespace Web.Models;

public class SearchPageModel
{
    public KeyValuePair<string,string>[] Status =
    {
        KeyValuePair.Create("Halal", "Halal"),
        KeyValuePair.Create("Claim", "Claim Halal"),
        KeyValuePair.Create("No", "Tidak Halal"),
        KeyValuePair.Create("NA", "Belum Ada Respon")
    };

    public string[] Wilayah = {"Jakarta","Bandung"};
    public string[] Category = {"Cafe","Chinese"};

    public SearchPageModel(string[] wilayah, string[] categories)
    {
        Wilayah = wilayah;
        Category = categories;
    }
}
