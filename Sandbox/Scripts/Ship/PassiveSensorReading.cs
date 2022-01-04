public struct PassiveSensorReading
{
    public ulong ContactID {get; private set;}
    public float Heading { get; private set; }    
    public GravitySignature Signature { get; private set; }    

    public PassiveSensorReading(ulong contactID, float angle, GravitySignature signature)
    {
        ContactID = contactID;
        Heading = angle;        
        Signature = signature;
    }
}
