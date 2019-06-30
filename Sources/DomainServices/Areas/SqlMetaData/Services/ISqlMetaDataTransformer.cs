namespace Mmu.DrawIoBuddy.DomainServices.Areas.SqlMetaData.Services
{
    public interface ISqlMetaDataTransformer
    {
        string Transform(string metaDataSql);
    }
}