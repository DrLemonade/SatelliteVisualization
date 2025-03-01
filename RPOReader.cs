using System;
using CSVHelper;

public class RPOReader{
    private string File;
    public RPOReader(string file){
        File = file;
    }

    public void ReadFile(){
        using (var reader = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + File))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                for (int i = 0; csv.Read(); i++)
                {
                    int secondsSinceStart;
                    double timeJulianDay;
                    int timeUtcYear;
                    int timeUtcMonth;
                    int timeUtcDay;
                    int timeUtcHour;
                    int timeUtcMinute;
                    int timeUtcSeconds;
                    double positionChiefEciX;
                    double positionChiefEciY;
                    double positionChiefEciZ;
                    double velocityChiefEciX;
                    double velocityChiefEciY;
                    double velocityChiefEciZ;
                    double positionDeputyEciX;
                    double positionDeputyEciY;
                    double positionDeputyEciZ;
                    double velocityDeputyEciX;
                    double velocityDeputyEciY;
                    double velocityDeputyEciZ;
                    


                    RpoData record = new RpoData(firstName, lastName, gender, dob, patientID, i);
                    DoublyLinkedList.InsertFirst(record);
                }
            }
    }
}