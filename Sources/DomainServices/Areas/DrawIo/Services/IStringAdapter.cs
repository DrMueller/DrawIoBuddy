namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services
{
    public interface IStringAdapter
    {
        string EncodeToDrawIoString(string str);

        string DecodeToNativeString(string str);
    }
}