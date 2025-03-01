using System;
using CSVHelper;

public class ManeuverReader{
    private string File;
    private DoublyLinkedList<ManeuverData> List;
    public ManeuverReader(string file){
        File = file;
        List = new DoublyLinkedList<ManeuverData>();
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
                        "maneuverId", "secondsSinceStart", "timeJulianDay", "TimeUtcYear", "TimeUtcMonth",
                        "TimeUtcDay", "TimeUtcHour", "TimeUtcMinute", "TimeUtcSeconds", "dVEciX",
                        "dVEciY", "dVEciZ", "dVLvlhX", "dVLvlhY", "dVLvlhZ", "dVBodyX", "dVBodyY", "dVBodyZ",
                        "dVMagnitude", "WaypointX", "WaypointY", "WaypointZ",
                        "WaypointTransferTime" 
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


                    RpoData record = new RpoData(dataMap);
                    List.InsertFirst(record);
                }
            }
    }
}