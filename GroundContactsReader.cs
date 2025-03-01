using System;
using CSVHelper;

public class GroundContactsReader{
    private string File;
    private DoublyLinkedList List;
    public GroundContactsReader(string file){
        File = file;
        List = new DoublyLinkedList();
    }

    public void ReadFile(){
        using (var reader = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + File))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                for (int i = 0; csv.Read(); i++)
                {
                    Dictionary<string, double> dataMap = new Dictionary<string, double>();

                    string[] keys = new string[]
                    {
                        "contactId","startSeconds","stopSeconds","startJulianDate","stopJulianDate","startUtcYear","startUtcMonth",
                        "startUtcDay","startUtcHour","startUtcMinute","startUtcSeconds","stopUtcYear","stopUtcMonth","stopUtcDay",
                        "stopUtcHour","stopUtcMinute","stopUtcSeconds","groundSite"

                    };

                    foreach (var key in keys)
                    {
                        if (double.TryParse(csv.GetField(key), out double value))
                        {
                            dataMap[key] = value;
                        }
                        else
                        {
                            Console.WriteLine($"Error parsing field: {key}");
                        }
                    }


                    List.InsertFirst(dataMap);
                }
            }
    }
}