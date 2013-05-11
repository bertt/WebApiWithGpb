using System.Runtime.Serialization;


namespace WebApiWithGpb
{
    [DataContract]
    public class Person
    {
        [DataMember(Order= 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }
}