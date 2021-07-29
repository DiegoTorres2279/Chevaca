
using System;
using Domain.Chevaca;

namespace Domain.Context
{
    public class DbInitializer
    {
        public static void Initialize(ChevacaDB_Context context)
        {
            bool init = context.Database.EnsureCreated();

            if (init)
            {
                Ranch ranch_one = new Ranch(1,"030224640013", "La Capelina", "lacapelina", "Juan newbery borba cousillas", "ninguno"  );

                Land land_one = new("1","Boliche Blanco", "");
                //Land land_two = new("2","Tres Boliches", "");
                string heltec_encode = "";
                string heltec_decode = @" function Decode(fPort, bytes, variables) {
                    var decoded = {};
                    decoded.lat = ((bytes[0] << 16) >>> 0) + ((bytes[1] << 8) >>> 0) + bytes[2];
                    decoded.lat = (decoded.lat / 16777215.0 * 180) - 90;
                    decoded.lon = ((bytes[3] << 16) >>> 0) + ((bytes[4] << 8) >>> 0) + bytes[5];
                    decoded.lon = (decoded.lon / 16777215.0 * 360) - 180;
                    decoded.info = 'Signal_OK';

                    var altValue = ((bytes[6] << 8) >>> 0) + bytes[7];
                    var sign = bytes[6] & (1 << 7);
                    if (sign) {
                        decoded.alt = 0xFFFF0000 | altValue;
                    } else {
                        decoded.alt = altValue;
                    }
                    if (decoded.alt === 0) {
                        decoded.info = 'Signal_NOT.';
                    }
                    decoded.hdop = bytes[8] / 10.0;    
                    //decoded.numeracion = ((bytes[9] << 8) >>> 0) + bytes[7]; // Igual a ALT.
                    decoded.num = bytes[9];
                    return decoded;
                }";
                
                Guid chirpstack_profile_id = Guid.Parse("5fc42a48-3bc6-4e54-bc74-f0d2c3cda878");
                string payload_codec = "CUSTOM_JS";
                Ch_Profile profile_heltec = new Ch_Profile(chirpstack_profile_id,"Heltec",payload_codec,heltec_encode, heltec_decode, "5") ;
                
                Ch_Device device_one = new Ch_Device("Collar_Heltec_01","277030173516ab7b", profile_heltec );
                Ch_Device device_two = new Ch_Device("Collar_Heltec_02","35640deaa04955ec",profile_heltec);
                Ch_Device device_three = new Ch_Device("Collar_Heltec_03","82b38300a9095a66",profile_heltec);
                Ch_Device device_four = new Ch_Device("Collar_Heltec_04","29ba60b676470545",profile_heltec);
                Ch_Device device_five = new Ch_Device("Collar_Heltec_05","e8140d639654924b",profile_heltec);
                Ch_Device device_six = new Ch_Device("Collar_Heltec_06","643e23813c5d01ed",profile_heltec);
                Ch_Device device_seven = new Ch_Device("Collar_Heltec_07","672c22212180781e",profile_heltec);
                Ch_Device device_eight = new Ch_Device("Collar_Heltec_08","d6974ba5488cdf53",profile_heltec);
                Ch_Device device_nine = new Ch_Device("Collar_Heltec_09","795b5c94eb15637e",profile_heltec);
                Ch_Device device_ten = new Ch_Device("Collar_Heltec_10","f06e7d7900505d2d",profile_heltec);
                
                Animal animal_one = new(device_one, "F");
                Animal animal_two = new(device_two, "M");
                Animal animal_three = new(device_three, "F");
                Animal animal_four = new(device_four, "M");
                Animal animal_five = new(device_five, "F");
                Animal animal_six = new(device_six, "M");
                Animal animal_seven = new(device_seven, "F");
                Animal animal_eight = new(device_eight, "F");
                Animal animal_nine = new(device_nine, "F");
                Animal animal_ten = new(device_ten, "M");
                
                land_one.Animals.Add(animal_one);
                land_one.Animals.Add(animal_two);
                land_one.Animals.Add(animal_three);
                land_one.Animals.Add(animal_four);
                land_one.Animals.Add(animal_five);
                land_one.Animals.Add(animal_six);
                land_one.Animals.Add(animal_seven);
                land_one.Animals.Add(animal_eight);
                land_one.Animals.Add(animal_nine);
                land_one.Animals.Add(animal_ten);
                
                ranch_one.Lands.Add(land_one);

                context.Db_Ranchs.Add(ranch_one);
                context.SaveChanges();

            }   
        }
    }
}