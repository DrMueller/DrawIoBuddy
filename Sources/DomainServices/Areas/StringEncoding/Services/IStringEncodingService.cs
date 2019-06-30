namespace Mmu.DrawIoBuddy.DomainServices.Areas.StringEncoding.Services
{
    public interface IStringEncodingService
    {
        string Encode(string nativeString);

        string Decode(string drawIoString);
    }
}