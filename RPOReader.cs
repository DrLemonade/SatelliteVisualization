using System;
using CSVHelper;

public class RPOReader{
    private string File;
    private DoublyLinkedList List;
    public RPOReader(string file){
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
                        "secondsSinceStart", "timeJulianDay", "timeUtcYear", "timeUtcMonth", "timeUtcDay",
                        "timeUtcHour", "timeUtcMinute", "timeUtcSeconds", "positionChiefEciX", "positionChiefEciY",
                        "positionChiefEciZ", "velocityChiefEciX", "velocityChiefEciY", "velocityChiefEciZ",
                        "positionDeputyEciX", "positionDeputyEciY", "positionDeputyEciZ", "velocityDeputyEciX",
                        "velocityDeputyEciY", "velocityDeputyEciZ", "positionDepRelToChiefEciX", "positionDepRelToChiefEciY",
                        "positionDepRelToChiefEciZ", "velocityDepRelToChiefEciX", "velocityDepRelToChiefEciY", "velocityDepRelToChiefEciZ",
                        "positionDepRelToChiefLvlhX", "positionDepRelToChiefLvlhY", "positionDepRelToChiefLvlhZ", "velocityDepRelToChiefLvlhX",
                        "velocityDepRelToChiefLvlhY", "velocityDepRelToChiefLvlhZ", "relativeRange", "relativeVelocity", "relativeRangeRate",
                        "attitudeMode", "attitudeDeputyEci2BodyQx", "attitudeDeputyEci2BodyQy", "attitudeDeputyEci2BodyQz", "attitudeDeputyEci2BodyQs",
                        "sunDirectionEciX", "sunDirectionEciY", "sunDirectionEciZ", "sunDirectionLvlhX"
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
                    DoublyLinkedList.InsertFirst(record);
                }
            }
    }
}