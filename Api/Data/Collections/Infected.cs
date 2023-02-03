using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Data.Collections
{
    public class Infected
    {
        public Infected(DateTime birthdate, string sex, double latitude, double longitude)
        {
            this.Birthdate = birthdate;
            this.Sex = sex;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}